using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExercicioCrudApi.Model.Configuration
{
    public class FuncionarioConfiguration : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("Funcionario");
            builder.HasKey(a => a.FuncionarioId);
            builder.Property(a => a.FuncionarioId).HasColumnName("FuncionarioId");
            builder.Property(a => a.Nome).HasColumnName("Nome").IsRequired();
            builder.Property(a => a.Idade).HasColumnName("Idade").HasMaxLength(3).IsRequired().HasColumnType("decimal");
            builder.Property(a => a.Cargo).HasColumnName("Cargo").IsRequired();
            builder.Property(a => a.Active).HasColumnName("Ativo");
        }
    }
}
