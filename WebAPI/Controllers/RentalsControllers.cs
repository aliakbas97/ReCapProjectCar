using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsControllers : ControllerBase
    {
        IRentalService _rentalService;

        public RentalsControllers(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpPost("addrental")]
        public IActionResult AddRental(Rental rental)
        {
            var result = _rentalService.Add(rental);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }


        [HttpGet("getallrentalcar")]
        public IActionResult GetAllRentalCar()
        {
            var result = _rentalService.GetAllRentalCar();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


    }
}
