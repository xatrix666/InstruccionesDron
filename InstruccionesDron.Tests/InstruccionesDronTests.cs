using AutoMapper;
using InstruccionesDron.Api.Controllers;
using InstruccionesDron.Api.DTOs;
using InstruccionesDron.Domain.Interfaces;
using InstruccionesDron.Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace InstruccionesDron.Tests
{
    public class InstruccionesDronTests
    {
        [Fact]
        public void Result_not_is_null()
        {
            Mock<IMapper> mapper = new Mock<IMapper>();
            Mock<IInstruccionesDronService> instruccionesDronService = new Mock<IInstruccionesDronService>();

            var instruccionRequestModel = GetInstruccionModelEjemplo();
            var instruccionResponseModel = GetInstruccionResponseModelEjemplo();
            instruccionesDronService.Setup(a => a.AplicarInstruccion(instruccionRequestModel)).Returns(instruccionResponseModel);

            InstruccionesDronController instruccionesDron = new InstruccionesDronController(mapper.Object, instruccionesDronService.Object);
            var instruccionDtoEjemplo = GetInstruccionDtoEjemplo();
            var result = instruccionesDron.GetPosicionesFinales(instruccionDtoEjemplo);

            Assert.NotNull(result);
        }

        private InstruccionRequestModel GetInstruccionModelEjemplo()
        {
            PosicionDronModel posicionDronModelRequest = new PosicionDronModel();
            posicionDronModelRequest.PosicionX = 0;
            posicionDronModelRequest.PosicionY = 0;
            posicionDronModelRequest.Direccion = "N";

            List<DatosDronModel> datosDronModelList = new List<DatosDronModel>();
            DatosDronModel datosDronModel = new DatosDronModel();
            datosDronModel.PosicionDronInicial = posicionDronModelRequest;
            datosDronModelList.Add(datosDronModel);

            Tama�oRectanguloModel tama�oRectanguloModel = new Tama�oRectanguloModel();
            tama�oRectanguloModel.RectanguloX = 5;
            tama�oRectanguloModel.RectanguloY = 5;

            InstruccionRequestModel instruccionRequestModel = new InstruccionRequestModel();
            instruccionRequestModel.Tama�oRectangulo = tama�oRectanguloModel;
            instruccionRequestModel.DatosDrones = datosDronModelList;

            return instruccionRequestModel;
        }
        private InstruccionResponseModel GetInstruccionResponseModelEjemplo()
        {
            List<PosicionDronModel> posicionDronModelList = new List<PosicionDronModel>();
            PosicionDronModel posicionDronModel = new PosicionDronModel();
            posicionDronModel.DronId = Guid.NewGuid();
            posicionDronModel.Direccion = "O";
            posicionDronModel.PosicionX = 3;
            posicionDronModel.PosicionY = 2;
            posicionDronModelList.Add(posicionDronModel);

            InstruccionResponseModel instruccionResponseModel = new InstruccionResponseModel();
            instruccionResponseModel.InstruccionId = Guid.NewGuid();
            instruccionResponseModel.PosicionFinalDrones = posicionDronModelList;

            return instruccionResponseModel;
        }
        private InstruccionRequestDto GetInstruccionDtoEjemplo()
        {
            PosicionDronDto posicionDronDtoRequest = new PosicionDronDto();
            posicionDronDtoRequest.PosicionX = 0;
            posicionDronDtoRequest.PosicionY = 0;
            posicionDronDtoRequest.Direccion = "N";

            List<DatosDronDto> datosDronDtoList = new List<DatosDronDto>();
            DatosDronDto datosDronDto = new DatosDronDto();
            datosDronDto.PosicionDronInicial = posicionDronDtoRequest;
            datosDronDtoList.Add(datosDronDto);

            Tama�oRectanguloDto tama�oRectanguloDto = new Tama�oRectanguloDto();
            tama�oRectanguloDto.RectanguloX = 5;
            tama�oRectanguloDto.RectanguloY = 5;

            InstruccionRequestDto instruccionRequestDto = new InstruccionRequestDto();
            instruccionRequestDto.Tama�oRectangulo = tama�oRectanguloDto;
            instruccionRequestDto.DatosDrones = datosDronDtoList;

            return instruccionRequestDto;
        }
    }
}
