using System.ComponentModel.DataAnnotations;

namespace InstruccionesDron.Api.DTOs
{
    public class DatosDronDto
    {
        public PosicionDronDto PosicionDronInicial { get; set; }

        [Required]
        public string MovimientoDron { get; set; }
    }
}
