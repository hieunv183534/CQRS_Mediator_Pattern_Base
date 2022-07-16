using NOM.Domain._Base.Abstractions.Messaging;

using System.Collections.Generic;

namespace NOM.Domain.Application.Properties.Queries;
/// <summary>
/// haitc 02/06/2022
/// </summary>
public record FindAllPropertiesQuery() : IQuery<IEnumerable<PropertiesQueryDto>>;
public record FindByIdPropertiesQuery(string PropertyId) : IQuery<PropertiesQueryDto>;