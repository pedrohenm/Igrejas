using Entities.Entidades;

namespace Domain.Interfaces.Servicos
{
    public interface IIgrejaServico
    {
        Task<Igreja> Incluir(Igreja igreja); 
    }
}
