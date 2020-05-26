using System.Collections.Generic;
using BethanysPieShopHRM.Api.Models;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BethanysPieShopHRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;

        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        // GET: api/<controller>
        [HttpGet]
        public  IEnumerable<Country> GetCountries()
        {
	        //return Ok(_countryRepository.GetAllCountries());
	        return _countryRepository.GetAllCountries();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult GetCountryById(int id)
        {
            return Ok(_countryRepository.GetCountryById(id));
        }
    }
}
