using Market.API.Filters;
using Market.BL.Contracts;
using Market.Common.Contract;
using Market.Common.Exceptions;
using Market.DAL.Entities;
using System;
using System.Web.Http;

namespace Market.API.Controllers
{
    public class ProductController : ApiController
    {
        private IProductService _productService;
        private ILogger _loger;
        public ProductController(IProductService productService, ILogger logger)
        {
            _productService = productService;
            _loger = logger;
        }

        [HttpGet]
        [Route("Product/GetAllProducts")]
        public IHttpActionResult Get()
        {
            return Ok(_productService.GetAllProducts());
        }

        [HttpGet]
        [Route("Product/GetProductById/{id}")]
        public IHttpActionResult Get(int id)
        {
            _loger.LogInfo($"GetProductById started with parameter id ={id}");
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                throw new NotFoundByIdException("product by that id not found");
            }
            try
            {
                return Ok(product);
            }
            catch (Exception ex)
            {
                _loger.LogError(ex);
                return BadRequest();
            }
        }

        [HttpPost]
        [ModelValidator]
        [Route("Product/CreateProduct")]
        public IHttpActionResult Post([FromBody] Product product)
        {
            try
            {
                return Ok(_productService.AddProduct(product));
            }
            catch (Exception ex)
            {
                _loger.LogError(ex);
                return BadRequest();
            }
        }

        [HttpPut]
        [ModelValidator]
        [Route("Product/UpdateProduct")]
        public IHttpActionResult Put([FromBody] Product product)
        {
            try
            {
                return Ok(_productService.UpdateProduct(product));
            }

            catch (Exception ex)
            {
                _loger.LogError(ex);
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("Product/GetProductsAndCategories")]
        public IHttpActionResult GetProductsAndCategories()
        {
            try
            {
                return Ok(_productService.GetProductsAndCategories());
            }
            catch (Exception ex)
            {
                _loger.LogError(ex);
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("Product/GetProductsByCategory/{id}")]
        public IHttpActionResult GetProductsByCategory(int id)
        {
            var product = _productService.GetProductsByCategory(id);
            if (product == null)
            {
                throw new NotFoundByIdException("product by that id not found");
            }
            try
            {
                return Ok(product);
            }
            catch (Exception ex)
            {
                _loger.LogError(ex);
                return BadRequest();
            }
        }
    }
}
