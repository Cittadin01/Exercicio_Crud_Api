namespace ExercicioCrudApi.Model
{
    public class Empresa
    {
        public Guid EmpresaId { get; set; }
        public string Cnpj { get; set; }
        public string Nome { get; set; }
        public string País { get; set; }
        public string Endereço { get; set; }
        public decimal Numero { get; set; }
        public string Cep { get; set; }
        public bool Active { get; set; }
    }
}
