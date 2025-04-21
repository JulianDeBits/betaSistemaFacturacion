using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaFacturacion.DAL.Entities;
using SistemaFacturacion.DAL.Repositories;
using SistemaFacturacion.DAL.Repositorios;

namespace SistemaFacturacion.DAL.Repositories
{
    public class GastoRepository : GenericRepository<Gasto>
    {
        public GastoRepository(DbSistemaFacturacionContext context) : base(context)
        {
        }
        // Aquí se pueden agregar métodos específicos para la entidad Gasto si es necesario
    }
}
