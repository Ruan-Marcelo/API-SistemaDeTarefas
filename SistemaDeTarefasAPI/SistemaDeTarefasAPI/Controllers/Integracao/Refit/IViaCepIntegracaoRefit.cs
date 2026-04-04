using Refit;
using SistemaDeTarefasAPI.Controllers.Integracao.Response;

namespace SistemaDeTarefasAPI.Controllers.Integracao.Refit
{
    public interface IViaCepIntegracaoRefit
    {
        [Get("/ws/{cep}/json")]
        Task<ApiResponse<ViaCepResponse>> ObterDadosViaCep(string cep);
    }
}
