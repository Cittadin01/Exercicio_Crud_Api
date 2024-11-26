namespace ExercicioCrudApi.Model
{
    public class Funcionario
    {
        public Guid FuncionarioId { get; set; }
        public string Nome { get; set; }
        public decimal Idade { get; set; }
        public string Cargo { get; set; }
        public bool Active { get; set; }
    }
}
