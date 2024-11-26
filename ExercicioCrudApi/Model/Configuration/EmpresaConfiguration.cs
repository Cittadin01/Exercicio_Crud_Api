using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExercicioCrudApi.Model.Configuration
{
    public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresa");
            builder.HasKey(a => a.EmpresaId);
            builder.Property(a => a.EmpresaId).HasColumnName("EmpresaId");
            builder.Property(a => a.Cnpj).HasColumnName("CNPJ").HasMaxLength(20).IsRequired();
            builder.Property(a => a.Nome).HasColumnName("Nome").IsRequired();
            builder.Property(a => a.País).HasColumnName("Pais").IsRequired();
            builder.Property(a => a.Endereço).HasColumnName("Endereco").IsRequired();
            builder.Property(a => a.Numero).HasColumnName("Numero").HasColumnType("decimal");
            builder.Property(a => a.Cep).HasColumnName("CEP").HasMaxLength(10).IsRequired();
            builder.Property(a => a.Active).HasColumnName("Ativo");
        }
    }
}
