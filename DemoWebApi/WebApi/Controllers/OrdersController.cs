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
    [Authorize]//****************** Sayfa User Yetkisi
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderBs;

        public OrdersController(IOrderService orderBs)
        {
            _orderBs = orderBs;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _orderBs.GetAll();
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        [HttpGet("get")]
        public IActionResult Get(int Id)
        {
            var result = _orderBs.Get(c => c.Id == Id);
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Order order)
        {
            var result = _orderBs.Add(order);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(Order order)
        {
            var result = _orderBs.Update(order);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }

        [HttpPost("remove")]
        public IActionResult Remove(Order order)
        {
            var result = _orderBs.Remove(order);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Order order)
        {
            var result = _orderBs.Delete(order);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }
    }
}
