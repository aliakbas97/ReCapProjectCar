
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {

        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();

            if(result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
        [HttpGet("getcarsbybrandid")]
        public IActionResult GetByBrandId(int id)
        {
            var result = _carService.GetCarsByBrandId(id);

            if(result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

      [HttpPost("add")]
      public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);

            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpPost("addrental")]
        public IActionResult AddRental(Rental rental)
        {
            var result = _carService.Add(rental);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpGet("getallrentalcar")]
        public IActionResult GetAllRentalCar()
        {
            var result = _carService.GetAllRentalCar();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
    }
}
