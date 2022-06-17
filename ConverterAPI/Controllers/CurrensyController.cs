using System;
using ConverterAPI.Data;
using ConverterAPI.Services;
using CurrencyConverter.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConverterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrensyController : Controller
    {
        private readonly CurrencyDbService _service;
        
        public CurrensyController(CurrencyDbService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var currencies = _service.GetAll();
            return Ok(currencies);
        }
        [HttpGet("{id}")]
        public IActionResult GetbyID(string id)
        {
            var currency = _service.GetById(id);
            return Ok(currency);
        }
        
        [HttpPost]
        public IActionResult AddCurrency([FromBody] Currency currency)
        {
            if (currency == null)
            {
                return BadRequest("Currency is null");
            }

            if (_service.CheckIfExsist(currency.Id).Result)
            {
                return BadRequest("Currency already exists");
            }
            _service.Create(currency);
            return Ok("Currency added");
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateCurrency(string id)
        {
            if (id == null)
            {
                return BadRequest("Currency id is null");
            }
            var currency = _service.GetById(id);
            _service.Update(currency.Result);
            return Ok("Currency updated");

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCurrency(string id)
        {
            if (id == null)
            {
                return BadRequest("Currency id is null");
            }
            _service.Delete(id);
            return Ok("Currency deleted");
        }
    }
}