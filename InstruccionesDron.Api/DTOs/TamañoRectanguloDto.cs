using System.ComponentModel.DataAnnotations;

namespace InstruccionesDron.Api.DTOs
{
    public class TamañoRectanguloDto
    {
        [Required]
        public int RectanguloX { get; set; }

        [Required]
        public int RectanguloY { get; set; }
    }
}
