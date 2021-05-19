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

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_dobavljacService.GetAll());
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
        public IActionResult Put(int id, [FromBody] EditUlaznaFakturaDto request)
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
            _mapper.Map<EditUlaznaFakturaDto>(result.ResultObject);

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

        [HttpGet("grad")]
        public IActionResult GetAllGrad()
        {
            return Ok(_dobavljacService.GetAllGrad());
        }

        [HttpGet("ulica")]
        public IActionResult GetAllUlica()
        {
            return Ok(_dobavljacService.GetAllUlica());
        }
    }
}
