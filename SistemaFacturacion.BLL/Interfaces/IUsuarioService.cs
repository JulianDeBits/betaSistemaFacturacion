using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaFacturacion.DAL.Entities;

namespace SistemaFacturacion.BLL.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> ObtenerTodosAsync();
        Task<Usuario> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Usuario usuario);
        Task ActualizarAsync(Usuario usuario);
        Task EliminarAsync(int id);
    }
}
