using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NationalParkApi.Models;
using NationalParkApi.Models.Dtos;
using NationalParkApi.Repository;
using System.Collections.Generic;
using System.Linq;

namespace NationalParkApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalParksController : ControllerBase
    {
        private readonly INationalParkRepository _nationalParkRepository;
        private readonly IMapper _mapper;

        public NationalParksController(INationalParkRepository nationalParkRepository, IMapper mapper)
        {
            _nationalParkRepository = nationalParkRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var nationalParks = _nationalParkRepository.GetNationalParks();
            var parksDto = _mapper.Map<List<NationalPark>>(nationalParks);

            return Ok(parksDto);
        }

        [HttpGet("{parkId}")]
        public IActionResult Get(int parkId)
        {
            var nationalPark = _nationalParkRepository.GetNationalPark(parkId);

            if(nationalPark == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<NationalParkDto>(nationalPark));
        }
    }
}
