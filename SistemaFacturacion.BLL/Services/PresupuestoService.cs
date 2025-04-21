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
    public class PresupuestoService : IPresupuestoService
    {
        private readonly PresupuestoRepository _presupuestoRepository;

        public PresupuestoService(PresupuestoRepository presupuestoRepository)
        {
            _presupuestoRepository = presupuestoRepository;
        }

        public async Task<IEnumerable<Presupuesto>> ObtenerTodosAsync()
        {
            return await _presupuestoRepository.GetAllAsync();
        }

        public async Task<Presupuesto> ObtenerPorIdAsync(int id)
        {
            return await _presupuestoRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Presupuesto>> ObtenerPorUsuarioAsync(int usuarioId)
        {
            return await _presupuestoRepository.GetByConditionAsync(p => p.UsuarioId == usuarioId);
        }

        public async Task AgregarAsync(Presupuesto presupuesto)
        {
            await _presupuestoRepository.AddAsync(presupuesto);
        }

        public async Task ActualizarAsync(Presupuesto presupuesto)
        {
            _presupuestoRepository.Update(presupuesto);
        }

        public async Task EliminarAsync(int id)
        {
            var presupuesto = await _presupuestoRepository.GetByIdAsync(id);
            if (presupuesto != null)
            {
                _presupuestoRepository.Delete(presupuesto);
            }
        }
    }
}
