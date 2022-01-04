using System;

namespace InstruccionesDron.Domain.Models
{
    public class PosicionDronModel
    {
        public Guid DronId { get; set; }
        public int PosicionX { get; set; }
        public int PosicionY { get; set; }
        public string Direccion { get; set; }
    }
}
