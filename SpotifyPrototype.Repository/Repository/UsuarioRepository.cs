using SpotifyPrototype.Domain.Conta.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Repository.Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario>
    {
        public UsuarioRepository(SpotifyPrototypeContext context) : base(context) { }
    }
}
