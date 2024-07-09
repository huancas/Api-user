using BCrypt.Net;
using Dapper;
using Npgsql;
using pruebafinalApi.Data.Repositories;
using pruebafinalApi.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebafinalApi.Data
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private PostgreConfig _connectionString;

        public UsuarioRepository(PostgreConfig connectionString)
        {
            _connectionString = connectionString;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectString);
        }





        public async Task<bool> DeleteUsuario(Usuario usuario)
        {
            var db = dbConnection();
            var sql = @"
                Delete 
                FROM public.""Usuarios""
                WHERE id=@Id
                ";
            var result = await db.ExecuteAsync(sql, new { usuario.Id });
            return result > 0;

        }

        public async Task<IEnumerable<Usuario>> GetAllUsuario()
        {
            var db = dbConnection();
            var sql = @"
                SELECT id, name, description, username, password, createdate, lastupdate, idprofile
                FROM public.""Usuarios""

                ";
            return await db.QueryAsync<Usuario>(sql, new {});
        }

        public async Task<Usuario> GetUsuarioById(int id)
        {
            var db = dbConnection();
            var sql = @"
                SELECT id, name, description, username, password, createdate, lastupdate as updateDate, idprofile
                FROM public.""Usuarios""
                WHERE id=@id
                ";
            return await db.QueryFirstOrDefaultAsync<Usuario>(sql, new { Id=id });
        }



        public async Task<bool> InsertUsuario(Usuario usuario)
        {
            try
            {
                usuario.Password = BCrypt.Net.BCrypt.HashPassword(usuario.Password);
                usuario.CreateDate = DateTime.UtcNow.ToString();
                usuario.UpdateDate = DateTime.UtcNow.ToString();

                using var db = dbConnection();
                var sql = @"
            INSERT INTO public.""Usuarios""(
                name, description, username, password, createdate, lastupdate, idprofile)
            VALUES (@Name, @Description, @UserName, @Password, @CreateDate, @UpdateDate, @IdProfile);
        ";

                var result = await db.ExecuteAsync(sql, new
                {
                    usuario.Name,
                    usuario.Description,
                    usuario.UserName,
                    usuario.Password,
                    usuario.CreateDate,
                    usuario.UpdateDate,
                    usuario.IdProfile
                });

                return result > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public async Task<bool> UpdateUsuario(Usuario usuario)
        {
            var db = dbConnection();
            var sql = @"
                update  public.""Usuarios""
                SET  
                    name=@Name, 
                    description=@Description, 
                    username=@UserName, 
                    password=@Password, 
                    lastupdate=@UpdateDate, 
                    idprofile=@IdProfile
                 WHERE id=@Id
	         
                ";
            var result = await db.ExecuteAsync(sql, new { usuario.Name, usuario.Description, usuario.UserName, usuario.Password, usuario.UpdateDate, usuario.IdProfile, usuario.Id });
            return result > 0;
        }




        public async Task<bool> Session(Login login)
        {
            try
            {
                using var db = dbConnection();
                var sql = @"
                    SELECT COUNT(*)
                    FROM public.""Usuarios""
                    WHERE username = @UserName AND password = @Password;
                ";

                var result = await db.ExecuteScalarAsync<int>(sql, new { login.UserName, login.Password });

                return result > 0;
            }
            catch (Exception ex)
            {
 
                return false;
            }
        }

    
    }
}
