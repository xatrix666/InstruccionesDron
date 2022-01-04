using InstruccionesDron.Domain.Models;

namespace InstruccionesDron.Domain.Interfaces
{
    public interface IInstruccionesDronService
    {
        InstruccionResponseModel AplicarInstruccion(InstruccionRequestModel request);
    }
}
