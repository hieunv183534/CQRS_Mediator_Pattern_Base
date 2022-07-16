using AutoMapper;
using AutoMapper.QueryableExtensions;
using NOM.Dao.Entities;
using NOM.DomainGlobal._Base.Extentions;
using NOM.DomainGlobal._Base.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManagerParam.Queries
{
    public class GetPagingQueryHandler : IRequestHandler<GetPagingQuery, PagingResultModel<GetPagingQueryResult>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPagingQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PagingResultModel<GetPagingQueryResult>> Handle(GetPagingQuery request, CancellationToken cancellationToken)
        {
            var query = _context.ReportManagerParam.AsQueryable();

            // where custom in here

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

            return await query.ProjectTo<GetPagingQueryResult>(_mapper.ConfigurationProvider)
                .ToPagedListAsync(request, cancellationToken);
        }
    }
}
