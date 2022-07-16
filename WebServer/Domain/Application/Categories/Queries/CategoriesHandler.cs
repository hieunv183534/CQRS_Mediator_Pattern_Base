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
using NOM.Domain.Application.Properties.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NOM.Domain.Application.Categories.Queries;
/// <summary>
/// haitc 02/06/2022
/// </summary>

public class CategoriesHandler : BaseHandler,
                                 IQueryHandler<FindAllCategoriesQuery, PagingResultModel<FindAllCategoriesResult>>,
                                 IQueryHandler<FindByIdCategoriesQuery, FindByIdCategoriesResult>
{
    public CategoriesHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    /// <summary>
    /// Get All
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<PagingResultModel<FindAllCategoriesResult>> Handle(FindAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Categories.AsQueryable();

        if (request.ValueSearch != null && request.ValueSearch.Length > 0)
        {
            var listOr = new List<object>();
            foreach (var item in request.ValueSearch)
            {
                listOr.Add(new
                {
                    and = new object[]
                    {
                            new { item.CategoryName },
                            new { item.TableName },
                            new { item.CategoryTypeId },
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
            query = query.Where(c => c.CategoryName.ToLower().Contains(textSearch)
                                     || c.TableName.ToLower().Contains(textSearch)
                                     || c.CategoryTypeId == request.TextSearch);
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

        return await query.ProjectTo<FindAllCategoriesResult>(_mapper.ConfigurationProvider)
            .ToPagedListAsync(request, cancellationToken);
    }

    /// <summary>
    /// Get By Id
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<FindByIdCategoriesResult> Handle(FindByIdCategoriesQuery request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.CategoryId))
        {
            throw new BadRequestException("Id danh mục không được để trống");
        }
        var categoriesQueryDto = await _context.Categories
                                    .Where(x => x.CategoryId == request.CategoryId)
                                    .Select(x => _mapper.Map<CategoriesQueryDto>(x))
                                    .FirstOrDefaultAsync();
        if (categoriesQueryDto is not null)
        {
            var propertiesQueryDtos = await _context.Properties
                                            .Where(x => x.CategoryId == request.CategoryId
                                                        && x.Status > 0)
                                            .Select(x => _mapper.Map<PropertiesQueryDto>(x))
                                            .ToListAsync();
            return new FindByIdCategoriesResult(categoriesQueryDto, propertiesQueryDtos);
        }
        return null;
    }
}