using AutoMapper;
using FPIS.Domain;
using FPIS.Models;
using FPIS.Service;
using FPIS.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FPIS.Controllers
{
    [Route("api/dobavljac")]
    [ApiController]
    public class DobavljacController : ControllerBase
    {
        private readonly IDobavljacService _dobavljacService;
        private readonly IMapper _mapper;

        public DobavljacController(IDobavljacService dobavljacService, IMapper mapper)
        {
            _dobavljacService = dobavljacService;
            _mapper = mapper;
        }

        [HttpGet("search")]
        public IActionResult Search([FromQuery] string searchTerm = null)
        {
            return Ok(_dobavljacService.Search(searchTerm));
        }

        [HttpGet("{id}", Name = "GetDobavljac")]
        public IActionResult Get(int id)
        {
            if (id < 0)
                return BadRequest(new ServiceResult<Dobavljac>(false, "'id' manji od 0."));

            var dobavljac = _dobavljacService.Get(id);

            if (dobavljac == null)
                return NotFound(new ServiceResult<Dobavljac>(false, "Dobavljac nije pronadjen."));

            return Ok(dobavljac);
        }

        [HttpPost]
        public IActionResult Post([FromBody] DobavljacDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var dobavljac = _mapper.Map<Dobavljac>(request);

            var result = _dobavljacService.Add(dobavljac);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EditDobavljacDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id < 0)
                return BadRequest(new ServiceResult<Dobavljac>(false, "'id' manji od 0."));

            var dobavljac = _dobavljacService.Get(id);

            if (dobavljac == null)
                return NotFound(new ServiceResult<Dobavljac>(false, "Dobavljac nije pronadjen."));

            _mapper.Map(request, dobavljac);

            var result = _dobavljacService.Update(dobavljac);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0)
                return BadRequest(new ServiceResult<Dobavljac>(false, "'id' manji od 0."));

            var dobavljac = _dobavljacService.Get(id);

            if (dobavljac == null)
                return NotFound(new ServiceResult<Dobavljac>(false, "Dobavljac nije pronadje."));

            var result = _dobavljacService.Delete(dobavljac);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("drzava")]
        public IActionResult GetAllDrzava()
        {
            return Ok(_dobavljacService.GetAllDrzava());
        }

        [HttpGet("grad/{drzavaId}")]
        public IActionResult GetAllGrad(int drzavaId)
        {
            return Ok(_dobavljacService.GetAllGrad(drzavaId));
        }

        [HttpGet("ulica/{gradId}")]
        public IActionResult GetAllUlica(int gradId)
        {
            return Ok(_dobavljacService.GetAllUlica(gradId));
        }

        [HttpGet("rang")]
        public IActionResult GetAllRangovi()
        {
            return Ok(_dobavljacService.GetAllRangovi());
        }
    }
}
