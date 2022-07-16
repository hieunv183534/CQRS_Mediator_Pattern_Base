//using NOM.Dao.Kt1Log;
//using NOM.Domain.Interfaces;
//using MediatR;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Http.Features;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Threading;
//using System.Threading.Tasks;

//namespace NOM.Domain._Base.Behaviours
//{
//    public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
//    {
//        private readonly ILogger<TRequest> _logger;
//        private readonly IUserService _currentUserService;
//        private readonly IHttpContextAccessor _httpContextAccessor;
//        private readonly LogDbContext _db;

//        public UnhandledExceptionBehaviour(ILogger<TRequest> logger,
//            IUserService currentUserService,
//            IHttpContextAccessor httpContextAccessor,
//            LogDbContext db)
//        {
//            _logger = logger;

//            _currentUserService = currentUserService;
//            _httpContextAccessor = httpContextAccessor;
//            _db = db;
//        }

//        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
//        {
//            try
//            {
//                return await next();
//            }
//            catch (Exception ex)
//            {
//                //if (ex.GetType().Name != "ValidationException")
//                //{
//                   var requestName = typeof(TRequest).Name;

//                 _logger.LogError(ex, "BCCP Request: Unhandled Exception for Request {Name} {@Request}", requestName, request);

//                //    var feature = _httpContextAccessor.HttpContext.Features.Get<IHttpConnectionFeature>();
//                //    var LocalIPAddr = feature?.LocalIpAddress?.ToString();
//                //    var Id = System.Convert.ToInt64(RT.Comb.Provider.Sql.CreateDoubleID(0));
//                //    await _db.ErrorLog.AddAsync(new ErrorLog
//                //    {
//                //        Id = Id,
//                //        ErrorCode = "500",
//                //        ActionLink = _httpContextAccessor.HttpContext.Request.Path.Value,
//                //        Application = "KT1",
//                //        CreateDate = DateTime.Now,
//                //        RequestIp = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString(),
//                //        ServerIp = LocalIPAddr,
//                //        UserJson = Newtonsoft.Json.JsonConvert.SerializeObject(new
//                //        {
//                //            UserName = _currentUserService.GetUserInfo().UserName,
//                //            FullName = _currentUserService.GetUserInfo().FullName
//                //        }),
//                //        DataJson = Newtonsoft.Json.JsonConvert.SerializeObject(request),
//                //        Message = ex.Message,
//                //        Trace = ex.StackTrace
//                //    });
//                //    await _db.SaveChangesAsync();
//                //}
//                throw ex;
//            }
//        }
//    }
//}