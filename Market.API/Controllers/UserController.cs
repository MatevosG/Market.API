using Market.API.Filters;
using Market.BL.Contracts;
using Market.Common.Contract;
using Market.DAL.Entities;
using System;
using System.Web.Http;

namespace Market.API.Controllers
{
    public class UserController : ApiController
    {
        private IUserService _userService;
        private ILogger _loger;
        public UserController(IUserService userService, ILogger logger)
        {
            _userService = userService;
            _loger = logger;
        }
        [HttpGet]
        [Route("User/GetAllUsers")]
        public IHttpActionResult GetAllUsers()
        {
             var users =  _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet]
        [Route("User/GetUserById/{id}")]
        public IHttpActionResult GetUserById(int id)
        {
            try
            {
                return Ok(_userService.GetUserById(id));
            }
            catch (Exception ex)
            {
                _loger.LogError(ex);
                return BadRequest();
            }
        }

        [HttpPost]
        [ModelValidator]
        [Route("User/CreateUser")]
        public IHttpActionResult CreateUser([FromBody] User User)
        {
            try
            {
                return Ok(_userService.AddUser(User));
            }
            catch (Exception ex)
            {
                _loger.LogError(ex);
                return BadRequest();
            }
        }

        [HttpPut]
        [ModelValidator]
        [Route("User/UpdateUser")]
        public IHttpActionResult UpdateUser([FromBody] User user)
        {
            try
            {
                return Ok(_userService.UpdateUser(user));
            }
            catch (Exception ex)
            {
                _loger.LogError(ex);
                return BadRequest();
            }
        }

    }
}
