using CursosProjeto.Data;
using CursosProjeto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CursosProjeto.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

      
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return _context.cursos != null ?
                          View(await _context.cursos.AsNoTracking().ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.cursos'  is null.");
        }

        public async Task<IActionResult> DetalhesCurso(int? id)
        {
            var curso = await _context.cursos.AsNoTracking().Include(x => x.modulos.OrderBy(x => x.OrdemDeExibicao))
                .FirstOrDefaultAsync(m => m.Id == id);

            return View(curso);
        }

        public async Task<IActionResult> DetalhesModulo(int? id)
        {
            ViewBag.TotalModulos = _context.modulos.AsNoTracking().Count();
            ViewBag.Ultimo = id;


            var modulo = await _context.modulos.Include(x => x.aulas)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            ViewBag.CursoAtual = modulo.CursoId.ToString();

            return View(modulo);
        }

        public async Task<IActionResult> DetalhesAula(int? id)
        {
            ViewBag.TotalAulas = _context.aulas.AsNoTracking().Count();
            ViewBag.Ultimo = id;
                
            

            var aula = await _context.aulas.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
            

            return View(aula);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}