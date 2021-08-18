using Business.Abstract;
using Business.Handlers.Interpolations.Commands;
using Business.Handlers.Interpolations.Queries;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntegrationsController : BaseApiController
    {
        [Consumes("application/json")]
        [Produces("application/json","text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type= typeof(string))]
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateIntegrationCommand createIntegrations)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(createIntegrations));
        }

        [Consumes("application/json")]
        [Produces("application/json","text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpDelete("delete")] 
        public async Task<IActionResult> Delete([FromBody] DeleteIntegrationCommand deleteIntegrations)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteIntegrations));
        }

        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateIntegrationCommand updateIntegrations)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(updateIntegrations));
        }

        [Produces("application/json","text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Integration))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetByID(int id)
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetIntegrationByIdQuery { ID = id }));
        }

        [Produces("application/json","text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Integration>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetIntegrationsQuery()));
        }

        // WE MOVE TO UI SIDE. THIS CONTROLLER FOR SEND DATA TO DEEP LEARNING MODEL FOR EVALUATING IMAGE.  
        //[HttpPost("send")]
        //public ActionResult Send(IFormFile file)
        //{
        //    var result = _interpolationService.Send(file);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}
    }
}
