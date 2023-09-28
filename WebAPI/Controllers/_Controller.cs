using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFranework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class _Controller : ControllerBase
    {
        I_Service _Service;
        public _Controller(I_Service Service)
        {
                _Service = Service;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _Service.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _Service.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getbycategory")]
        public IActionResult GetByCategoryId(int categoryId)
        {
            var result = _Service.GetAllByCategory(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpPost("add")]
        public IActionResult Add(_ product)
        {
            var result = _Service.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
