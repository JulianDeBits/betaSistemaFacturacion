using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaFacturacion.DAL.Entities;
using SistemaFacturacion.DAL.Repositorios;

namespace SistemaFacturacion.DAL.Repositories
{
    public class MonedaRepository : GenericRepository<Moneda>
    {
        public MonedaRepository(DbSistemaFacturacionContext context) : base(context)
        {
        }
        // Aquí se pueden agregar métodos específicos para la entidad Moneda si es necesario
    }
}
