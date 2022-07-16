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

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManager.Queries
{
    public class FindOneQueryHandler : IRequestHandler<FindOneQuery, FindOneQueryResult>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FindOneQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<FindOneQueryResult> Handle(FindOneQuery request, CancellationToken cancellationToken)
        {
            var query = _context.ReportManager.AsQueryable();

            // where loopback default
            if (request.Where.HasValue())
            {
                query = query.WhereLoopback(request.WhereLoopBack);
            }

            // order by paging by lookback default
            if (request.Order.HasValue())
            {
                query = query.OrderByLoopback(request.OrderLoopBack);
            }

            return await query.ProjectTo<FindOneQueryResult>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }
    }
}


