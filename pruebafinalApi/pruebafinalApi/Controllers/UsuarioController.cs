using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pruebafinalApi.Data.Repositories;
using pruebafinalApi.Model;

namespace pruebafinalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

       [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllUsuario()
        {
          /* var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            Console.WriteLine($"Token recibido: {token}");*/
            return Ok(await _usuarioRepository.GetAllUsuario());
        }

        //[Authorize]
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetUsuarioDetalil(int id)
        //{
        //    return Ok(await _usuarioRepository.GetUsuarioById(id));
        //}

        //[Authorize(Roles = "Admin")]
        //[HttpPost]
        //public async Task<IActionResult> CreateUsuario([FromBody] Usuario usuario)
        //{
        //    if (usuario == null)
        //    {
        //        return BadRequest("Datos de usuario inválidos.");
        //    }

        //    try
        //    {
        //        usuario.Password = BCrypt.Net.BCrypt.HashPassword(usuario.Password);
        //        var create = await _usuarioRepository.InsertUsuario(usuario);
        //        if (create)
        //        {
        //            return Created("created", true);
        //        }
        //        else
        //        {
        //            return StatusCode(500, "Ocurrió un error al crear el usuario.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error al crear usuario: {ex.Message}");
        //        return StatusCode(500, $"Error interno del servidor: {ex.Message}");
        //    }
        //}

        //[Authorize]
        //[HttpPut]
        //public async Task<IActionResult> UpdateUsuario([FromBody] Usuario usuario)
        //{
        //    if (usuario == null)
        //    {
        //        return BadRequest();
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    usuario.Password = BCrypt.Net.BCrypt.HashPassword(usuario.Password);
        //    await _usuarioRepository.UpdateUsuario(usuario);
        //    return NoContent();
        //}

        //[Authorize(Roles = "Admin")]
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteUsuario(int id)
        //{
        //    await _usuarioRepository.DeleteUsuario(new Usuario { Id = id });
        //    return NoContent();
        //}
    }
}
