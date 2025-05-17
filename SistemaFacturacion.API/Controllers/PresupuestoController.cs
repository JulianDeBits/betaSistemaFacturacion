using Microsoft.AspNetCore.Mvc;
using SistemaFacturacion.BLL.Interfaces;
using SistemaFacturacion.DAL.Entities;
using SistemaFacturacion.API.Models;

namespace TuProyecto.API.Controllers
{
    public class PresupuestoController : Controller
    {
        private readonly IPresupuestoService _presupuestoService;

        public PresupuestoController(IPresupuestoService presupuestoService)
        {
            _presupuestoService = presupuestoService;
        }

        public async Task<IActionResult> Index()
        {
            var presupuestos = await _presupuestoService.ObtenerTodosAsync();
            return View(presupuestos);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(PresupuestoViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            await _presupuestoService.AgregarAsync(new Presupuesto
            {
                UsuarioId = model.UsuarioId,
                CategoriaId = model.CategoriaId,
                MonedaId = model.MonedaId,
                Limite = model.Limite,
                FechaInicio = model.FechaInicio,
                FechaFin = model.FechaFin
            });

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Editar(int id)
        {
            var presupuesto = await _presupuestoService.ObtenerPorIdAsync(id);
            if (presupuesto == null) return NotFound();

            var model = new PresupuestoViewModel
            {
                Id = presupuesto.Id,
                UsuarioId = presupuesto.UsuarioId,
                CategoriaId = presupuesto.CategoriaId,
                MonedaId = presupuesto.MonedaId,
                Limite = presupuesto.Limite,
                FechaInicio = presupuesto.FechaInicio,
                FechaFin = presupuesto.FechaFin
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(PresupuestoViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            await _presupuestoService.ActualizarAsync(new Presupuesto
            {
                Id = model.Id,
                UsuarioId = model.UsuarioId,
                CategoriaId = model.CategoriaId,
                MonedaId = model.MonedaId,
                Limite = model.Limite,
                FechaInicio = model.FechaInicio,
                FechaFin = model.FechaFin
            });

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            var presupuesto = await _presupuestoService.ObtenerPorIdAsync(id);
            if (presupuesto == null) return NotFound();

            return View(presupuesto);
        }

        [HttpPost, ActionName("Eliminar")]
        public async Task<IActionResult> ConfirmarEliminar(int id)
        {
            await _presupuestoService.EliminarAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
