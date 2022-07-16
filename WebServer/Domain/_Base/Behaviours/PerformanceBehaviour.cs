//using MediatR;
//using Microsoft.Extensions.Logging;
//using NOM.Domain.Interfaces;
//using System.Diagnostics;
//using System.Threading;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using System;
//using Microsoft.AspNetCore.Http.Features;

//namespace NOM.Domain._Base.Behaviours
//{
//    public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
//    {
//        private readonly Stopwatch _timer;
//        private readonly ILogger<TRequest> _logger;
//        private readonly IHttpContextAccessor _httpContextAccessor;

//        public PerformanceBehaviour(
//            ILogger<TRequest> logger,
//            IHttpContextAccessor httpContextAccessor)
//        {
//            _timer = new Stopwatch();

//            _logger = logger;
//            _httpContextAccessor = httpContextAccessor;
//        }

//        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
//        {
//            _timer.Start();

//            var response = await next();

//            //_timer.Stop();

//            var elapsedMilliseconds = _timer.ElapsedMilliseconds;

//            if (elapsedMilliseconds > 500)
//            {
//                var requestName = typeof(TRequest).Name;
//                var userName = _currentUserService.GetUserInfo()?.UserName ?? string.Empty;

//                _logger.LogWarning("BCCP Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserName} {@Request}",
//                    requestName, elapsedMilliseconds, userName, request);
//            }

//            if (_currentUserService.GetUserInfo() != null &&
//                _httpContextAccessor.HttpContext != null &&
//                _httpContextAccessor.HttpContext.Request.Method == "POST" &&
//                (request.GetType().Name.StartsWith("Create") ||
//                 request.GetType().Name.StartsWith("Update") ||
//                 request.GetType().Name.StartsWith("Delete")))
//            {
//                var feature = _httpContextAccessor.HttpContext.Features.Get<IHttpConnectionFeature>();
//                var LocalIPAddr = feature?.LocalIpAddress?.ToString();
//                var Id = System.Convert.ToInt64(RT.Comb.Provider.Sql.CreateDoubleID(0));
//                await _db.ActionLog.AddAsync(new ActionLog
//                {
//                    Id = Id,
//                    Message = request.GetType().Name,
//                    ActionLink = _httpContextAccessor.HttpContext.Request.Path.Value,
//                    Application = "KT1",
//                    CreateDate = DateTime.Now,
//                    RequestIp = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress?.ToString(),
//                    ServerIp = LocalIPAddr,
//                    UserJson = Newtonsoft.Json.JsonConvert.SerializeObject(new
//                    {
//                        UserName = _currentUserService.GetUserInfo().UserName,
//                        FullName = _currentUserService.GetUserInfo().FullName
//                    }),
//                    DataJson = Newtonsoft.Json.JsonConvert.SerializeObject(request),
//                    ReturnJson = Newtonsoft.Json.JsonConvert.SerializeObject(response)
//                });
//                await _db.SaveChangesAsync();
//            }

//            return response;
//        }
//    }
//}