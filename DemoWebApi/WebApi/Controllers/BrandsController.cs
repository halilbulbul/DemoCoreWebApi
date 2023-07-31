using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize()]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandBs;

        public BrandsController(IBrandService brandBs)
        {
            _brandBs = brandBs;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _brandBs.GetAll();
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        [HttpGet("get")]
        public IActionResult Get(int Id)
        {
            var result = _brandBs.Get(c => c.Id == Id);
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        [Authorize(Roles = "Admin")]
        public IActionResult Add(Brand brand)
        {
            var result = _brandBs.Add(brand);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(Brand brand)
        {
            var result = _brandBs.Update(brand);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }

        [HttpPost("remove")]
        [Authorize(Roles = "Admin")]
        public IActionResult Remove(Brand brand)
        {
            var result = _brandBs.Remove(brand);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(Brand brand)
        {
            var result = _brandBs.Delete(brand);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }
    }
}
