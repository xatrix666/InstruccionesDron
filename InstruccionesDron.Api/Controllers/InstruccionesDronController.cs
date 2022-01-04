using AutoMapper;
using InstruccionesDron.Api.DTOs;
using InstruccionesDron.Domain.Interfaces;
using InstruccionesDron.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstruccionesDron.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstruccionesDronController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IInstruccionesDronService _instruccionesDronService;

        public InstruccionesDronController(IMapper mapper, IInstruccionesDronService instruccionesDronService)
        {
            _mapper = mapper;
            _instruccionesDronService = instruccionesDronService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<InstruccionResponseDto> GetPosicionesFinales(InstruccionRequestDto request)
        {
            if (request is null) return BadRequest();

            var requestModel = _mapper.Map<InstruccionRequestModel>(request);

            var result = _instruccionesDronService.AplicarInstruccion(requestModel);

            var responseDto = _mapper.Map<InstruccionResponseDto>(result);

            return Ok(responseDto);
        }
    }
}
