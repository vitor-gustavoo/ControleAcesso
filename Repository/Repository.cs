using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Repository
{
    public class Context : DbContext
    {
        
        public DbSet<Usuario> Usuarios { get; set;}
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }
        string connection = "Server=localhost;Uid=root;Database=controleacesso;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseMySql(connection, ServerVersion.AutoDetect(connection));
        

    }


}