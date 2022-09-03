using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NET6_WEB_API_TEMPLATE_JWT.DTOs;
using NET6_WEB_API_TEMPLATE_JWT.Entities.User;
using NET6_WEB_API_TEMPLATE_JWT.Helpers.AuthTools;
using NET6_WEB_API_TEMPLATE_JWT.Services.Interfaces;
using System.Security.Claims;

namespace NET6_WEB_API_TEMPLATE_JWT.Services.Repository
{
    public class UserService : IUserService
    { 
        private readonly ApplicationDbContext _context;
        private readonly HttpContext httpContext;

        public UserService(IConfiguration configuration, ApplicationDbContext context, IHttpContextAccessor httpContextAccessor/*Este método esta configurado en program*/)
        { 
            _context = context;
            httpContext = httpContextAccessor.HttpContext;
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



        public int ObtenerUsuarioId()
        {
            if (httpContext.User.Identity.IsAuthenticated)
            {
                var idClaim = httpContext.User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault();
                var id = int.Parse(idClaim.Value);
                return id;
            }
            else
            {
                throw new ApplicationException("El usuario no esta autenticado");
            }
        }


        public async Task revokeRefreshToken() 
        { 
            var usuario = await _context.Usuarios.Where(x => x.Id == 2).FirstOrDefaultAsync();
            usuario.RefreshToken = null;
            usuario.CreatedRefreshToken = null;
            usuario.ExpireTimeRefreshToken = null;
            _context.Usuarios.Update(usuario);
           await _context.SaveChangesAsync();

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
