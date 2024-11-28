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
        //buscar usuario por ID
        public async Task<Usuarios> ObtenerUsuarioPorNombreAsync(int id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.UsuarioID == id);
        }
        //validar Usuario
        public async Task<bool> ValidateCredentialsAsync(string username, string password)
        {
            try
            {
                var user = await _context.Usuarios
                    .FirstOrDefaultAsync(u => u.Email == username && u.Contraseña == password);

                return user != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al validar credenciales: {ex.Message}");
                return false;
            }
        }
    }
}
