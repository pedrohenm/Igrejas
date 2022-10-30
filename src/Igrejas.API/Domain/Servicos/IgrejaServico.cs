using Domain.Interfaces.Repositorios;
using Domain.Interfaces.Servicos;
using Domain.Interfaces.UnitOfWorks;
using Entities.Entidades;

namespace Domain.Servicos
{
    public class IgrejaServico :
        IIgrejaServico
    {
        private IIgrejaRepositorio _repositorio;
        private IUnitOfWork _unitOfWork;

        public IgrejaServico(
            IIgrejaRepositorio repositorio,
            IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _unitOfWork = unitOfWork;
        }

        public async Task<Igreja> Incluir(Igreja igreja)
        {
            //await VerificarIgrejaJaExiste(igreja);

            var igrejaIncluida = await IncluirIgreja(igreja);

            return igrejaIncluida;
        }

        private async Task<Igreja> IncluirIgreja(Igreja igreja)
        {
            await _repositorio.Adicionar(igreja);

            await _unitOfWork.SaveChangesAsync();

            return igreja;
        }
    }
}
