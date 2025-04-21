using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaFacturacion.DAL.Entities;

namespace SistemaFacturacion.BLL.Interfaces
{
    public interface IPresupuestoService
    {
        Task<IEnumerable<Presupuesto>> ObtenerTodosAsync();
        Task<Presupuesto> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Presupuesto>> ObtenerPorUsuarioAsync(int usuarioId);
        Task AgregarAsync(Presupuesto presupuesto);
        Task ActualizarAsync(Presupuesto presupuesto);
        Task EliminarAsync(int id);
    }
}
