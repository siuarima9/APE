using APE.Domain.Models;
using Infra.ProvaDev.Mappings;
using Microsoft.EntityFrameworkCore;

namespace APE.Infra.Context
{
    public class ApeContext : DbContext
    {
        public ApeContext() { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Contato> Contatos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMapping());
            modelBuilder.ApplyConfiguration(new ContatoMapping());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server = db; Port = 5432; Database = apeapi; User Id = postgres; Password = postgres;");
        }
    }
}
