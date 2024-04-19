using GeradorValores.Context;
using GeradorValores.Models.ViewModel;
using GeradorValores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.Entity;
using System.Net;

namespace GeradorValores.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly AppDbContext _context;

        public FuncionariosController()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AppDbContext"].ConnectionString;
            _context = new AppDbContext(connectionString);
        }

        public ActionResult Index()
        {
            var funcionarios = _context.Funcionarios.ToList();
            return View(funcionarios);
        }

        public ActionResult GerarValores(int id)
        {
            var funcionario = _context.Funcionarios.Include("ValoresHora").FirstOrDefault(f => f.codigo == id);
            return View(funcionario);
        }


        [HttpPost]
        public ActionResult AdicionarValorHora(int IdFuncionario, decimal ValorHora, int Ano)
        {
            var funcionario = _context.Funcionarios.Include("ValoresHora").FirstOrDefault(f => f.codigo == IdFuncionario);

            if (funcionario != null)
            {
                for (int mes = 1; mes <= 12; mes++)
                {
                    var valorMensal = new tbl_funcionarios_valor_hora
                    {
                        id_funcionario = IdFuncionario,
                        valor_hora = ValorHora,
                        ano = Ano,
                        mes = mes
                    };

                    _context.FuncionariosValorHora.Add(valorMensal);
                }

                _context.SaveChanges();
            }

            return RedirectToAction("GerarValores", new { id = IdFuncionario });
        }

        public ActionResult EditarValor(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            tbl_funcionarios_valor_hora valorHora = _context.FuncionariosValorHora.Find(id);

            if (valorHora == null)
            {
                return HttpNotFound();
            }

            return View(valorHora);
        }


        [HttpPost]
        public JsonResult EditarValor(int codigo, decimal valorHora, int ano)
        {
            try
            {
                var valorOriginal = _context.FuncionariosValorHora.Find(codigo);

                if (valorOriginal != null)
                {
                    valorOriginal.valor_hora = valorHora;
                    valorOriginal.ano = ano;

                    _context.SaveChanges();

                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false, errorMessage = "Valor não encontrado." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = ex.Message });
            }
        }














    }
}