using System.ComponentModel;

namespace SistemaDeTarefasAPI.Enums
{
    public enum StatusTerafa
    {
        [Description("A Fazer")]
        AFazer = 1,
        [Description("Em Andamento")]
        EmAndamento = 2,
        [Description("Concluído")]
        Concluido = 3


    }
}
