using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaFacturacion.DAL.Entities;

namespace SistemaFacturacion.BLL.Interfaces
{
    public interface IMonedaService
    {
        Task<IEnumerable<Moneda>> ObtenerTodosAsync();
        Task<Moneda> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Moneda moneda);
        Task ActualizarAsync(Moneda moneda);
        Task EliminarAsync(int id);
    }
}
