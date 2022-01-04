using System.Collections.Generic;

namespace InstruccionesDron.Domain.Models
{
    public class InstruccionRequestModel
    {
        public TamañoRectanguloModel TamañoRectangulo { get; set; }
        public List<DatosDronModel> DatosDrones { get; set; }
    }
}
