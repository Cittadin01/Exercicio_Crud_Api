namespace ExercicioCrudApi.Controllers
{
    public class EmpresaModel
    {
        public string Cnpj { get; set; }
        public string Nome { get; set; }
        public string País { get; set; }
        public string Endereço { get; set; }
        public decimal Numero { get; set; }
        public string Cep { get; set; }
        public bool Active { get; set; }
    }
}
