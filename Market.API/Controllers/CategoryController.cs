using Market.API.Filters;
using Market.BL.Contracts;
using Market.Common.Contract;
using Market.Common.Helpers;
using Market.DAL.Entities;
using System;
using System.Web.Http;

namespace Market.API.Controllers
{
    public class CategoryController : ApiController
    {
        private ICategoryService _categoryService;
        private ILogger _loger ;
        public CategoryController(ICategoryService inventaryService, ILogger logger)
        {
            _categoryService = inventaryService;
            _loger = logger;
        }
        
        [HttpGet]
        [Route("Category/GetCategories")]
        public IHttpActionResult GetCategories()
        {
            return Ok(_categoryService.GetAllCategories());
        }

        [HttpGet]
        [Route("Category/GetCategoryById/{id}")]
        public IHttpActionResult GetCategoryById(int id)
        {
            try
            {
                int a = 7;
                int b = a / 0;
                return Ok(_categoryService.GetCategory(id));
            }
            catch (Exception ex)
            {
                 _loger.LogError(ex);
                return BadRequest("lav ban chi exel");
            }
        }

        [HttpPost]
        [ModelValidator]
        [Route("Category/CreateCategory")]
        public IHttpActionResult CreateCategory([FromBody]Category category)
        {
            try
            {
                return Ok(_categoryService.AddCategory(category));
            }
            catch (Exception ex)
            {
                _loger.LogError(ex);
                return BadRequest("lav ban chi exel");
            }
        }

        [HttpPut]
        [ModelValidator]
        [Route("Category/UpdateCategory")]
        public IHttpActionResult UpdateCategory([FromBody] Category category)
        {
            try
            {
                return Ok(_categoryService.UpdateCategory(category));
            }
            catch (Exception ex)
            {
                _loger.LogError(ex);
                return BadRequest("lav ban chi exel");
            }
        }
    }
}
