using Dapper;
using Microsoft.Extensions.Options;
using SpotifyPrototype.STS.Model;
using System.Data.SqlClient;

namespace SpotifyPrototype.STS.Data
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly string connectionString;

        public IdentityRepository(IOptions<DataBaseOption> dataBaseOption)
        {
            connectionString = dataBaseOption.Value.SpotifyPrototypeConnection;
        }

        public async Task<Usuario> FindByIdAsync(Guid id)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var user = await connection.QueryFirstOrDefaultAsync<Usuario>(IdentityQuery.FindById(), new
                {
                    id = id,
                });

                return user;
            }
        }

        public async Task<Usuario> FindByEmailAndPasswordAsync(string email, string senha)
        {
            {
                using (var connection = new SqlConnection(this.connectionString))
                {
                    var user = await connection.QueryFirstOrDefaultAsync<Usuario>(IdentityQuery.FindByEmailAndPassword(), new
                    {
                        email = email,
                        senha = senha
                    });

                    return user;
                }
            }
        }
    }

    public static class IdentityQuery
    {
        public static String FindById() =>
            @"SELECT ID, NOME, EMAIL FROM USUARIO WHERE ID = @ID";

        public static String FindByEmailAndPassword() =>
            @"SELECT ID, NOME, EMAIL FROM USUARIO WHERE EMAIL = @EMAIL AND SENHA = @SENHA";
    }
}
