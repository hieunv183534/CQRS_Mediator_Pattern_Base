using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace BCCP.DomainGlobal.Application.FileCloud.Commands
{
    public class SynFileCommand : IRequest<bool>
    {
        public object DataOld { get; set; }

        public object DataNew { get; set; }
    }
}
