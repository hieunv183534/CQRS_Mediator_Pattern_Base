using AutoMapper;
using BCCP.DomainGlobal._Base.Mappings;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace BCCP.DomainGlobal.Application.FileCloud.Commands
{
    public class CreateCommand : IRequest<List<string>>
    {
        public string RootDirectory { get; set; }
        public List<IFormFile> FileByte { get; set; }
    }
}
