using AutoMapper;
using FPIS.Domain;
using FPIS.Service;
using FPIS.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPIS.Controllers
{
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
    }
}
