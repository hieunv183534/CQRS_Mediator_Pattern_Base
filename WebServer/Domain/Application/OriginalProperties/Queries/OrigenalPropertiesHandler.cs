using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using NOM._Base.Models;
using NOM.Dao.Entities;
using NOM.Domain._Base.Abstractions.Messaging;
using NOM.Domain._Base.Extentions;
using NOM.Domain._Base.Handlers;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NOM.Domain.Application.OriginalProperties.Queries;

/// <summary>
/// haitc 02/06/2022
/// </summary>
public class OrigenalPropertiesHandler : BaseHandler,
                                             IQueryHandler<FindAllOriginalPropertiesQuery, PagingResultModel<FindAllOriginalPropertiesResult>>,
                                             IQueryHandler<FindByIdOriginalPropertiesQuery, OriginalPropertiesQueryDto>
{
    public OrigenalPropertiesHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    /// <summary>
    /// Get All
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<PagingResultModel<FindAllOriginalPropertiesResult>> Handle(FindAllOriginalPropertiesQuery request, CancellationToken cancellationToken)
    {
        var query = _context.OriginalProperties.AsQueryable();

        if (request.ValueSearch != null && request.ValueSearch.Length > 0)
        {
            var listOr = new List<object>();
            foreach (var item in request.ValueSearch)
            {
                listOr.Add(new
                {
                    and = new object[]
                    {
                            new { item.PropertyName },
                            new { item.PropertyCode }
                    }
                });
            }
            var whereOrLoopBack = new
            {
                or = listOr
            };
            query = query.WhereLoopback(JObject.FromObject(whereOrLoopBack));
        }

        if (request.TextSearch.HasValue())
        {
            string textSearch = request.TextSearch.ToLower();
            query = query.Where(c => c.PropertyName.ToLower().Contains(textSearch)
                                     || c.PropertyCode.ToLower().Contains(textSearch));
        }

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

        return await query.ProjectTo<FindAllOriginalPropertiesResult>(_mapper.ConfigurationProvider)
            .ToPagedListAsync(request, cancellationToken);
    }

    /// <summary>
    /// Get By Id
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<OriginalPropertiesQueryDto> Handle(FindByIdOriginalPropertiesQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.OriginalProperties
            .Where(x => x.PropertyId == request.PropertyId)
                          .Select(x => _mapper.Map<OriginalPropertiesQueryDto>(x))
                          .FirstOrDefaultAsync();
        return result ?? null;
    }
}