using AutoMapper;
using NOM.RIFDGATEWAY.Domain._Base.Mappings;
using MediatR;
using System;
using System.Linq;

namespace NOM.RIFDGATEWAY.Domain.Application.SynData.Commands
{
    public class UpdateCommand : IRequest<long>
    {
        public string DeviceId { get; set; }
        public string Code { get; set; }

        public float Lat { get; set; }
        public float Long { get; set; }
        public string ClientSecrets { get; set; }
       
    }
}
