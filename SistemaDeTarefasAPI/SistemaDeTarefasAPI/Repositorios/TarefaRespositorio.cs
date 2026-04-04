using Microsoft.EntityFrameworkCore;
using SistemaDeTarefasAPI.Data;
using SistemaDeTarefasAPI.Models;
using SistemaDeTarefasAPI.Repositorios.Interfaces;

namespace SistemaDeTarefasAPI.Repositorios
{
    public class TarefaRespositorio : ITarefaRepositorio
    {

        private readonly SistemaTarefasDBContex _dbContext;

        public TarefaRespositorio(SistemaTarefasDBContex sistemaTarefasDBContex)
        {
            _dbContext = sistemaTarefasDBContex;
        }

        public async Task<TarefaModel> BuscarPorId(int id)
        {
            return await _dbContext.Tarefas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TarefaModel>> BuscarTodasTarefas()
        {
            return await _dbContext.Tarefas.ToListAsync();
        }

        public async Task<TarefaModel> Adicionar(TarefaModel tarefa)
        {
            await _dbContext.Tarefas.AddAsync(tarefa);
            await _dbContext.SaveChangesAsync();

            return tarefa;

        }

        public async Task<TarefaModel> Atualizar(TarefaModel tarefa, int id)
        {
            TarefaModel TarefaPorId = await  BuscarPorId(id);
            
            if(TarefaPorId == null)
            {
                throw new Exception($"Tarefa para o ID: {id} Não foi encontrado no banco de dados");
            }

            TarefaPorId.Nome = tarefa.Nome;
            TarefaPorId.Descricao = tarefa.Descricao;
            TarefaPorId.Status = tarefa.Status;
            TarefaPorId.UsuarioId = tarefa.UsuarioId;

            _dbContext.Tarefas.Update(TarefaPorId);
            await _dbContext.SaveChangesAsync();

            return TarefaPorId;
        }
        public async Task<bool> Apagar(int id)
        {
            TarefaModel tarefaPorId = await BuscarPorId(id);

            if (tarefaPorId == null)
            {
                throw new Exception($"Tarerfa para o ID: {id} Não foi encontrado no banco de dados");
            }

            _dbContext.Tarefas.Remove(tarefaPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }    
    }
}
