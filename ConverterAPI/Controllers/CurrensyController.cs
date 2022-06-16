using System;
using Microsoft.AspNetCore.Mvc;

namespace ConverterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrensyController:Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}