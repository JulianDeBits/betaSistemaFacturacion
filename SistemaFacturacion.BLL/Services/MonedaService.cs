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
    public class MonedaService : IMonedaService
    {
        private readonly MonedaRepository _monedaRepository;

        public MonedaService(MonedaRepository monedaRepository)
        {
            _monedaRepository = monedaRepository;
        }

        public async Task<IEnumerable<Moneda>> ObtenerTodosAsync()
        {
            return await _monedaRepository.GetAllAsync();
        }

        public async Task<Moneda> ObtenerPorIdAsync(int id)
        {
            return await _monedaRepository.GetByIdAsync(id);
        }

        public async Task AgregarAsync(Moneda moneda)
        {
            await _monedaRepository.AddAsync(moneda);
        }

        public async Task ActualizarAsync(Moneda moneda)
        {
            _monedaRepository.Update(moneda);
        }

        public async Task EliminarAsync(int id)
        {
            var moneda = await _monedaRepository.GetByIdAsync(id);
            if (moneda != null)
            {
                _monedaRepository.Delete(moneda);
            }
        }
    }
}
