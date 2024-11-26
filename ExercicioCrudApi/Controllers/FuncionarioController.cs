using Dapper;
using ExercicioCrudApi.Model;
using ExercicioCrudApi.Model.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ExercicioCrudApi.Controllers
{
    public class FuncionarioController : ControllerBase
    {
        private readonly Context _context;

        public FuncionarioController(Context context)
        {
            _context = context;
        }

        [Route("criar-funcionario")]
        [HttpPost]
        public ActionResult CadastrarFuncionario(FuncionarioModel model)
        {
            try
            {
                Funcionario funcionario = new Funcionario()
                {
                    FuncionarioId = new Guid(),
                    Nome = model.Nome,
                    Idade = model.Idade,
                    Cargo = model.Cargo,
                    Active = model.Active
                };

                _context.Add<Funcionario>(funcionario);
                _context.SaveChanges();

                return StatusCode(201, "Operação realizada com sucesso!");

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = ex.Message });
            }
        }

        [Route("cria-funcionario-dapper")]
        [HttpPost]
        public IActionResult CriarFuncionarioDapper(FuncionarioModel model)
        {
            try
            {
                Funcionario funcionario = new Funcionario()
                {
                    FuncionarioId = Guid.NewGuid(),
                    Nome = model.Nome,
                    Idade = model.Idade,
                    Cargo = model.Cargo,
                    Active = model.Active
                };

                var query = @"INSERT INTO Funcionario(FuncionarioId, Nome, Idade, Cargo, Ativo) VALUES (@FuncionarioId, @Nome, @Idade, @Cargo, @Active)";

                using (var connection = new SqlConnection("Data Source=PE0C0TDJ\\SQLEXPRESS;Initial Catalog=ExercicioEstagio;Persist Security Info=True;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;Application Name=EntityFramework"))
                {
                    connection.Execute(query, funcionario);
                }

                return StatusCode(201, "Operação realizada com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensagem = ex.Message });
            }
        }

        [Route("listar-funcionario")]
        [HttpGet]
        public IActionResult ListarFuncionario(Guid funcionarioId)
        {
            try
            {
                var funcionario = _context.Funcionario.FirstOrDefault(a => a.FuncionarioId == funcionarioId);
                return StatusCode(200, funcionario);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }
        }

        [Route("listar-funcionario-dapper")]
        [HttpGet]
        public IActionResult ListarFuncionarioDapper(Guid funcionarioId)
        {
            try
            {
                using (var connection = new SqlConnection("Data Source=PE0C0TDJ\\SQLEXPRESS;Initial Catalog=ExercicioEstagio;Persist Security Info=True;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;Application Name=EntityFramework"))
                {
                    var funcionario = connection.Query<Funcionario>($"SELECT * FROM Funcionario WHERE FuncionarioId = @FuncionarioId", new {FuncionarioId = funcionarioId}).FirstOrDefault();
                    return StatusCode(200, funcionario);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { funcionarioId = ex.Message });
            }
        }
    }
}
