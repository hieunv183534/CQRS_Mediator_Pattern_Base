using AutoMapper;
using NOM._Base.Models;
using NOM.Dao.Entities;
using NOM.Domain._Base.Abstractions.Messaging;
using NOM.Domain._Base.Mappings;
using NOM.Domain.Application.Properties.Queries;
using System.Collections.Generic;

namespace NOM.Domain.Application.Categories.Queries;
/// <summary>
/// haitc 02/06/2022
/// </summary>
public record FindAllCategoriesQuery(CategoriesQueryKey[] ValueSearch, string TextSearch) : BasePagingModel, IQuery<PagingResultModel<FindAllCategoriesResult>>;
public record FindAllCategoriesResult : CategoriesQueryDto, IMapFrom<Category>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Category, FindAllCategoriesResult>();
    }
}
public record CategoriesQueryKey(string? CategoryName, string? TableName, string? CategoryTypeId);
public record FindByIdCategoriesQuery(string CategoryId) : IQuery<FindByIdCategoriesResult>;
public record FindByIdCategoriesResult(CategoriesQueryDto CategoriesQueryDto, List<PropertiesQueryDto> PropertiesQueryDtos);