using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaFacturacion.DAL.Entities;
using SistemaFacturacion.DAL.Repositorios;

namespace SistemaFacturacion.DAL.Repositories
{
    public class PresupuestoRepository : GenericRepository<Presupuesto>
    {
        public PresupuestoRepository(DbSistemaFacturacionContext context) : base(context)
        {
        }

        //Aqui se pueden agregar metodos especificos para el PresupuestoRepository
    }
}
