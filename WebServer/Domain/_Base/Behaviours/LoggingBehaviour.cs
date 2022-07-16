//using NOM.Domain.Interfaces;
//using MediatR.Pipeline;
//using Microsoft.Extensions.Logging;
//using System.Threading;
//using System.Threading.Tasks;

//namespace NOM.Domain._Base.Behaviours
//{
//    public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest>
//    {
//        private readonly ILogger _logger;
//        private readonly IUserService _currentUserService;

//        public LoggingBehaviour(ILogger<TRequest> logger, IUserService currentUserService)
//        {
//            _logger = logger;
//            _currentUserService = currentUserService;
//        }

//        public async Task Process(TRequest request, CancellationToken cancellationToken)
//        {
//            // bắt đầu chạy request
//            //var requestName = typeof(TRequest).Name;
//            //string userName = _currentUserService.GetUserInfo()?.UserName ?? string.Empty;

//            //_logger.LogInformation("BCCP Request: {Name} {@UserName} {@Request}",
//            //    requestName, userName, request);
//        }
//    }
//}