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
        private readonly IStavkaUlazneFaktureService _stavkaUlazneFaktureService;
        private readonly IMapper _mapper;

        public UlaznaFakturaController(IUlaznaFakturaService ulaznaFakturaService, IMapper mapper, IStavkaUlazneFaktureService stavkaUlazneFaktureService)
        {
            _ulaznaFakturaService = ulaznaFakturaService;
            _stavkaUlazneFaktureService = stavkaUlazneFaktureService;
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

            var ulaznaFaktura = _mapper.Map<UlaznaFaktura>(request);

            var result = _ulaznaFakturaService.Add(ulaznaFaktura);

            //foreach (var stavka in request.StavkeUlazneFakture)
            //{
            //    stavka.UlaznaFakturaId = result.ResultObject.Id;
            //    var stavkaUlazneFakture = _mapper.Map<StavkaUlazneFakture>(stavka);

            //    _stavkaUlazneFaktureService.Add(stavkaUlazneFakture);
            //}

            var response = _mapper.Map<UlaznaFakturaDto>(result.ResultObject);

            return Ok(response);
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

            //foreach (var stavka in ulaznaFaktura.StavkeUlazneFakture)
            //{
            //    if (stavka.StatusStavke == StatusStavke.None)
            //        continue;

            //    else if (stavka.StatusStavke == StatusStavke.Insert)
            //    {
            //        stavka.UlaznaFakturaId = ulaznaFaktura.Id;
            //        _stavkaUlazneFaktureService.Add(stavka);
            //    }

            //    else if (stavka.StatusStavke == StatusStavke.Update)
            //        _stavkaUlazneFaktureService.Update(stavka);

            //    else
            //        _stavkaUlazneFaktureService.Delete(stavka);
            //}

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

        [HttpGet("rang")]
        public IActionResult GetAllRangovi()
        {
            return Ok(_ulaznaFakturaService.GetAllRangovi());
        }
    }
}
