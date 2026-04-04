using SistemaDeTarefasAPI.Enums;

namespace SistemaDeTarefasAPI.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public StatusTerafa Status { get; set; }

        public int? UsuarioId { get; set; }

        public UsuarioModel? Usuario { get; set; }
    }
}
