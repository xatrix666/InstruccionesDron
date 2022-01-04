using InstruccionesDron.Domain.Interfaces;
using InstruccionesDron.Domain.Models;
using System;
using System.Collections.Generic;

namespace InstruccionesDron.Domain.Implementations
{
    public class InstruccionesDronService : IInstruccionesDronService
    {
        public InstruccionResponseModel AplicarInstruccion(InstruccionRequestModel request)
        {
            List<PosicionDronModel> posicionDronesList = new List<PosicionDronModel>();
            foreach (var datosDron in request.DatosDrones)
            {
                if (!ComprobarPosicion(request.TamañoRectangulo.RectanguloX, request.TamañoRectangulo.RectanguloY, datosDron.PosicionDronInicial.PosicionX, datosDron.PosicionDronInicial.PosicionY))
                {
                    return null;
                }
                var positionDronFinal = PosicionDronFinal(request.TamañoRectangulo, datosDron);
                if (positionDronFinal is null)
                {
                    positionDronFinal = new PosicionDronModel()
                    {
                        DronId = Guid.NewGuid(),
                        PosicionX = -1,
                        PosicionY = -1
                    };
                }
                posicionDronesList.Add(positionDronFinal);
            }

            InstruccionResponseModel instruccionResponseModel = new InstruccionResponseModel()
            {
                InstruccionId = Guid.NewGuid(),
                PosicionFinalDrones = posicionDronesList
            };

            return instruccionResponseModel;
        }


        private PosicionDronModel PosicionDronFinal(TamañoRectanguloModel tamañoArea, DatosDronModel datosDronModel)
        {
            int x = datosDronModel.PosicionDronInicial.PosicionX;
            int y = datosDronModel.PosicionDronInicial.PosicionY;
            var direccionActual = datosDronModel.PosicionDronInicial.Direccion;

            for (int i = 0; i < datosDronModel.MovimientoDron.Length; i++)
            {
                var letra = datosDronModel.MovimientoDron.Substring(i, 1);
                if (letra is "L" || letra is "R")
                {
                    direccionActual = DireccionActual(direccionActual, letra);
                }
                else
                {
                    if (direccionActual is "E") x--;
                    else if (direccionActual is "S") y--;
                    else if (direccionActual is "O") x++;
                    else y++;

                    if (!ComprobarPosicion(tamañoArea.RectanguloX, tamañoArea.RectanguloY, x, y)) return null;
                }
            }
            var posicionDronFinal = new PosicionDronModel()
            {
                DronId = Guid.NewGuid(),
                PosicionX = x,
                PosicionY = y,
                Direccion = direccionActual
            };

            return posicionDronFinal;
        }

        private bool ComprobarPosicion(int tamañaoX, int tamañoY, int posicionX, int posicionY)
        {
            if (tamañaoX < posicionX || tamañoY < posicionY)
            {
                return false;
            }
            return true;
        }

        private string DireccionActual(string direccionActual, string direccionNueva)
        {
            if (direccionActual is "E")
            {
                switch (direccionNueva)
                {
                    case "L":
                        return "S";
                    case "R":
                        return "N";
                    default:
                        break;
                }
            }
            else if (direccionActual is "S")
            {
                switch (direccionNueva)
                {
                    case "L":
                        return "O";
                    case "R":
                        return "E";
                    default:
                        break;
                }
            }
            else if (direccionActual is "O")
            {
                switch (direccionNueva)
                {
                    case "L":
                        return "N";
                    case "R":
                        return "S";
                    default:
                        break;
                }
            }
            else
            {
                switch (direccionNueva)
                {
                    case "L":
                        return "E";
                    case "R":
                        return "O";
                    default:
                        break;
                }
            }
            return null;
        }
    }
}
