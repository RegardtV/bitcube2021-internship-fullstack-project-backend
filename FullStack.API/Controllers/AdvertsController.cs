using FullStack.API.Services;
using FullStack.ViewModels.Adverts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStack.API.Controllers
{
    [Route("adverts")]
    [ApiController]
    public class AdvertsController : ControllerBase
    {
        private readonly IAdvertService _adService;
        public AdvertsController(IAdvertService adService)
        {
            _adService = adService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AdvertViewModel>> GetAllAdverts()
        {
            var adverts = _adService.GetAllAdverts();
            return Ok(adverts);
        }

        [HttpGet("{advertId}")]
        public ActionResult<AdvertViewModel> GetAdvertById(int advertId)
        {
            var adverts = _adService.GetAdvertById(advertId);
            return Ok(adverts);
        }

        [Authorize]
        [HttpGet("provinces")]
        public ActionResult<IEnumerable<ProvinceViewModel>> GetAllProvinces()
        {
            var provinces = _adService.GetAllProvinces();
            return Ok(provinces);
        }

        [Authorize]
        [HttpGet("cities")]
        public ActionResult<IEnumerable<CityViewModel>> GetAllCities()
        {
            var cities = _adService.GetAllCities();
            return Ok(cities);
        }

        [Authorize]
        [HttpGet("provinces/{provinceId}/cities")]
        public ActionResult<IEnumerable<ProvinceViewModel>> GetAllProvinceCities(int provinceId)
        {
            var cities = _adService.GetAllProvinceCities(provinceId);
            return Ok(cities);
        }
    }
}
