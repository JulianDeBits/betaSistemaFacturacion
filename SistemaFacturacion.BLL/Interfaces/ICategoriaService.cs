using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using SistemaFacturacion.DAL.Entities;

namespace SistemaFacturacion.BLL.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<Categoria>> ObtenerTodosAsync();
        Task<Categoria?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Categoria categoria);
        Task ActualizarAsync(Categoria categoria);
        Task EliminarAsync(int id);
    }
}
