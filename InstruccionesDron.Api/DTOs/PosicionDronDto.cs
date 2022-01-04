using System;
using System.ComponentModel.DataAnnotations;

namespace InstruccionesDron.Api.DTOs
{
    public class PosicionDronDto
    {
        public Guid DronId { get; set; }

        [Required]
        public int PosicionX { get; set; }

        [Required]
        public int PosicionY { get; set; }

        [Required]
        public string Direccion { get; set; }

    }
}
