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
    public class GastoService : IGastoService
    {
        private readonly GastoRepository _gastoRepository;
        public GastoService(GastoRepository gastoRepository)
        {
            _gastoRepository = gastoRepository;
        }
        public async Task<IEnumerable<Gasto>> ObtenerTodosAsync()
        {
            return await _gastoRepository.GetAllAsync();
        }
        public async Task<Gasto> ObtenerPorIdAsync(int id)
        {
            return await _gastoRepository.GetByIdAsync(id);
        }
        public async Task<IEnumerable<Gasto>> ObtenerPorUsuarioAsync(int
       usuarioId)
        {
            return await _gastoRepository.GetByConditionAsync(g => g.UsuarioId ==
           usuarioId);
        }
        public async Task AgregarAsync(Gasto gasto)
        {
            await _gastoRepository.AddAsync(gasto);
        }
        public async Task ActualizarAsync(Gasto gasto)
        {
            _gastoRepository.Update(gasto);
        }
        public async Task EliminarAsync(int id)
        {
            var gasto = await _gastoRepository.GetByIdAsync(id);
            if (gasto != null)
            {
                _gastoRepository.Delete(gasto);
            }
        }
    }
}
