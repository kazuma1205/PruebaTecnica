using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Models;

namespace PruebaTecnica.Data
{
    public class UsuariosServices
    {
        private readonly AplicacionDbContext _context;

        public UsuariosServices(AplicacionDbContext context)
        {
            _context = context;
        }

        public async Task<List<Usuarios>> GetUsuariosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }
    }
}
