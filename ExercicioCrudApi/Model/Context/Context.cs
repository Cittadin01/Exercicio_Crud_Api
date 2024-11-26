using ExercicioCrudApi.Model.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ExercicioCrudApi.Model.Context
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=PE0C0TDJ\SQLEXPRESS;Initial Catalog=ExercicioEstagio;Persist Security Info=True;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;Application Name=EntityFramework");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmpresaConfiguration());
            modelBuilder.ApplyConfiguration(new FuncionarioConfiguration());
        }

        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
    }
}
