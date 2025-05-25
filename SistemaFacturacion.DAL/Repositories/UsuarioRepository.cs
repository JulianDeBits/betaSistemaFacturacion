using Microsoft.EntityFrameworkCore;
using SistemaFacturacion.DAL.Entities;
using SistemaFacturacion.DAL.Repositorios;

namespace SistemaFacturacion.DAL.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>
    {

        private readonly DbSistemaFacturacionContext _context;  

        public UsuarioRepository(DbSistemaFacturacionContext context) : base(context)
        {
            
        }

        public async Task<Usuario> GetByEmailAsync(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Usuarios.AnyAsync(u => u.Email == email);
        }

        public async Task<IEnumerable<Usuario>> GetAllWithGastosAsync()
        {
            return await _context.Usuarios
                .Include(u => u.Gastos) // Incluir los gastos relacionados
                .ToListAsync();
        }
    }
}
