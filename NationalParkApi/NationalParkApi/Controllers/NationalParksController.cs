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

        [HttpGet("{parkId}", Name = "GetNationalPark")]
        public IActionResult GetNationalPark(int parkId)
        {
            var nationalPark = _nationalParkRepository.GetNationalPark(parkId);

            if (nationalPark == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<NationalParkDto>(nationalPark));
        }

        [HttpPost]
        public IActionResult Create([FromBody] NationalParkDto nationalParkDto)
        {
            if (nationalParkDto == null)
            {
                return BadRequest(nationalParkDto);
            }

            if (_nationalParkRepository.Exists(nationalParkDto.Name))
            {
                ModelState.AddModelError("", "National Park Exists!");
                return StatusCode(404, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nationalPark = _mapper.Map<NationalPark>(nationalParkDto);
            if (!_nationalParkRepository.CreateNationalPark(nationalPark))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {nationalPark.Name}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetNationalPark", new { parkId = nationalPark.Id }, nationalPark);
        }

        [HttpPatch("{parkId}", Name = "GetNationalPark")]
        public IActionResult Update(int parkId, [FromBody] NationalParkDto nationalParkDto)
        {
            if (nationalParkDto == null || parkId != nationalParkDto.Id)
            {
                return BadRequest(nationalParkDto);
            }

            if (_nationalParkRepository.Exists(nationalParkDto.Name))
            {
                ModelState.AddModelError("", "National Park Exists!");
                return StatusCode(404, ModelState);
            }

            var nationalPark = _mapper.Map<NationalPark>(nationalParkDto);

            if (!_nationalParkRepository.UpdateNationalPark(nationalPark))
            {
                ModelState.AddModelError("", $"Something went wrong when updating the record {nationalPark.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
