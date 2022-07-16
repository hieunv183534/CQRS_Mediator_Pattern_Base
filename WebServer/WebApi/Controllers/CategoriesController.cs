using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NOM.Domain.Application.Categories.Commands;
using NOM.Domain.Application.Categories.Queries;

using NOM.WebApi.Base;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NOM.WebApi.Controllers
{
    public class CategoriesController : ApiController
    {
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(List<CategoriesQueryDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAll([FromBody] FindAllCategoriesQuery request)
        {
            var result = await Mediator.Send(request);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CategoriesQueryDto), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetById([FromRoute] string id)
        {
            var result = await Mediator.Send(new FindByIdCategoriesQuery(id));
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(CreateCategoriesResult), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult> Post([FromBody] CreateCategoriesCmd request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = result.CategoryId }, result);
        }

        [AllowAnonymous]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult> Put([FromBody] UpdateCategoriesCmd request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return new JsonResult(result);
        }

        [AllowAnonymous]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete([FromBody] DeleteCategoriesCmd request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return new JsonResult(result);
        }
    }
}