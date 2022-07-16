using AutoMapper;
using NOM.Dao.Entities;
using NOM.Domain._Base.Abstractions.Messaging;
using NOM.Domain._Base.Mappings;

namespace NOM.Domain.Application.OriginalProperties.Commands;
/// <summary>
/// haitc 02/06/2022
/// </summary>
public record CreateOriginalPropertiesCmd() : OriginalPropertiesCmdDto,
                                                  ICommand<CreateOriginalPropertiesResult>,
                                                  IMapTo<OriginalProperty>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateOriginalPropertiesCmd, OriginalProperty>();
    }
};
public record CreateOriginalPropertiesResult(string PropertyId, string PropertyCode, string PropertyName);
public record UpdateOriginalPropertiesCmd : OriginalPropertiesCmdDto,
                                              ICommand<UpdateOriginalPropertiesResult>,
                                              IMapTo<OriginalProperty>
{
    public UpdateOriginalPropertiesCmd()
    {
    }
    public UpdateOriginalPropertiesCmd(string PropertyId)
    {
        this.PropertyId = PropertyId;
    }
    public string PropertyId { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateOriginalPropertiesCmd, OriginalProperty>();
    }
};
public record UpdateOriginalPropertiesResult(string PropertyId, string PropertyCode, string PropertyName);
public record DeleteOriginalPropertiesCmd(string PropertyId) : ICommand<DeleteOriginalPropertiesResult>;
public record DeleteOriginalPropertiesResult(string PropertyId, string PropertyCode, string PropertyName);