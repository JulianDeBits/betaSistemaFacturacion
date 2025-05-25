using Microsoft.AspNetCore.Mvc;
using SistemaFacturacion.BLL.Interfaces;
using SistemaFacturacion.DAL.Entities;
using SistemaFacturacion.API.Models;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(UsuarioViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        if (string.IsNullOrWhiteSpace(model.Password))
        {
            ModelState.AddModelError("Password", "La contraseña es obligatoria.");
            return View(model);
        }

        var passwordHash = HashPassword(model.Password);

        var nuevoUsuario = new Usuario
        {
            Nombre = model.Nombre,
            Email = model.Email,
            PasswordHash = passwordHash,
            FechaRegistro = DateTime.Now
        };

        await _usuarioService.AgregarAsync(nuevoUsuario);

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
            FechaRegistro = usuario.FechaRegistro
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UsuarioViewModel model)
    {

        if (string.IsNullOrWhiteSpace(model.Password))
        {
            ModelState.Remove(nameof(model.Password));
        }

        if (!ModelState.IsValid)
        {
            foreach (var kvp in ModelState)
            {
                foreach (var error in kvp.Value.Errors)
                {
                    Console.WriteLine($"  Campo: {kvp.Key} - Error: {error.ErrorMessage}");
                }
            }
            return View(model);
        }

        var usuario = await _usuarioService.ObtenerPorIdAsync(model.Id);
        if (usuario == null)
        {
            return NotFound();
        }

        usuario.Nombre = model.Nombre;
        usuario.Email = model.Email;

        if (!string.IsNullOrWhiteSpace(model.Password))
        {
            usuario.PasswordHash = HashPassword(model.Password);
        }

        try
        {
            await _usuarioService.ActualizarAsync(usuario);
        }
        catch (Exception ex)
        {
            if (ex.InnerException != null)

            ModelState.AddModelError(string.Empty, "Error interno al actualizar usuario.");
            return View(model);
        }

        return RedirectToAction("Index");
    }



    public async Task<IActionResult> Delete(int id)
    {
        var usuario = await _usuarioService.ObtenerPorIdAsync(id);
        if (usuario == null) return NotFound();

        return View(new UsuarioViewModel
        {
            Id = usuario.Id,
            Nombre = usuario.Nombre,
            Email = usuario.Email
        });
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _usuarioService.EliminarAsync(id);
        return RedirectToAction("Index");
    }

    private string HashPassword(string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            Console.WriteLine("La contraseña enviada es invalida");
        }

        using (var sha256 = SHA256.Create())
        {
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }

}
