using AutoMapper;
using NOM.Dao.Entities;
using NOM.Domain._Base.Abstractions.Messaging;
using NOM.Domain._Base.Mappings;
using NOM.Domain.Application.Properties.Commands;
using System.Collections.Generic;

namespace NOM.Domain.Application.Categories.Commands;
/// <summary>
/// haitc 02/06/2022
/// </summary>
public record CreateCategoriesCmd : CategoriesCmdDto,
                                    ICommand<CreateCategoriesResult>,
                                    IMapTo<Category>
{
    public CreateCategoriesCmd()
    {
    }
    public CreateCategoriesCmd(List<CreatePropertiesCmd> CreatePropertiesCmds)
    {
        this.CreatePropertiesCmds = CreatePropertiesCmds;
    }
    public List<CreatePropertiesCmd> CreatePropertiesCmds { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateCategoriesCmd, Category>();
    }
};
public record CreateCategoriesResult(string CategoryId, string CategoryName);
public record UpdateCategoriesCmd : CategoriesCmdDto,
                                    ICommand<UpdateCategoriesResult>,
                                    IMapTo<Category>
{
    public UpdateCategoriesCmd()
    {
    }
    public UpdateCategoriesCmd(string CategoryId, List<UpdatePropertiesCmd> UpdatePropertiesCmds)
    {
        this.CategoryCodeId = CategoryId;
        this.UpdatePropertiesCmds = UpdatePropertiesCmds;
    }
    public string CategoryId { get; set; }
    public List<UpdatePropertiesCmd> UpdatePropertiesCmds { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateCategoriesCmd, Category>();
    }
};
public record UpdateCategoriesResult(string CategoryId, string CategoryName);
public record DeleteCategoriesCmd(string CategoryId) : ICommand<DeleteCategoriesResult>;
public record DeleteCategoriesResult(string CategoryId, string CategoryName);