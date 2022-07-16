using AutoMapper;
using AutoMapper.QueryableExtensions;
using NOM.Dao.Entities;
using NOM.DomainGlobal._Base.Extentions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManagerDataSet.Queries
{
    public class GetCountQueryHandler : IRequestHandler<GetCountQuery, long>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCountQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<long> Handle(GetCountQuery request, CancellationToken cancellationToken)
        {
            var query = _context.ReportManagerDataSet.AsQueryable();

            // where custom in here

            // where loopback default
            if (request.Where.HasValue())
            {
                query = query.WhereLoopback(request.WhereLoopBack);
            }

            return await query.CountAsync();
        }
    }
}
