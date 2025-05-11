using Microsoft.AspNetCore.Mvc;
using SistemaFacturacion.BLL.Interfaces;
using SistemaFacturacion.DAL.Entities;

public class UsuarioController : Controller
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    public async Task<IActionResult> Index()
    {
        var usuarios = await _usuarioService.ObtenerTodosAsync();
        return View(usuarios.Select(u => new UsuarioViewModel
        {
            Id = u.Id,
            Nombre = u.Nombre,
            Email = u.Email,
            FechaRegistro = u.FechaRegistro
        }));
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(UsuarioViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        await _usuarioService.AgregarAsync(new Usuario
        {
            Nombre = model.Nombre,
            Email = model.Email,
            PasswordHash = model.PasswordHash,
            FechaRegistro = DateTime.Now
        });

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(int id)
    {
        var usuario = await _usuarioService.ObtenerPorIdAsync(id);
        if (usuario == null) return NotFound();

        return View(new UsuarioViewModel
        {
            Id = usuario.Id,
            Nombre = usuario.Nombre,
            Email = usuario.Email,
            PasswordHash = usuario.PasswordHash
        });
    }

    [HttpPost]
    public async Task<IActionResult> Edit(UsuarioViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        await _usuarioService.ActualizarAsync(new Usuario
        {
            Id = model.Id,
            Nombre = model.Nombre,
            Email = model.Email,
            PasswordHash = model.PasswordHash
        });

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int id)
    {
        var usuario = await _usuarioService.ObtenerPorIdAsync(id);
        if (usuario == null) return NotFound();
        return View(usuario);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _usuarioService.EliminarAsync(id);
        return RedirectToAction("Index");
    }
}
