using System;
using System.Collections.Generic;

namespace InstruccionesDron.Api.DTOs
{
    public class InstruccionResponseDto
    {
        public Guid InstruccionId { get; set; }
        public List<PosicionDronDto> PosicionFinalDrones { get; set; }

    }
}
