using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class Context : DbContext
    {
        
        public DbSet<Models.Usuarios> Usuarios { get; set;}
        public DbSet<Models.Perfil> Perfil { get; set; }
        public DbSet<Models.Sessoes> Sessoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Uid=root;Database=controleacesso;");
        }

    }


}