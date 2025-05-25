using Microsoft.AspNetCore.Mvc;
using SistemaFacturacion.BLL.Interfaces;
using SistemaFacturacion.DAL.Entities;
using SistemaFacturacion.API.Models;

public class MonedaController : Controller
{
    private readonly IMonedaService _monedaService;

    public MonedaController(IMonedaService monedaService)
    {
        _monedaService = monedaService;
    }

    public async Task<IActionResult> Index()
    {
        var monedas = await _monedaService.ObtenerTodosAsync();

        var viewModel = monedas.Select(m => new MonedaViewModel
        {
            Id = m.Id,
            Codigo = m.Codigo,
            Nombre = m.Nombre,
            Simbolo = m.Simbolo
        }).ToList();

        return View(viewModel);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(MonedaViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        await _monedaService.AgregarAsync(new Moneda
        {
            Codigo = model.Codigo,
            Nombre = model.Nombre,
            Simbolo = model.Simbolo
        });

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(int id)
    {
        var moneda = await _monedaService.ObtenerPorIdAsync(id);
        if (moneda == null) return NotFound();

        return View(new MonedaViewModel
        {
            Id = moneda.Id,
            Codigo = moneda.Codigo,
            Nombre = moneda.Nombre,
            Simbolo = moneda.Simbolo
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(MonedaViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        await _monedaService.ActualizarAsync(new Moneda
        {
            Id = model.Id,
            Codigo = model.Codigo,
            Nombre = model.Nombre,
            Simbolo = model.Simbolo
        });

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int id)
    {
        var moneda = await _monedaService.ObtenerPorIdAsync(id);
        if (moneda == null) return NotFound();
        return View(moneda);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _monedaService.EliminarAsync(id);
        return RedirectToAction("Index");
    }
}
