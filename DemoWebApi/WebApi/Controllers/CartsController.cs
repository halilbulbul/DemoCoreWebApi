using Business.Abstract;
using Infrastructure.Utilities.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using System.Data;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartService _cartBs;
        private readonly IProductService _ProductBs;

        public CartsController(ICartService cartBs, IProductService productBs)
        {
            _cartBs = cartBs;
            _ProductBs = productBs;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _cartBs.GetAll();
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        [HttpGet("get")]
        public IActionResult Get(int Id)
        {
            var result = _cartBs.Get(c => c.Id == Id);
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Cart cart)
        {
            if (_ProductBs.StockControl(cart.ProductId))
            {
                var result = _cartBs.Add(cart);
                if (result.Success)
                    return Ok(result.Message);
                return BadRequest(result.Message);
            }
            return BadRequest("Ürün Stoklarımıza Kalmamıştır!");
        }

        [HttpPost("update")]
        public IActionResult Update(Cart cart)
        {
            var result = _cartBs.Update(cart);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }

        [HttpPost("remove")]
        public IActionResult Remove(Cart cart)
        {
            var result = _cartBs.Remove(cart);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Cart cart)
        {
            var result = _cartBs.Delete(cart);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }
    }
}
