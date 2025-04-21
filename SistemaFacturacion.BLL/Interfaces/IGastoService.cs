using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaFacturacion.DAL.Entities;

namespace SistemaFacturacion.BLL.Interfaces
{
    public interface IGastoService
    {
        Task<IEnumerable<Gasto>> ObtenerTodosAsync();
        Task<Gasto> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Gasto>> ObtenerPorUsuarioAsync(int usuarioId);
        Task AgregarAsync(Gasto gasto);
        Task ActualizarAsync(Gasto gasto);
        Task EliminarAsync(int id);
    }
}
