using FullStack.API.Services;
using FullStack.ViewModels.Adverts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStack.API.Controllers
{
    [Route("users/{userId}/adverts")]
    [ApiController]
    public class AdvertsController : ControllerBase
    {
        private readonly IAdvertService _adService;
        public AdvertsController(IAdvertService adService)
        {
            _adService = adService;
        }

        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<AdvertViewModel>> GetAllUserAdverts(int userId)
        {
            var adverts = _adService.GetAllUserAdverts(userId);
            return Ok(adverts);
        }

        [Authorize]
        [HttpGet("{advertId}", Name = "GetUserAdvertById")]
        public ActionResult<AdvertViewModel> GetUserAdvertById(int userId, int advertId)
        {
            var advert = _adService.GetUserAdvertById(userId, advertId);
            return Ok(advert);
        }

        [Authorize]
        [HttpPost]
        public ActionResult<AdvertViewModel> CreateUserAdvertById(int userId, AdvertCreateUpdateModel model)
        {
            var advert = _adService.CreateUserAdvertById(userId, model);
            return CreatedAtAction(nameof(GetUserAdvertById), new { userId = userId, advertId = advert.Id }, advert);
        }

        [Authorize]
        [HttpPut("{advertId}")]
        public IActionResult UpdateUserAdvertById(int userId, int advertId, AdvertCreateUpdateModel model)
        {
            _adService.UpdateUserAdvertById(userId, advertId, model);
            return NoContent();
        }

        [Authorize]
        [HttpGet("~/provinces")]
        public ActionResult<IEnumerable<ProvinceViewModel>> GetAllProvinces()
        {
            var provinces = _adService.GetAllProvinces();
            return Ok(provinces);
        }

        [Authorize]
        [HttpGet("~/cities")]
        public ActionResult<IEnumerable<CityViewModel>> GetAllCities()
        {
            var cities = _adService.GetAllCities();
            return Ok(cities);
        }

        [Authorize]
        [HttpGet("~/provinces/{provinceId}/cities")]
        public ActionResult<IEnumerable<ProvinceViewModel>> GetAllProvinceCities(int provinceId)
        {
            var cities = _adService.GetAllProvinceCities(provinceId);
            return Ok(cities);
        }
    }
}
