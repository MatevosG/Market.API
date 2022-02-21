using Market.API.Filters;
using Market.BL.Contracts;
using Market.BL.Sevices;
using Market.DAL.Contracts;
using Market.DAL.Entities;
using Market.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Market.API.Controllers
{
    public class AuthorizationController : ApiController
    {
        public IAuthorizationService _authorizationService;
        public AuthorizationController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [HttpPost]
        [ModelValidator]
        public IHttpActionResult Login([FromBody] User user)
        {
            var userLogin = _authorizationService.TryGetUser(user);
            if (user == null)
                return Unauthorized();
            var token = _authorizationService.CreateToken(user);
            if (token == null)
                return NotFound();
            return Ok(token);
        }
    }
}
