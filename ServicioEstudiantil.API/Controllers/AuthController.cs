using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ServicioEstudiantil.Core.DTOs;

namespace ServicioEstudiantil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        // Inyectamos IConfiguration para poder leer la llave secreta del appsettings.json
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Validación simulada. (En el futuro, aquí harías un query a tu tabla Usuarios)
            if (request.Correo == "admin@unicda.edu.do" && request.Password == "Wilmer2005")
            {
                var token = GenerarToken(request.Correo);
                return Ok(new { Token = token }); // Devolvemos el token en un formato JSON
            }

            return Unauthorized(new { Mensaje = "Credenciales incorrectas" });
        }

        private string GenerarToken(string correo)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]!);

            // Los "Claims" son las credenciales del usuario que viajan dentro del token encriptado
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, correo),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // ID único del token
                new Claim(ClaimTypes.Role, "Administrador") // Le asignamos un rol
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(2), // El token será válido por 2 horas
                Issuer = jwtSettings["Issuer"],
                Audience = jwtSettings["Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}