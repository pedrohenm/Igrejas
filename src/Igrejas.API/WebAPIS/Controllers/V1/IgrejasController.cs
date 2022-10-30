using Domain.Interfaces.Servicos;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIS.ViewModels.Igrejas;

namespace WebAPIS.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class IgrejasController : 
        ControllerBase
    {
        private IIgrejaServico _igrejaServico;

        public IgrejasController(
            IIgrejaServico igrejaServico)
        {
            _igrejaServico = igrejaServico;
        }

        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> IncluirIgreja(
            [FromBody] IncluirIgrejaViewModel viewModel)
        {
            var imagem = Convert.FromBase64String(viewModel.Imagem);
            var logo = Convert.FromBase64String(viewModel.Logo);

            var igrejaParaIncluir = new Igreja(
                Guid.NewGuid(),
                viewModel.Nome,
                viewModel.Telefone1,
                viewModel.Telefone2,
                viewModel.DescricaoHistorica,
                imagem,
                logo);

            var igrejaIncluida = await _igrejaServico
                .Incluir(igrejaParaIncluir);

            return new OkObjectResult(igrejaIncluida)
            {
                StatusCode = StatusCodes.Status201Created,
            };
        }
    }
}
