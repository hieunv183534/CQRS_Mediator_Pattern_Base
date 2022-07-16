using AutoMapper;
using NOM.Dao.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Threading;
using System.Threading.Tasks;
using RT.Comb;
using NOM.DomainGlobal.Interfaces;
using NOM.DomainGlobal._Base.Extentions;
using NOM.DomainGlobal._Base.Exceptions;
using System;

namespace NOM.GPSGATEWAY.Domain.Application.SynData.Commands
{
    public class UpdateCommandHandler : IRequestHandler<UpdateCommand, long>
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private IUserService _user;

        public UpdateCommandHandler(ApplicationDbContext context, IMapper mapper, IUserService user)
        {
            _mapper = mapper;
            _context = context;
            _user = user;
        }

        public async Task<long> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {

            //logic tích hợp khi có thiết bị
            return 1;
        }
    }
}

