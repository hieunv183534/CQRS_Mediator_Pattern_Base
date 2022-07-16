//using NOM.Domain.Interfaces;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc.Filters;
//using Microsoft.AspNetCore.Routing;
//using Microsoft.Extensions.Configuration;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Net;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;

//namespace NOM.WebApi.Filters
//{
//    public class CustomPoliceHandler : AuthorizationHandler<CustomPolice>
//    {
//        private readonly IHttpContextAccessor _httpContextAccessor;
//        private readonly IUserService _user;
//        private readonly IConfiguration _configuration;

//        public CustomPoliceHandler(IHttpContextAccessor httpContextAccessor, IUserService user, IConfiguration configuration)
//        {
//            _httpContextAccessor = httpContextAccessor;
//            _user = user;
//            _configuration = configuration;
//        }

//        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomPolice requirement)
//        {
//            //var endPoint = ((RouteEndpoint)context.Resource);

//            var method = _httpContextAccessor.HttpContext.Request.Method;
//            var url = _httpContextAccessor.HttpContext.Request.Path.Value;

//            switch (requirement.Name)
//            {
//                case "link":
//                    #region link
//                    var listEndPoint = _user.GetUserInfo().EndPoint;

//                    if (_configuration.GetValue<bool>("LinkPolice"))
//                    {
//                        if (listEndPoint.Any(x => x.Method == method && url.StartsWith(x.Url)))
//                        {
//                            context.Succeed(requirement);
//                        }
//                        else
//                        {
//                            _httpContextAccessor.HttpContext.Response.Body = new MemoryStream(Encoding.UTF8.GetBytes("Bạn không có quyền thao tác chức năng này"));
//                            context.Fail();
//                        }
//                    }
//                    else
//                    {
//                        context.Succeed(requirement);
//                    }
//                    #endregion
//                    break;
//                case "local":
//                    #region local
//                    if (_configuration.GetValue<bool>("LocalPolice"))
//                    {
//                        var ip = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress;
//                        if (!IPAddress.IsLoopback(ip))
//                        {
//                            _httpContextAccessor.HttpContext.Response.Body = new MemoryStream(Encoding.UTF8.GetBytes("Chức năng này chỉ dàng cho lập trình viên"));
//                            context.Fail();
//                        }
//                        else
//                        {
//                            context.Succeed(requirement);
//                        }
//                    }
//                    else
//                    {
//                        context.Succeed(requirement);
//                    }
//                    #endregion
//                    break;
//                default:
//                    context.Succeed(requirement);
//                    break;
//            }

//            if (_configuration.GetValue<bool>("ValidShiftHandover"))
//            {
//                var user = _user.GetUserInfo();
//                var posCode = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "POSCode")?.Value;
//                var shiphandover = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "ShiftHandover")?.Value;

//                if (user?.ShiftHandover?.ShiftHandoverID.ToString() != shiphandover)
//                {
//                    _httpContextAccessor.HttpContext.Response.Body = new MemoryStream(Encoding.UTF8.GetBytes("Ca làm việc đã bị thay đổi (chốt). Ấn Đồng ý để đăng nhập lại"));
//                    context.Fail();
//                }

//                if (user?.PostCode != posCode)
//                {
//                    _httpContextAccessor.HttpContext.Response.Body = new MemoryStream(Encoding.UTF8.GetBytes("Tài khoản đã thay đổi bưu cục. Vui lòng đăng nhập lại"));
//                    context.Fail();
//                }
//            }

//            return Task.CompletedTask;
//        }
//    }
//}