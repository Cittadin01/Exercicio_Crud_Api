using Dapper;
using ExercicioCrudApi.Model;
using ExercicioCrudApi.Model.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ExercicioCrudApi.Controllers
{
    public class EmpresaController : ControllerBase
    {
        private readonly Context _context;

        public EmpresaController(Context context)
        {
            _context = context;
        }

        [Route("criar-empresa")]
        [HttpPost]
        public IActionResult CadastrarEmpresa(EmpresaModel model)
        {
            try
            {
                Empresa empresa = new Empresa()
                {
                    EmpresaId = new Guid(),
                    Cnpj = model.Cnpj,
                    Nome = model.Nome,
                    País = model.País,
                    Endereço = model.Endereço,
                    Numero = model.Numero,
                    Cep = model.Cep,
                    Active = model.Active
                };

                _context.Add<Empresa>(empresa);
                _context.SaveChanges();

                return StatusCode(201, "Operação realizada com sucesso!");

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = ex.Message });
            }
        }

        [Route("cria-empresa-dapper")]
        [HttpPost]
        public IActionResult CriarEmpresaDapper(EmpresaModel model)
        {
            try
            {
                Empresa empresa = new Empresa()
                {
                    EmpresaId = Guid.NewGuid(),
                    Cnpj = model.Cnpj,
                    Nome = model.Nome,
                    País = model.País,
                    Endereço = model.Endereço,
                    Numero = model.Numero,
                    Cep = model.Cep,
                    Active = model.Active
                };

                var query = @"INSERT INTO Empresa(EmpresaId, Cnpj, Nome, Pais, Endereco, Numero, Cep, Ativo) VALUES (@EmpresaId, @Cnpj, @Nome, @País, @Endereço, @Numero, @Cep, @Active)";

                using (var connection = new SqlConnection("Data Source=PE0C0TDJ\\SQLEXPRESS;Initial Catalog=ExercicioEstagio;Persist Security Info=True;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;Application Name=EntityFramework"))
                {
                    connection.Execute(query, empresa);
                }

                return StatusCode(201, "Operação realizada com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = ex.Message });
            }
        }

        [Route("listar-empresa")]
        [HttpGet]
        public IActionResult ListarEmpresa(Guid empresaId)
        {
            try
            {
                var empresa = _context.Empresa.FirstOrDefault(a => a.EmpresaId == empresaId);
                return StatusCode(200, empresa);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }
        }

        [Route("listar-empresa-dapper")]
        [HttpGet]
        public IActionResult ListarEmpresaDapper(Guid empresaId)
        {
            try
            {
                using (var connection = new SqlConnection("Data Source=PE0C0TDJ\\SQLEXPRESS;Initial Catalog=ExercicioEstagio;Persist Security Info=True;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;Application Name=EntityFramework"))
                {
                    var empresa = connection.Query<Empresa>($"SELECT * FROM Empresa WHERE EmpresaId = @EmpresaId", new {EmpresaId = empresaId}).FirstOrDefault();
                    return StatusCode(200, empresa);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { empresaId = ex.Message });
            }
        }
    }
}
