using AutoMapper;
using NOM._Base.Models;
using NOM.Dao.Entities;
using NOM.Domain._Base.Abstractions.Messaging;
using NOM.Domain._Base.Mappings;

namespace NOM.Domain.Application.CategoryTypes.Queries;
/// <summary>
/// haitc 02/06/2022
/// </summary>
public record FindAllCategoriesTypeQuery(CategoryTypeQueryKey[] ValueSearch, string TextSearch) : BasePagingModel, IQuery<PagingResultModel<FindAllCategoriesTypeResult>>;

public record FindAllCategoriesTypeResult : CategoriesTypeQueryDto, IMapFrom<CategoriesType>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CategoriesType, FindAllCategoriesTypeResult>();
    }
}
public record CategoryTypeQueryKey(string? CategoryTypeName);
public record FindByIdCategoriesTypeQuery(string CategoryTypeId) : IQuery<CategoriesTypeQueryDto>;