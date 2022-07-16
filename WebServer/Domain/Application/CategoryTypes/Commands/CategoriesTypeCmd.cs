using AutoMapper;
using NOM.Dao.Entities;
using NOM.Domain._Base.Abstractions.Messaging;
using NOM.Domain._Base.Mappings;

namespace NOM.Domain.Application.CategoryTypes.Commands;
/// <summary>
/// haitc 02/06/2022
/// </summary>
public record CreateCategoriesTypeCmd() : CategoriesTypeCmdDto, ICommand<CreateCategoriesTypeResult>, IMapTo<CategoriesType>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateCategoriesTypeCmd, CategoriesType>();
    }
};
public record CreateCategoriesTypeResult(string CategoryTypeId, string CategoryTypeName);
public record UpdateCategoriesTypeCmd : CategoriesTypeCmdDto, ICommand<UpdateCategoriesTypeResult>, IMapTo<CategoriesType>
{
    public UpdateCategoriesTypeCmd()
    {
    }
    public UpdateCategoriesTypeCmd(string CategoryTypeId)
    {
        this.CategoryTypeId = CategoryTypeId;
    }
    public string CategoryTypeId { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateCategoriesTypeCmd, CategoriesType>();
    }
}
public record UpdateCategoriesTypeResult(string CategoryTypeId, string CategoryTypeName);
public record DeleteCategoriesTypeCmd(string CategoryTypeId) : ICommand<DeleteCategoriesTypeResult>;
public record DeleteCategoriesTypeResult(string CategoryTypeId, string CategoryTypeName);