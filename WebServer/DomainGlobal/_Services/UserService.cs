using NOM.Dao.Entities;
using NOM.Dao.Identity;
using NOM.DomainGlobal._Base.Extentions;
using NOM.DomainGlobal.Interfaces;
using NOM.DomainGlobal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static NOM.DomainGlobal.Models.UserModel;

namespace NOM.DomainGlobal._Services
{

    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IdentityDbContext _sso;
        private IMemoryCache _cache;

        public UserService(IHttpContextAccessor httpContextAccessor,
            ApplicationDbContext context,
            IdentityDbContext sso,
            IMemoryCache cache)
        {
            _context = context;
            Username = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            _cache = cache;
            _sso = sso;
        }

        public UserModel userData;
        private readonly object lockTask = new object();
        private string Username { get; }

        public UserModel GetUserInfo()
        {
            if (string.IsNullOrEmpty(Username))
            {
                return null;
            }
            if (userData != null)
            {
                return userData;
            }

            lock (lockTask)
            {
                if (userData != null)
                {
                    return userData;
                }

                // Look for cache key.
                var keyCache = $"userInfo_{Username}";
                if (!_cache.TryGetValue(keyCache, out userData))
                {
                    // login on thi lay du lieu theo tai khoan dang nhap
                    var query = (from u in _context.User
                                 where u.UserName == Username
                                 select new UserModel
                                 {
                                     UserName = u.UserName,
                                     PostCode = u.POSCode,
                                     //PostTypeCode = p.POSTypeCode,
                                     FullName = u.FullName,
                                     CustomerCode = u.CustomerCode,
                                     //ProvinceCode = p.ProvinceCode,
                                     //ProvinceListCode = pr.ProvinceListCode,
                                     UnitCode = u.UnitCode,
                                     AreaPos = u.AreaPos
                                 }).AsQueryable();


                    userData = query.FirstOrDefault();

                    // DUCNV: load menu fo user
                    var queryMenu = (from u in _sso.AspNetUsers
                                     join ur in _sso.AspNetUserRoles
                                     on u.Id equals ur.UserId
                                     join r in _sso.AspNetRoles
                                     on ur.RoleId equals r.Id
                                     join c in _sso.AspNetRoleClaims
                                     on r.Id equals c.RoleId
                                     join m in _sso.Menu
                                     on c.MenuId equals m.Code
                                     where u.UserName == Username
                                     select m).AsQueryable().Distinct().ToList();

                    userData.LinkMenu = queryMenu;

                    // DUCNV: load endPoint
                    var queryEndpoint = _sso.View_EndPoint.AsQueryable().Where(x => x.UserName == Username)
                        .Select(x => new UserModel.EndPointModel { Method = x.Method, Url = x.Url })
                        .Distinct()
                        .ToList();
                    userData.EndPoint = queryEndpoint;

                    // DUCNV: load role
                    var listRole = _sso.AspNetUserRoles.Where(x => x.User.UserName == userData.UserName)
                                       .Select(x => new RoleModel { Id = x.Role.Id, Name = x.Role.Name, NormalizedName = x.Role.NormalizedName })
                                       .ToList();
                    userData.Roles = listRole;

                    // Set cache options.
                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                        // Keep in cache for this time, reset time if accessed.
                        .SetSlidingExpiration(TimeSpan.FromHours(6));

                    // Save data in cache.
                    _cache.Set(keyCache, userData, cacheEntryOptions);
                }
            }

            return userData;
        }
    }
}
