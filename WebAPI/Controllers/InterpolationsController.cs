using Business.Abstract;
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
    public class InterpolationsController : ControllerBase
    {
        private IInterpolationService _interpolationService;

        public InterpolationsController(IInterpolationService interpolationService)
        {
            _interpolationService = interpolationService;
        }

        [HttpPost("add")]
        public ActionResult Add(Interpolation interpolation, IFormFile file)
        {
            var result = _interpolationService.Add(interpolation,file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")] 
        public ActionResult Delete(Interpolation interpolation)
        {
            var result = _interpolationService.Delete(interpolation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")] 
        public ActionResult Update(Interpolation interpolation, IFormFile file)
        {
            var result = _interpolationService.Update(interpolation, file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("send")]
        public ActionResult Send(IFormFile file)
        {
            var result = _interpolationService.Send(file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("get")]
        public ActionResult GetByID(int id)
        {
            var result = _interpolationService.GetByID(id);
            if (result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public ActionResult GetAll()
        {
            var result = _interpolationService.GetAll();
            if (result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
