using System;
using System.Collections.Generic;

namespace InstruccionesDron.Domain.Models
{
    public class InstruccionResponseModel
    {
        public Guid InstruccionId { get; set; }
        public List<PosicionDronModel> PosicionFinalDrones { get; set; }
    }
}
