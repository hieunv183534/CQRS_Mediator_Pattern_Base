using AutoMapper;
using BCCP.DomainGlobal._Base.Mappings;
using MediatR;
using System;
using System.Linq;

namespace BCCP.DomainGlobal.Application.FileCloud.Commands
{
    public class DeleteCommand : IRequest<bool>
    {
        public long[] Id { get; set; }

        public string[] Url { get; set; }
    }
}
