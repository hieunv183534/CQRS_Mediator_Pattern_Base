using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace BCCP.DomainGlobal.Application.FileCloud.Commands
{
    public class UploadCommand : IRequest<List<UploadCommandResult>>
    {
        public List<IFormFile> File { get; set; }

        public string RootDirectory { get; set; }
    }
}
