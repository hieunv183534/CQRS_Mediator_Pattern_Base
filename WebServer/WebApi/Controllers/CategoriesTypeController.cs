using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NOM.Domain.Application.CategoryTypes.Commands;
using NOM.Domain.Application.CategoryTypes.Queries;

using NOM.WebApi.Base;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NOM.Domain.Application.OriginalProperties.Commands;

/// <summary>
/// haitc 02/06/2022
/// </summary>
public class CategoriesTypeController : ApiController
{
    [AllowAnonymous]
    [HttpPost]
    [ProducesResponseType(typeof(List<CategoriesTypeQueryDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult> GetAll([FromBody] FindAllCategoriesTypeQuery request)
    {
        var result = await Mediator.Send(request);
        return Ok(result);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(CategoriesTypeQueryDto), StatusCodes.Status200OK)]
    public async Task<ActionResult> GetById([FromRoute] string id)
    {
        var result = await Mediator.Send(new FindByIdCategoriesTypeQuery(id));
        return Ok(result);
    }

    [AllowAnonymous]
    [HttpPost]
    [ProducesResponseType(typeof(CreateCategoriesTypeResult), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult> Post([FromBody] CreateCategoriesTypeCmd request, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.CategoryTypeId }, result);
    }

    [AllowAnonymous]
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult> Put([FromBody] UpdateCategoriesTypeCmd request, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(request, cancellationToken);
        return new JsonResult(result);
    }

    [AllowAnonymous]
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete([FromBody] DeleteCategoriesTypeCmd request, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(request, cancellationToken);
        return new JsonResult(result);
    }
}