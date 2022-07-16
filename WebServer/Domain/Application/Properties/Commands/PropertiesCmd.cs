using AutoMapper;
using NOM.Dao.Entities;
using NOM.Domain._Base.Abstractions.Messaging;
using NOM.Domain._Base.Mappings;

namespace NOM.Domain.Application.Properties.Commands;

/// <summary>
/// haitc 02/06/2022
/// </summary>
public record CreatePropertiesCmd() : PropertiesCmdDto,
                                         ICommand<CreatePropertiesResult>,
                                         IMapTo<Property>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreatePropertiesCmd, Property>();
    }
};
public record CreatePropertiesResult(string PropertyId, string PropertyCode, string PropertyName);
public record UpdatePropertiesCmd : PropertiesCmdDto,
                                                       ICommand<UpdatePropertiesResult>,
                                                       IMapTo<Property>
{
    public UpdatePropertiesCmd()
    {
    }
    public UpdatePropertiesCmd(string PropertyId)
    {
        this.PropertyId = PropertyId;
    }
    public string PropertyId { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdatePropertiesCmd, Property>();
    }
};
public record UpdatePropertiesResult(string PropertyId, string PropertyCode, string PropertyName);
public record DeletePropertiesCmd() : ICommand<DeletePropertiesResult>;
public record DeletePropertiesResult();