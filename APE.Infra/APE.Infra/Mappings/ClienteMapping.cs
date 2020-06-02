using APE.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.ProvaDev.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(x => x.Id)
                .HasColumnName("cd_cliente");

            builder.Property(x => x.IdGenero)
                .HasColumnName("cd_genero");

            builder.Property(x => x.Nome)
                .HasColumnName("nm_nome");

            builder.Property(x => x.Sobrenome)
                .HasColumnName("nm_sobrenome");

            builder.Property(x => x.Cpf)
                .HasColumnName("nu_cpf");

            builder.HasOne(e => e.Contato)
                .WithOne(e => e.Cliente)
                .HasForeignKey<Contato>(p => p.IdCliente);

            builder.ToTable("cliente", "Cliente");
        }
    }
}
