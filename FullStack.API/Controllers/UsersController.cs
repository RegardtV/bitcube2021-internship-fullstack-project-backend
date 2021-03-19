using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FullStack.API.Services;
using FullStack.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
using FullStack.API.Exceptions;

namespace FullStack.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public ActionResult<UserViewModel> Register(UserRegisterModel model)
        {

            var user = _userService.Create(model);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPost("authenticate")]
        public ActionResult<UserAuthenticateResponseModel> Authenticate(UserAuthenticateRequestModel model)
        {
            var response = _userService.Authenticate(model);
            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<UserViewModel>> GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
        
        [HttpGet("{unsecure}")]
        public ActionResult<IEnumerable<UserViewModel>> GetAllUnsecure()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [Authorize]
        [HttpGet("{id}", Name ="GetById")]
        public ActionResult<UserViewModel> GetById(int id)
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }
    }
}
