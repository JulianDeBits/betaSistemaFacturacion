using Microsoft.AspNetCore.Mvc;
using SistemaFacturacion.BLL.Interfaces;
using SistemaFacturacion.DAL.Entities;
using SistemaFacturacion.API.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using System.Linq;

public class PresupuestoController : Controller
{
    private readonly IPresupuestoService _presupuestoService;
    private readonly IUsuarioService _usuarioService;
    private readonly ICategoriaService _categoriaService;
    private readonly IMonedaService _monedaService;

    public PresupuestoController(IPresupuestoService presupuestoService, IUsuarioService usuarioService, ICategoriaService categoriaService, IMonedaService monedaService)
    {
        _presupuestoService = presupuestoService;
        _usuarioService = usuarioService;
        _categoriaService = categoriaService;
        _monedaService = monedaService;
    }

    public async Task<IActionResult> Index()
    {
        var presupuestos = await _presupuestoService.ObtenerTodosAsync();
        var usuarios = await _usuarioService.ObtenerTodosAsync();
        var categorias = await _categoriaService.ObtenerTodosAsync();
        var monedas = await _monedaService.ObtenerTodosAsync();

        var viewModel = presupuestos.Select(p => new PresupuestoViewModel
        {
            Id = p.Id,
            UsuarioId = p.UsuarioId,
            UsuarioNombre = usuarios.FirstOrDefault(u => u.Id == p.UsuarioId)?.Nombre,
            CategoriaId = p.CategoriaId,
            CategoriaNombre = categorias.FirstOrDefault(u => u.Id == p.CategoriaId)?.Nombre,
            MonedaId = p.MonedaId,
            MonedaNombre = monedas.FirstOrDefault(u => u.Id == p.MonedaId)?.Nombre,
            Limite = p.Limite,
            FechaInicio = p.FechaInicio,
            FechaFin = p.FechaFin
        });
        return View(viewModel);
    }

    public async Task<IActionResult> Create()
    {
        var model = new PresupuestoViewModel();
        await CargarListasDesplegables(model);
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Create(PresupuestoViewModel model)
    {
        if (!ModelState.IsValid)
        {
            await CargarListasDesplegables(model);
            return View(model);
        }

        var presupuesto = new Presupuesto
        {
            UsuarioId = model.UsuarioId.Value,
            CategoriaId = model.CategoriaId.Value,
            MonedaId = model.MonedaId.Value,
            Limite = model.Limite,
            FechaInicio = model.FechaInicio,
            FechaFin = model.FechaFin
        };

        await _presupuestoService.AgregarAsync(presupuesto);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(int id)
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

        await CargarListasDesplegables(model);
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(PresupuestoViewModel model)
    {
        ModelState.Remove("UsuarioNombre");
        ModelState.Remove("CategoriaNombre");
        ModelState.Remove("MonedaNombre");

        var usuarioExiste = await _usuarioService.ObtenerPorIdAsync(model.UsuarioId ?? 0) != null;
        var categoriaExiste = await _categoriaService.ObtenerPorIdAsync(model.CategoriaId ?? 0) != null;
        var monedaExiste = await _monedaService.ObtenerPorIdAsync(model.MonedaId ?? 0) != null;

        if (!ModelState.IsValid)
        {
            await CargarListasDesplegables(model);
            return View(model);
        }

        var presupuesto = new Presupuesto
        {
            Id = model.Id,
            UsuarioId = model.UsuarioId.Value,
            CategoriaId = model.CategoriaId.Value,
            MonedaId = model.MonedaId.Value,
            Limite = model.Limite,
            FechaInicio = model.FechaInicio,
            FechaFin = model.FechaFin
        };

        try
        {
            await _presupuestoService.ActualizarAsync(presupuesto);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", $"Error al actualizar el presupuesto: {ex.Message}");
            await CargarListasDesplegables(model);
            return View(model);
        }

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int id)
    {
        var presupuesto = await _presupuestoService.ObtenerPorIdAsync(id);
        if (presupuesto == null) return NotFound();

        var usuario = await _usuarioService.ObtenerPorIdAsync(presupuesto.UsuarioId);
        var categoria = await _categoriaService.ObtenerPorIdAsync(presupuesto.CategoriaId);
        var moneda = await _monedaService.ObtenerPorIdAsync(presupuesto.MonedaId);

        var model = new PresupuestoViewModel
        {
            Id = presupuesto.Id,
            UsuarioId = presupuesto.UsuarioId,
            UsuarioNombre = usuario?.Nombre,
            CategoriaId = presupuesto.CategoriaId,
            CategoriaNombre = categoria?.Nombre,
            MonedaId = presupuesto.MonedaId,
            MonedaNombre = moneda?.Nombre,
            Limite = presupuesto.Limite,
            FechaInicio = presupuesto.FechaInicio,
            FechaFin = presupuesto.FechaFin
        };

        return View(model);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _presupuestoService.EliminarAsync(id);
        return RedirectToAction("Index");
    }

    private async Task CargarListasDesplegables(PresupuestoViewModel model)
    {
        var usuarios = await _usuarioService.ObtenerTodosAsync();
        var categorias = await _categoriaService.ObtenerTodosAsync();
        var monedas = await _monedaService.ObtenerTodosAsync();

        ViewBag.Usuarios = new SelectList(usuarios, "Id", "Nombre", model?.UsuarioId);
        ViewBag.Categorias = new SelectList(categorias, "Id", "Nombre", model?.CategoriaId);
        ViewBag.Monedas = new SelectList(monedas, "Id", "Nombre", model?.MonedaId);
    }
}

