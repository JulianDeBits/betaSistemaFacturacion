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
    public class CategoriaService : ICategoriaService
    {
        private readonly CategoriaRepository _categoriaRepository;

        public CategoriaService(CategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<IEnumerable<Categoria>> ObtenerTodosAsync()
        {
            return await _categoriaRepository.GetAllAsync();
        }

        public async Task<Categoria?> ObtenerPorIdAsync(int id)
        {
            return await _categoriaRepository.GetByIdAsync(id);
        }

        public async Task AgregarAsync(Categoria categoria)
        {
            await _categoriaRepository.AddAsync(categoria);
        }

        public async Task ActualizarAsync(Categoria categoria)
        {
            _categoriaRepository.Update(categoria);
            await Task.CompletedTask; // para cumplir con la firma async si no se guarda aquí
        }

        public async Task EliminarAsync(int id)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(id);
            if (categoria != null)
            {
                _categoriaRepository.Delete(categoria);
            }
        }
    }
}
