using SpotifyPrototype.Domain.Admin.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Repository.Repository.Admin
{
    public class UsuarioAdminRepository : RepositoryBase<UsuarioAdmin>
    {
        public UsuarioAdminRepository(SpotifyPrototypeAdminContext context) : base(context) { }

        public UsuarioAdmin? GetByEmailSenha(String Email, String Senha)
        {
            return this.Find(x => x.Email == Email && x.Senha == Senha).FirstOrDefault();
        }
    }
}
