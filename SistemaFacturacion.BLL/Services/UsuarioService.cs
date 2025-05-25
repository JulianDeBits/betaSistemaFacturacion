using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaFacturacion.BLL.Interfaces;
using SistemaFacturacion.DAL.Entities;
using SistemaFacturacion.DAL.Repositories;

namespace SistemaFacturacion.BLL.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioService(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<Usuario>> ObtenerTodosAsync()
        {
            return await _usuarioRepository.GetAllAsync();
        }

        public async Task<Usuario> ObtenerPorIdAsync(int id)
        {
            return await _usuarioRepository.GetByIdAsync(id);
        }


        public async Task<Usuario> ObtenerPorEmailAsync(string email)
        {
            return await _usuarioRepository.GetByEmailAsync(email);
        }

        public async Task AgregarAsync(Usuario usuario)
        {
            await _usuarioRepository.AddAsync(usuario);
        }

        public async Task ActualizarAsync(Usuario usuario)
        {
            await _usuarioRepository.Update(usuario);
        }

        public async Task EliminarAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario != null)
            {
                await _usuarioRepository.Delete(usuario);
            }
        }

        public async Task<IEnumerable<Usuario>> ObtenerTodosConGastosAsync()
        {
            return await _usuarioRepository.GetAllWithGastosAsync();
        }

        public async Task<bool> EmailExisteAsync(string email)
        {
            return await _usuarioRepository.EmailExistsAsync(email);
        }
    }
}
