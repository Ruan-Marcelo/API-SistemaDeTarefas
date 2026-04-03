using Microsoft.EntityFrameworkCore;
using SistemaDeTarefasAPI.Models;

namespace SistemaDeTarefasAPI.Data
{
    public class SistemaTarefasDBContex : DbContext
    {

        public SistemaTarefasDBContex(DbContextOptions<SistemaTarefasDBContex> options) 
            : base(options)
        {

        }
        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}
