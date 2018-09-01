using CS.Eventos.IO.Domain.Organizadores;
using CS.Eventos.IO.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CS.Eventos.IO.Infra.Data.Mappings
{
    public class OrganizadorMapping : EntityTypeConfiguration<Organizador>
    {
        public override void Map(EntityTypeBuilder<Organizador> builder)
        {
            builder.Property(e => e.Nome)
                 .HasColumnType("varchar(150)")
                 .IsRequired();

            builder.Property(e => e.Email)
                 .HasColumnType("varchar(100)")
                 .IsRequired();

            builder.Property(e => e.CPF)
                 .HasColumnType("varchar(11)")
                 .IsRequired();

            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(e => e.CascadeMode);

            builder.ToTable("Organizadores");
        }
    }
}
