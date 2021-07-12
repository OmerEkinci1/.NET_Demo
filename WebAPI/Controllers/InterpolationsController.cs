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
        private IInterpolationService _pictureService;

        public InterpolationsController(IInterpolationService pictureService)
        {
            _pictureService = pictureService;
        }

        [HttpPost("add")]
        public ActionResult Add(Interpolation interpolation, IFormFile file)
        {
            var result = _pictureService.Add(interpolation,file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")] // HttpPost olabilir, duruma göre denenicek.
        public ActionResult Delete(Interpolation interpolation)
        {
            var result = _pictureService.Delete(interpolation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")] // HttpPost olabilir, duruma göre denenicek.
        public ActionResult Update(Interpolation interpolation, IFormFile file)
        {
            var result = _pictureService.Update(interpolation, file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("get")]
        public ActionResult GetByID(int id)
        {
            var result = _pictureService.GetByID(id);
            if (result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public ActionResult GetAll()
        {
            var result = _pictureService.GetAll();
            if (result.Data != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
