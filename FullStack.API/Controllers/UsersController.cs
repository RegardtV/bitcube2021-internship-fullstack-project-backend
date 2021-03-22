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
using FullStack.ViewModels.Adverts;

namespace FullStack.API.Controllers
{
    [Route("users")]
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
        
        /*[HttpGet("{unsecure}")]
        public ActionResult<IEnumerable<UserViewModel>> GetAllUnsecure()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }*/

        [Authorize]
        [HttpGet("{id}", Name ="GetById")]
        public ActionResult<UserViewModel> GetById(int id)
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }

        [Authorize]
        [HttpGet("{userId}/adverts")]
        public ActionResult<IEnumerable<AdvertViewModel>> GetAllUserAdverts(int userId)
        {
            var adverts = _userService.GetAllUserAdverts(userId);
            return Ok(adverts);
        }

        [Authorize]
        [HttpGet("{userId}/adverts/{advertId}", Name = "GetUserAdvertById")]
        public ActionResult<AdvertViewModel> GetUserAdvertById(int userId, int advertId)
        {
            var advert = _userService.GetUserAdvertById(userId, advertId);
            return Ok(advert);
        }

        [Authorize]
        [HttpPost("{userId}/adverts")]
        public ActionResult<AdvertViewModel> CreateUserAdvertById(int userId, AdvertCreateUpdateModel model)
        {
            var advert = _userService.CreateUserAdvertById(userId, model);
            return CreatedAtAction(nameof(GetUserAdvertById), new { userId = userId, advertId = advert.Id }, advert);
        }

        [Authorize]
        [HttpPut("{userId}/adverts/{advertId}")]
        public IActionResult UpdateUserAdvertById(int userId, int advertId, AdvertCreateUpdateModel model)
        {
            _userService.UpdateUserAdvertById(userId, advertId, model);
            return NoContent();
        }
    }
}
