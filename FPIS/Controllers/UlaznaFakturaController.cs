using AutoMapper;
using FPIS.Domain;
using FPIS.Models;
using FPIS.Service;
using FPIS.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FPIS.Controllers
{

    [Route("api/ulaznafaktura")]
    [ApiController]
    public class UlaznaFakturaController : ControllerBase
    {
        private readonly IUlaznaFakturaService _ulaznaFakturaService;
        private readonly IStavkaUlazneFaktureService _stavkaUlazneFaktureService;
        private readonly IMapper _mapper;

        public UlaznaFakturaController(IUlaznaFakturaService ulaznaFakturaService, IMapper mapper, IStavkaUlazneFaktureService stavkaUlazneFaktureService)
        {
            _ulaznaFakturaService = ulaznaFakturaService;
            _stavkaUlazneFaktureService = stavkaUlazneFaktureService;
            _mapper = mapper;
        }

        [HttpGet("search")]
        public IActionResult Search([FromQuery] string searchTerm = null, int status = -1)
        {
            return Ok(_ulaznaFakturaService.Search(searchTerm, status));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id < 0)
                return BadRequest(new ServiceResult<UlaznaFaktura>(false, "'id' manji od 0."));

            var ulaznaFaktura = _ulaznaFakturaService.Get(id);

            if (ulaznaFaktura == null)
                return NotFound(new ServiceResult<UlaznaFaktura>(false, "Ulazna faktura nije pronadjena."));

            return Ok(ulaznaFaktura);
        }


        [HttpPost]
        public IActionResult Post([FromBody] UlaznaFakturaDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ulaznaFaktura = _mapper.Map<UlaznaFaktura>(request);

            var ulaznaFakturaResponse = _ulaznaFakturaService.Add(ulaznaFaktura);

            var result = _mapper.Map<ServiceResult<UlaznaFakturaDto>>(ulaznaFakturaResponse);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EditUlaznaFakturaDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id < 0)
                return BadRequest(new ServiceResult<UlaznaFaktura>(false, "'id' manji od 0."));

            var ulaznaFaktura = _ulaznaFakturaService.Get(id);

            if (ulaznaFaktura == null)
                return NotFound(new ServiceResult<UlaznaFaktura>(false, "Ulazna faktura nije pronadjena."));

            _mapper.Map(request, ulaznaFaktura);

            var ulaznaFakturaResponse = _ulaznaFakturaService.Update(ulaznaFaktura);

            var result = _mapper.Map<ServiceResult<EditUlaznaFakturaDto>>(ulaznaFakturaResponse);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0)
                return BadRequest(new ServiceResult<UlaznaFaktura>(false, "'id' manji od 0."));

            var ulaznaFaktura = _ulaznaFakturaService.Get(id);

            if (ulaznaFaktura == null)
                return NotFound(new ServiceResult<UlaznaFaktura>(false, "Ulazna faktura nije pronadjena."));

            var result = _ulaznaFakturaService.Delete(ulaznaFaktura);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("proizvod")]
        public IActionResult GetAllProizvodi()
        {
            return Ok(_ulaznaFakturaService.GetAllProizvodi());
        }

        [HttpGet("packinglista")]
        public IActionResult GetAllPackingListe()
        {
            return Ok(_ulaznaFakturaService.GetAllPackingListe());
        }
    }
}
