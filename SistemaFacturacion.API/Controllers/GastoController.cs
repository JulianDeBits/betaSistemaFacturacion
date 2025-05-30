﻿using Microsoft.AspNetCore.Mvc;
using SistemaFacturacion.BLL.Interfaces;
using SistemaFacturacion.DAL.Entities;
using SistemaFacturacion.API.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using System.Linq;

public class GastoController : Controller
{
    private readonly IGastoService _gastoService;
    private readonly IUsuarioService _usuarioService;
    private readonly ICategoriaService _categoriaService;
    private readonly IMonedaService _monedaService;

    public GastoController(
        IGastoService gastoService,
        IUsuarioService usuarioService,
        ICategoriaService categoriaService,
        IMonedaService monedaService)
    {
        _gastoService = gastoService;
        _usuarioService = usuarioService;
        _categoriaService = categoriaService;
        _monedaService = monedaService;
    }

    public async Task<IActionResult> Index()
    {
        var gastos = await _gastoService.ObtenerTodosAsync();
        var usuarios = await _usuarioService.ObtenerTodosAsync();
        var categorias = await _categoriaService.ObtenerTodosAsync();
        var monedas = await _monedaService.ObtenerTodosAsync();

        var viewModel = gastos.Select(g => new GastoViewModel
        {
            Id = g.Id,
            UsuarioId = g.UsuarioId,
            UsuarioNombre = usuarios.FirstOrDefault(u => u.Id == g.UsuarioId)?.Nombre,
            CategoriaId = g.CategoriaId,
            CategoriaNombre = categorias.FirstOrDefault(c => c.Id == g.CategoriaId)?.Nombre,
            MonedaId = g.MonedaId,
            MonedaNombre = monedas.FirstOrDefault(m => m.Id == g.MonedaId)?.Nombre,
            Monto = g.Monto,
            Fecha = g.Fecha,
            Descripcion = g.Descripcion
        });

        return View(viewModel);
    }

    public async Task<IActionResult> Create()
    {
        var model = new GastoViewModel(); 
        await CargarListasDesplegables(model);
        return View(model); 
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(GastoViewModel model)
    {
        if (!ModelState.IsValid)
        {
            await CargarListasDesplegables(model);
            return View(model);
        }

        var gasto = new Gasto
        {
            Id = model.Id,
            UsuarioId = model.UsuarioId.Value,     
            CategoriaId = model.CategoriaId.Value,
            MonedaId = model.MonedaId.Value,
            Monto = model.Monto,
            Fecha = model.Fecha,
            Descripcion = model.Descripcion
        };

        await _gastoService.AgregarAsync(gasto);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(int id)
    {
        var gasto = await _gastoService.ObtenerPorIdAsync(id);
        if (gasto == null) return NotFound();

        var model = new GastoViewModel
        {
            Id = gasto.Id,
            UsuarioId = gasto.UsuarioId,
            CategoriaId = gasto.CategoriaId,
            MonedaId = gasto.MonedaId,
            Monto = gasto.Monto,
            Fecha = gasto.Fecha,
            Descripcion = gasto.Descripcion
        };

        await CargarListasDesplegables(model);
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(GastoViewModel model)
    {
        ModelState.Remove("UsuarioNombre");
        ModelState.Remove("CategoriaNombre");
        ModelState.Remove("MonedaNombre");

        foreach (var kvp in ModelState)
        {
            var field = kvp.Key;
            var state = kvp.Value;

            if (state.Errors.Any())
            {
                Console.WriteLine($"Campo: {field}");
                foreach (var error in state.Errors)
                {
                    Console.WriteLine($"  ➤ Error: {error.ErrorMessage}");
                }
            }
        }

        var usuarioExiste = await _usuarioService.ObtenerPorIdAsync(model.UsuarioId ?? 0) != null;
        var categoriaExiste = await _categoriaService.ObtenerPorIdAsync(model.CategoriaId ?? 0) != null;
        var monedaExiste = await _monedaService.ObtenerPorIdAsync(model.MonedaId ?? 0) != null;


        if (!ModelState.IsValid)
        {
            await CargarListasDesplegables(model);
            return View(model);
        }

        var gasto = new Gasto
        {
            Id = model.Id,
            UsuarioId = model.UsuarioId.Value,
            CategoriaId = model.CategoriaId.Value,
            MonedaId = model.MonedaId.Value,
            Monto = model.Monto,
            Fecha = model.Fecha,
            Descripcion = model.Descripcion
        };

        try
        {
            await _gastoService.ActualizarAsync(gasto);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, $"Ocurrió un error al actualizar el gasto: {ex.Message}");
            await CargarListasDesplegables(model);
            return View(model);
        }

        return RedirectToAction("Index");
    }


    public async Task<IActionResult> Delete(int id)
    {
        var gasto = await _gastoService.ObtenerPorIdAsync(id);
        if (gasto == null) return NotFound();

        var usuario = await _usuarioService.ObtenerPorIdAsync(gasto.UsuarioId);
        var categoria = await _categoriaService.ObtenerPorIdAsync(gasto.CategoriaId);
        var moneda = await _monedaService.ObtenerPorIdAsync(gasto.MonedaId);

        var model = new GastoViewModel
        {
            Id = gasto.Id,
            UsuarioId = gasto.UsuarioId,
            UsuarioNombre = usuario?.Nombre,
            CategoriaId = gasto.CategoriaId,
            CategoriaNombre = categoria?.Nombre,
            MonedaId = gasto.MonedaId,
            MonedaNombre = moneda?.Nombre,
            Monto = gasto.Monto,
            Fecha = gasto.Fecha,
            Descripcion = gasto.Descripcion
        };

        return View(model);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _gastoService.EliminarAsync(id);
        return RedirectToAction("Index");
    }

    private async Task CargarListasDesplegables(GastoViewModel model)
    {
        var usuarios = await _usuarioService.ObtenerTodosAsync();
        var categorias = await _categoriaService.ObtenerTodosAsync();
        var monedas = await _monedaService.ObtenerTodosAsync();

        ViewBag.Usuarios = new SelectList(usuarios, "Id", "Nombre", model?.UsuarioId);
        ViewBag.Categorias = new SelectList(categorias, "Id", "Nombre", model?.CategoriaId);
        ViewBag.Monedas = new SelectList(monedas, "Id", "Nombre", model?.MonedaId);
    }
}
