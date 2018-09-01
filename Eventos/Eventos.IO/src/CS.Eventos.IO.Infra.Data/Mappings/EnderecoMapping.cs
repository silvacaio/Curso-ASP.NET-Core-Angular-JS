using CS.Eventos.IO.Domain.Eventos;
using CS.Eventos.IO.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CS.Eventos.IO.Infra.Data.Mappings
{
    public class EnderecoMapping : EntityTypeConfiguration<Endereco>
    {
        public override void Map(EntityTypeBuilder<Endereco> builder)
        {
            builder.Property(e => e.Logradouro)
             .HasColumnType("varchar(150)")
             .IsRequired();

            builder.Property(e => e.Logradouro)
             .HasColumnType("varchar(20)")
             .IsRequired();

            builder.Property(e => e.Bairro)
             .HasColumnType("varchar(150)")
             .IsRequired();

            builder.Property(e => e.CEP)
             .HasColumnType("varchar(8)")
             .IsRequired();

            builder.Property(e => e.Complemento)
             .HasColumnType("varchar(100)");

            builder.Property(e => e.Cidade)
             .HasColumnType("varchar(100)")
             .IsRequired();

            builder.Property(e => e.Estado)
             .HasColumnType("varchar(100)")
             .IsRequired();

            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(e => e.CascadeMode);

            builder.ToTable("Enderecos");

            builder.HasOne(e => e.Evento)
                .WithOne(o => o.Endereco)
                .HasForeignKey<Endereco>(c => c.EventoId)
                .IsRequired();
        }
    }
}
