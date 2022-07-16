using AutoMapper;
using AutoMapper.QueryableExtensions;
using NOM.Dao.Entities;
using NOM.DomainGlobal._Base.Extentions;
using NOM.DomainGlobal._Base.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NOM.REPORT.Domain.Application.DanhMuc.ReportManager.Queries
{
    public class ComboboxQueryHandler : IRequestHandler<ComboboxQuery, PagingResultModel<ComboboxQueryResult>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ComboboxQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PagingResultModel<ComboboxQueryResult>> Handle(ComboboxQuery request, CancellationToken cancellationToken)
        {
            var query = _context.ReportManager.AsQueryable();

            // where custom in here

            // where constain
            if (request.ValueSearch != null && request.ValueSearch.Length > 0)
            {
                query = query.Where(x => request.ValueSearch.Contains(x.Id));
            }

            //if (request.TextSearch.HasValue())
            //{
                //query = query.Where(x => x.ColText.StartsWith(request.TextSearch));
            //}

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

            return await query.ProjectTo<ComboboxQueryResult>(_mapper.ConfigurationProvider)
                .ToPagedListAsync(request, cancellationToken);
        }
    }
}
