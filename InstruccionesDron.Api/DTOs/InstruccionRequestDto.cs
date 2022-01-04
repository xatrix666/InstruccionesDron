using System.Collections.Generic;

namespace InstruccionesDron.Api.DTOs
{
    public class InstruccionRequestDto
    {
        public TamañoRectanguloDto TamañoRectangulo { get; set; }
        public List<DatosDronDto> DatosDrones { get; set; }
    }
}
