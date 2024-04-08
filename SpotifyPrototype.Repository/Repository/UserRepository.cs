using SpotifyPrototype.Domain.Account.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Repository.Repository
{
    public class UserRepository : RepositoryBase<User>
    {
        public SpotifyPrototypeContext Context { get; set; }

        public UserRepository(SpotifyPrototypeContext context) : base(context)
        {
            Context = context;
        }
    }
}
