using Infrastructure.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using Models.Entities;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Infrastructure.Utilities.Results;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productBs;
        public ProductsController(IProductService productBs)
        {
            _productBs = productBs;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _productBs.GetAll(x => x.IsActive);
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        [HttpGet("get/{id}")]
        public IActionResult Get(int Id)
        {
            var result = _productBs.Get(c => c.Id == Id && c.IsActive);
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        [HttpPost("active")]
        public IActionResult Active(Product product)
        {
            product.IsActive = true;
            var result = _productBs.Update(product);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }
        [HttpPost("passive")]
        public IActionResult passive(Product product)
        {
            product.IsActive = false;
            var result = _productBs.Update(product);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }

        [HttpGet("filter/{param}")]
        public IActionResult Filter(string param)
        {
            var result = _productBs.Get(c => c.ProductName == param);
            if (result.Success)
                return Ok(result.Data);
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        [Authorize(Roles = "Admin")]
        public IActionResult Add(Product product)
        {
            var result = _productBs.Add(product);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(Product product)
        {
            var result = _productBs.Update(product);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }

        [HttpPost("remove")]
        [Authorize(Roles = "Admin")]
        public IActionResult Remove(Product product)
        {
            var result = _productBs.Remove(product);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(Product product)
        {
            var result = _productBs.Delete(product);
            if (result.Success)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }

        [HttpGet("getpc")]
        public List<Product> GetProductsWithCategories()
        {
            RepositoryParameters<Product> parameters = new();
            parameters.includeList = new string[] { "Category" };
            var products = _productBs.GetAll(null, parameters);
            return products.Data;
        }

        [HttpGet("getsome/{skip}/{take}")]
        public List<Product> GetSomeProducts(int skip, int take)
        {
            RepositoryParameters<Product> parameters = new();
            parameters.skip = skip;
            parameters.take = take;
            var products = _productBs.GetAll(null, parameters);
            return products.Data;
        }

        [HttpGet("getproductsbycategoryid/{id}/")]
        public List<Product> GetProductsByCategoryId(int id)
        {
            RepositoryParameters<Product> parameters = new();
            parameters.filter = p => p.Id == id;
            var products = _productBs.GetAll(null, parameters);
            return products.Data;
        }
    }
}
