using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefasAPI.Models;
using SistemaDeTarefasAPI.Repositorios;
using SistemaDeTarefasAPI.Repositorios.Interfaces;

namespace SistemaDeTarefasAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        public readonly ITarefaRepositorio _tarefaRepositorio;

        public TarefaController(ITarefaRepositorio tarefaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<TarefaModel>>> ListarTodas()
        {
            List<TarefaModel> tarefas =  await _tarefaRepositorio.BuscarTodasTarefas();
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaModel>> BuscarPorId(int id)
        { 
                TarefaModel tarefa = await _tarefaRepositorio.BuscarPorId(id);
                return Ok(tarefa);          
        }

        [HttpPost]
        public async Task<ActionResult<TarefaModel>> Cadastrar([FromBody] TarefaModel tarefaModel)
        {
            TarefaModel tarefa = await _tarefaRepositorio.Adicionar(tarefaModel);

            return Ok("Tarefa cadastrado com sucesso");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TarefaModel>> Atualizar([FromBody] TarefaModel tarefaModel, int id)
        {
            tarefaModel.Id = id;
            TarefaModel usuario = await _tarefaRepositorio.Atualizar(tarefaModel, id);

            return Ok("Tarefa Atualizado com sucesso");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> Apagar( int id)
        {
            bool apagado = await _tarefaRepositorio.Apagar(id);

            return Ok("tarefa Apagado com sucesso");
        }
    }
}
