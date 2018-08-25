using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppCoreGMQA.Models;
using WebAppCoreGMQA.ViewModels.Ciclo;
using WebAppCoreGMQA.ViewModels.Projeto;
using WebAppCoreGMQA.ViewModels.Risco;
using WebAppCoreGMQA.ViewModels.Usuario;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppCoreGMQA.ViewModels.Artefatos;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppCoreGMQA.Controllers
{

    [Authorize]
    public class ArtefatosController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext _context;
        public ArtefatosController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public string GetIdUserLogado(string email)
        {
            var userId =_userManager.Users.Where(a => a.Email == email).FirstOrDefault();
            return userId.Id;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {

            var artefatos = from a in _context.ArtefatosViewModel
                         join c in  _context.CicloViewModel on a.IdCiclo equals c.IdCiclos
                         join p in _context.ProjetoViewModel on c.IdProjeto equals p.IdProjeto
                         where p.IdUserAdmProjeto == GetIdUserLogado(User.Identity.Name) || p.IdUserResponsavelProjeto == GetIdUserLogado(User.Identity.Name)
                         select new ArtefatosViewModel
                         {
                             IdArtefato = a.IdArtefato,
                             IdCiclo = c.IdCiclos,
                             IdProjeto = c.IdProjeto,
                             Nome = a.Nome,
                             Caminho = a.Caminho,
                             NomeCiclo = "",
                             NomeProjeto = p.Nome

                         };

            var artefatosViewModel = artefatos.OrderBy(a => a.Nome).ToList();

            return View(artefatosViewModel);
        }

        public IActionResult Create()
        {
            CarregaViewBase();


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProjetoViewModel projetoViewModel)
        {
            if (ModelState.IsValid)
            {
                projetoViewModel.DataReal = DateTime.Now;
               
                _context.ProjetoViewModel.Add(projetoViewModel);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Usuarios = _userManager.Users.ToList();
            
            return View(projetoViewModel);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProjetoViewModel projetoViewModel = _context.ProjetoViewModel.SingleOrDefault(m => m.IdProjeto == id);
            ViewBag.Usuarios = _userManager.Users.ToList();
            ViewBag.IdUserAdmProjeto = _userManager.Users.Where(a => a.Email == User.Identity.Name).ToList();

            return View(projetoViewModel);
        }

        // POST: ProjetoViewModells/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProjetoViewModel projetoViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Update(projetoViewModel);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projetoViewModel);
        }

        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProjetoViewModel projetoViewModel = _context.ProjetoViewModel.SingleOrDefault(m => m.IdProjeto == id);
            if (projetoViewModel == null)
            {
                return NotFound();
            }

            return View(projetoViewModel);
        }

        // POST: NivelAcessoViewModels/Delete/5
        [ActionName("DeleteConfirmed")]
        public IActionResult DeleteConfirmed(int id)
        {
            var projeto = _context.ProjetoViewModel.Where(a => a.IdProjeto == id).FirstOrDefault();

            var ciclos = _context.CicloViewModel.Where(a => a.IdProjeto == id).ToList();

            var riscos = _context.RiscoViewModel.Where(a => a.IdProjeto == id).ToList();

            if (riscos.Count() != 0)
                _context.RiscoViewModel.RemoveRange(riscos);

            if (ciclos.Count() != 0)
                _context.CicloViewModel.RemoveRange(ciclos);

            _context.ProjetoViewModel.Remove(projeto);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult SearchProject(string filtro)
        {
            var search = _context.ProjetoViewModel.Where(a => a.Nome.Contains(filtro)).ToList();

            return PartialView(search);
        }

        public JsonResult RetornQntProd()
        {
            int aprovado = 0, andamento = 0, cancelado = 0, parado = 0;
            var idUserLogado = GetIdUserLogado(User.Identity.Name);

            var tdsProjeto = _context.ProjetoViewModel.Where(a => a.IdUserAdmProjeto == idUserLogado || a.IdUserResponsavelProjeto == idUserLogado).ToList().OrderBy(a => a.DataInicio);

            foreach (var item in tdsProjeto)
            {
                if (item.Status == "apro")
                    aprovado++;

                else if (item.Status == "anda")
                    andamento++;

                else if (item.Status == "canc")
                    cancelado++;

                else
                    parado++;

            }

            return Json(new { aprovado = aprovado, andamento = andamento, cancelado = cancelado, parado = parado });
        }

        public void CarregaViewBase()
        {
            var ListStatus = new List<SelectListItem>()
            {
                new SelectListItem {Text = "Em Andamento" , Value = "1"},
                new SelectListItem {Text = "Entregue" , Value = "2"},
                new SelectListItem {Text = "Revisando" , Value = "3"},
                new SelectListItem {Text = "Refazer" , Value = "4"}
            };

            ViewBag.ListProjetos = _context.ProjetoViewModel.Where(a => a.IdUserAdmProjeto == GetIdUserLogado(User.Identity.Name) || a.IdUserResponsavelProjeto == GetIdUserLogado(User.Identity.Name)).ToList();


            ViewBag.ListStatus = ListStatus;
            ViewBag.ListCiclos = _context.CicloViewModel.ToList();
        }

        public void CicloProjeto(int projeto)
        {
            ViewBag.ListCiclos = _context.CicloViewModel.Where(a => a.IdCiclos == projeto).ToList();
        }
    }
}
