using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pruebafinalApi.Model;

namespace pruebafinalApi.Data.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAllUsuario();
        Task<Usuario> GetUsuarioById(int id);
        Task<bool> InsertUsuario(Usuario usuario);
        Task<bool> UpdateUsuario(Usuario usuario);
        Task<bool> DeleteUsuario(Usuario usuario);
        Task<bool> Session(Login login);
    }
}
