using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NOM.Domain.Application.OriginalProperties.Commands;
using NOM.Domain.Application.OriginalProperties.Queries;
using NOM.WebApi.Base;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NOM.WebApi.Controllers
{
    public class OriginalPropertiesController : ApiController
    {
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(List<OriginalPropertiesQueryDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAll([FromBody] FindAllOriginalPropertiesQuery request)
        {
            var result = await Mediator.Send(request);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OriginalPropertiesQueryDto), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetById([FromRoute] string id)
        {
            var result = await Mediator.Send(new FindByIdOriginalPropertiesQuery(id));
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(CreateOriginalPropertiesResult), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult> Post([FromBody] CreateOriginalPropertiesCmd request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = result.PropertyId }, result);
        }

        [AllowAnonymous]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult> Put([FromBody] UpdateOriginalPropertiesCmd request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return new JsonResult(result);
        }

        [AllowAnonymous]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete([FromBody] DeleteOriginalPropertiesCmd request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return new JsonResult(result);
        }
    }
}