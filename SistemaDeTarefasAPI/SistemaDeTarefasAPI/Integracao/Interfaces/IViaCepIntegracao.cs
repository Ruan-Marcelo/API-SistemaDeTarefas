using SistemaDeTarefasAPI.Controllers.Integracao.Response;

namespace SistemaDeTarefasAPI.Integracao.Interfaces
{
    public interface IViaCepIntegracao
    {
        Task<ViaCepResponse> ObterDadosViaCep(string cep);
    }
}
