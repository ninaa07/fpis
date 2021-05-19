using AutoMapper;
using FPIS.Domain;
using FPIS.Models;
using FPIS.Service;
using FPIS.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPIS.Controllers
{

    [Route("api/ulaznafaktura")]
    [ApiController]
    public class UlaznaFakturaController : ControllerBase
    {
        private readonly IUlaznaFakturaService _ulaznaFakturaService;
        private readonly IMapper _mapper;

        public UlaznaFakturaController(IUlaznaFakturaService ulaznaFakturaService, IMapper mapper)
        {
            _ulaznaFakturaService = ulaznaFakturaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_ulaznaFakturaService.GetAll());
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

            foreach (var stavka in request.StavkeUlazneFakture)
            {
            }

            var ulaznaFaktura = _mapper.Map<UlaznaFaktura>(request);

            _ulaznaFakturaService.Add(ulaznaFaktura);

            return Ok(ulaznaFaktura);
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

            foreach (var stavka in ulaznaFaktura.StavkeUlazneFakture)
            {
                
            }

            var result = _ulaznaFakturaService.Update(ulaznaFaktura);

            _mapper.Map<EditUlaznaFakturaDto>(result.ResultObject);

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
    }
}
