using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using Business.Concrete;
using Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Infrastructure.Utilities.Results;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryBs;

        public CategoriesController(ICategoryService categoryBs)
        {
            _categoryBs = categoryBs;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _categoryBs.GetAll();
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        [HttpGet("get")]
        public IActionResult Get(int Id)
        {
            var result = _categoryBs.Get(c => c.Id == Id);
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        [Authorize(Roles = "Admin")]
        public IActionResult Add(Category category)
        {
            var result = _categoryBs.Add(category);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(Category category)
        {
            var result = _categoryBs.Update(category);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }

        [HttpPost("remove")]
        [Authorize(Roles = "Admin")]
        public IActionResult Remove(Category category)
        {
            var result = _categoryBs.Remove(category);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(Category category)
        {
            var result = _categoryBs.Delete(category);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }
    }
}