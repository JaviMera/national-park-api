using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NationalParkApi.Repository;

namespace NationalParkApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalParkController : ControllerBase
    {
        private readonly INationalParkRepository _nationalParkRepository;
        private readonly IMapper _mapper;

        public NationalParkController(INationalParkRepository nationalParkRepository, IMapper mapper)
        {
            _nationalParkRepository = nationalParkRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var parks = _nationalParkRepository.GetNationalParks();
            return Ok(parks);
        }
    }
}
