using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using pruebafinalApi.Data.Repositories;
using pruebafinalApi.Model;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Claims;
using System.Text;

namespace pruebafinalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SesionController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IConfiguration _configuration;

        public SesionController(IUsuarioRepository usuarioRepository, IConfiguration configuration)
        {
            _usuarioRepository = usuarioRepository;
            _configuration = configuration;
        }

       /* [HttpPost]
        public async Task<IActionResult> Access([FromBody] Login loginRequest)
        {
            if (loginRequest == null || string.IsNullOrEmpty(loginRequest.UserName) || string.IsNullOrEmpty(loginRequest.Password))
            {
                return BadRequest("Invalid client request");
            }

            var login = await _usuarioRepository.Session(loginRequest);
            if (login)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                 {
                    new Claim(ClaimTypes.Name, loginRequest.UserName)
                 }),
                    Expires = DateTime.UtcNow.AddHours(1),

                    Issuer = _configuration["Jwt:Issuer"],  // Asegúrate de que esté configurado
                    Audience = _configuration["Jwt:Audience"], // Asegúrate de que esté configurado
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    
                };
               /* var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);*/
               

               // Console.WriteLine("Token string:" + tokenString);

             /*   var token = tokenHandler.CreateEncodedJwt(tokenDescriptor);
                return Ok(new { Token = token });

               // return Ok(new { Token = tokenString });
                //return Ok(tokenString );
            }
            else
            {
                return Unauthorized("Invalid username or password.");
            }
        }*/
        public async Task<IActionResult> Access([FromBody] Login loginRequest)
        {
            if (loginRequest == null || string.IsNullOrEmpty(loginRequest.UserName) || string.IsNullOrEmpty(loginRequest.Password))
            {
                return BadRequest("Invalid client request");
            }

            var login = await _usuarioRepository.Session(loginRequest);
            if (login)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                new Claim(ClaimTypes.Name, loginRequest.UserName)
                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    Issuer = _configuration["Jwt:Issuer"],
                    Audience = _configuration["Jwt:Audience"],
                    SigningCredentials = credentials //new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
               
            };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                Console.WriteLine("Token string:" + tokenString);

                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized("Invalid username or password.");
            }
        }
    }
}
