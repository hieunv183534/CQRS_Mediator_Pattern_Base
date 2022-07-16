using AutoMapper;
using NOM._Base.Models;
using NOM.Dao.Entities;
using NOM.Domain._Base.Abstractions.Messaging;
using NOM.Domain._Base.Mappings;

namespace NOM.Domain.Application.OriginalProperties.Queries;
/// <summary>
/// haitc 02/06/2022
/// </summary>
public record FindAllOriginalPropertiesQuery(OriginalPropertiesQueryKey[] ValueSearch, string TextSearch) : BasePagingModel, IQuery<PagingResultModel<FindAllOriginalPropertiesResult>>;
public record FindAllOriginalPropertiesResult : OriginalPropertiesQueryDto, IMapFrom<OriginalProperty>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<OriginalProperty, FindAllOriginalPropertiesResult>();
    }
}
public record OriginalPropertiesQueryKey(string? PropertyName, string? PropertyCode);
public record FindByIdOriginalPropertiesQuery(string PropertyId) : IQuery<OriginalPropertiesQueryDto>;