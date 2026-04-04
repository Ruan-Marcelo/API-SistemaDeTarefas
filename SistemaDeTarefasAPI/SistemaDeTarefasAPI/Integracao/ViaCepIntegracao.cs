using SistemaDeTarefasAPI.Controllers.Integracao.Refit;
using SistemaDeTarefasAPI.Controllers.Integracao.Response;
using SistemaDeTarefasAPI.Integracao.Interfaces;

namespace SistemaDeTarefasAPI.Integracao
{
    public class ViaCepIntegracao : IViaCepIntegracao
    {
        private readonly IViaCepIntegracaoRefit _viaCepIntegracaoRefit;

        public ViaCepIntegracao(IViaCepIntegracaoRefit viaCepIntgracaoRefit) 
        {
            _viaCepIntegracaoRefit = viaCepIntgracaoRefit;
        }
        public async Task<ViaCepResponse> ObterDadosViaCep(string cep)
        {
            var responseData = await _viaCepIntegracaoRefit.ObterDadosViaCep(cep);

            if(responseData != null && responseData.IsSuccessStatusCode)
            {
                return responseData.Content;
            }

            return null;
        }
    }
}
