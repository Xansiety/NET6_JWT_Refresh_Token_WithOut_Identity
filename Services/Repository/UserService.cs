using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NET6_WEB_API_TEMPLATE_JWT.DTOs;
using NET6_WEB_API_TEMPLATE_JWT.Entities.User;
using NET6_WEB_API_TEMPLATE_JWT.Helpers.AuthTools;
using NET6_WEB_API_TEMPLATE_JWT.Services.Interfaces;

namespace NET6_WEB_API_TEMPLATE_JWT.Services.Repository
{
    public class UserService : IUserService
    { 
        private readonly ApplicationDbContext _context; 
        public UserService(IConfiguration configuration, ApplicationDbContext context)
        { 
            _context = context; 
        }


        public async Task<string> RegisterAsync(RegisterDTO registerDto)
        {
            //Asignación información del usuario
            var usuario = new Usuario
            {
                Nombres = registerDto.Nombres,
                ApellidoMaterno = registerDto.ApellidoMaterno,
                ApellidoPaterno = registerDto.ApellidoPaterno,
                Email = registerDto.Email,
                UserName = registerDto.Username,
                Password = registerDto.Password 
            };

            //Validar Usuario existe username en DB
            var usuarioExiste =  await _context.Usuarios.Where(x => x.Email.ToLower() == registerDto.Email.ToLower()).FirstOrDefaultAsync();

            if (usuarioExiste == null)
            {
                //buscamos el rol predeterminado
                var rolPredeterminado = await _context.Roles
                                        .Where(u => u.Nombre == Autorizacion.rol_predeterminado.ToString())
                                        .FirstAsync();
                try
                {
                    //agregamos el rol de la colección
                    usuario.Roles.Add(rolPredeterminado);
                    _context.Usuarios.Add(usuario);
                    await _context.SaveChangesAsync();

                    return $"El usuario {registerDto.Username} ha sido registrado exitosamente";
                }
                catch (Exception ex)
                {
                    var message = ex.Message;
                    return $"Error: {message}";
                }
            }
            else
            {
                return $"El usuario con {registerDto.Username} ya se encuentra registrado.";
            }
        }


        public async Task<Usuario> ValidateUserAync(UserCredentials userCredentials)
        {
            return await _context.Usuarios
                .Include(x => x.Roles)
                .Where(x => x.Email == userCredentials.Email && x.Password == userCredentials.Password && x.Activo).FirstOrDefaultAsync();
             
        }

        public async Task<Usuario> GetByRefreshTokenAsync(string refreshToken)
        {
            return await _context.Usuarios
                .Include(u => u.Roles) 
                .FirstOrDefaultAsync(u => u.RefreshToken != null);
        }

        public async Task<Usuario> GetByUserNameAsync(string username)
        {
            return await _context.Usuarios
                .Include(u => u.Roles) 
                .FirstOrDefaultAsync(u => u.UserName.ToLower() == username.ToLower());
        }

    }
}
