using Microsoft.AspNetCore.Mvc;
using SistemaFacturacion.BLL.Interfaces;
using SistemaFacturacion.DAL.Entities;
using SistemaFacturacion.API.Models;

public class GastoController : Controller
{
    private readonly IGastoService _gastoService;
    private readonly ICategoriaService _categoriaService;
    private readonly IPresupuestoService _presupuestoService;

    public GastoController(IGastoService gastoService, ICategoriaService categoriaService, IPresupuestoService presupuestoService)
    {
        _gastoService = gastoService;
        _categoriaService = categoriaService;
        _presupuestoService = presupuestoService;
    }

    public async Task<IActionResult> Index()
    {
        var gastos = await _gastoService.ObtenerTodosAsync();
        return View(gastos);
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.Categorias = await _categoriaService.ObtenerTodosAsync();
        ViewBag.Presupuestos = await _presupuestoService.ObtenerTodosAsync();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(GastoViewModel model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Categorias = await _categoriaService.ObtenerTodosAsync();
            ViewBag.Presupuestos = await _presupuestoService.ObtenerTodosAsync();
            return View(model);
        }

        await _gastoService.AgregarAsync(new Gasto
        {
            PresupuestoId = model.PresupuestoId,
            CategoriaId = model.CategoriaId,
            Monto = model.Monto,
            Descripcion = model.Descripcion,
            Fecha = model.Fecha
        });

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(int id)
    {
        var gasto = await _gastoService.ObtenerPorIdAsync(id);
        if (gasto == null) return NotFound();

        ViewBag.Categorias = await _categoriaService.ObtenerTodosAsync();
        ViewBag.Presupuestos = await _presupuestoService.ObtenerTodosAsync();

        return View(new GastoViewModel
        {
            Id = gasto.Id,
            PresupuestoId = gasto.PresupuestoId,
            CategoriaId = gasto.CategoriaId,
            Monto = gasto.Monto,
            Descripcion = gasto.Descripcion,
            Fecha = gasto.Fecha
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(GastoViewModel model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Categorias = await _categoriaService.ObtenerTodosAsync();
            ViewBag.Presupuestos = await _presupuestoService.ObtenerTodosAsync();
            return View(model);
        }

        await _gastoService.ActualizarAsync(new Gasto
        {
            Id = model.Id,
            PresupuestoId = model.PresupuestoId,
            CategoriaId = model.CategoriaId,
            Monto = model.Monto,
            Descripcion = model.Descripcion,
            Fecha = model.Fecha
        });

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int id)
    {
        var gasto = await _gastoService.ObtenerPorIdAsync(id);
        if (gasto == null) return NotFound();
        return View(gasto);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _gastoService.EliminarAsync(id);
        return RedirectToAction("Index");
    }
}
