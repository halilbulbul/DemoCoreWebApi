using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using System.Data;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private readonly IModelService _modelBs;

        public ModelsController(IModelService modelBs)
        {
            _modelBs = modelBs;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _modelBs.GetAll();
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        [HttpGet("get")]
        public IActionResult Get(int Id)
        {
            var result = _modelBs.Get(c => c.Id == Id);
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        [Authorize(Roles = "Admin")]
        public IActionResult Add(Model model)
        {
            var result = _modelBs.Add(model);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(Model model)
        {
            var result = _modelBs.Update(model);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }

        [HttpPost("remove")]
        [Authorize(Roles = "Admin")]
        public IActionResult Remove(Model model)
        {
            var result = _modelBs.Remove(model);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(Model model)
        {
            var result = _modelBs.Delete(model);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }
    }
}
