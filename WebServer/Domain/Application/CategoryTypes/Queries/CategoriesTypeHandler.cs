using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using NOM._Base.Models;
using NOM.Dao.Entities;
using NOM.Domain._Base.Abstractions.Messaging;
using NOM.Domain._Base.Exceptions;
using NOM.Domain._Base.Extentions;
using NOM.Domain._Base.Handlers;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NOM.Domain.Application.CategoryTypes.Queries;

/// <summary>
/// haitc 02/06/2022
/// </summary>
public class CategoryTypeHandler : BaseHandler,
        IQueryHandler<FindAllCategoriesTypeQuery, PagingResultModel<FindAllCategoriesTypeResult>>,
        IRequestHandler<FindByIdCategoriesTypeQuery, CategoriesTypeQueryDto>
{
    public CategoryTypeHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    /// <summary>
    /// Get All
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<PagingResultModel<FindAllCategoriesTypeResult>> Handle(FindAllCategoriesTypeQuery request, CancellationToken cancellationToken)
    {
        var query = _context.CategoriesTypes.AsQueryable();
        if (request.ValueSearch != null && request.ValueSearch.Length > 0)
        {
            var listOr = new List<object>();
            foreach (var item in request.ValueSearch)
            {
                listOr.Add(new
                {
                    and = new object[]
                    {
                            new { item.CategoryTypeName },
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
            query = query.Where(c => c.CategoryTypeName.ToLower().Contains(textSearch));
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
        return await query.ProjectTo<FindAllCategoriesTypeResult>(_mapper.ConfigurationProvider)
            .ToPagedListAsync(request, cancellationToken);
    }

    /// <summary>
    /// Get By Id
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<CategoriesTypeQueryDto> Handle(FindByIdCategoriesTypeQuery request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.CategoryTypeId))
        {
            throw new BadRequestException("Id kiểu danh mục không được để trống");
        }
        var result = await _context.CategoriesTypes
            .Where(x => x.CategoryTypeId == request.CategoryTypeId)
                          .Select(x => _mapper.Map<CategoriesTypeQueryDto>(x))
                          .FirstOrDefaultAsync();
        return result ?? null;
    }
}