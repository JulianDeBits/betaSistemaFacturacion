using Microsoft.AspNetCore.Mvc;
using SistemaFacturacion.BLL.Interfaces;
using SistemaFacturacion.DAL.Entities;
using SistemaFacturacion.API.Models;

public class CategoriaController : Controller
{
    private readonly ICategoriaService _categoriaService;

    public CategoriaController(ICategoriaService categoriaService)
    {
        _categoriaService = categoriaService;
    }

    public async Task<IActionResult> Index()
    {
        var categorias = await _categoriaService.ObtenerTodosAsync();
        return View(categorias);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(CategoriaViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        await _categoriaService.AgregarAsync(new Categoria
        {
            Nombre = model.Nombre,
            Descripcion = model.Descripcion
        });

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(int id)
    {
        var cat = await _categoriaService.ObtenerPorIdAsync(id);
        if (cat == null) return NotFound();

        return View(new CategoriaViewModel
        {
            Id = cat.Id,
            Nombre = cat.Nombre,
            Descripcion = cat.Descripcion
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(CategoriaViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        await _categoriaService.ActualizarAsync(new Categoria
        {
            Id = model.Id,
            Nombre = model.Nombre,
            Descripcion = model.Descripcion
        });

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int id)
    {
        var cat = await _categoriaService.ObtenerPorIdAsync(id);
        if (cat == null) return NotFound();
        return View(cat);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _categoriaService.EliminarAsync(id);
        return RedirectToAction("Index");
    }
}

