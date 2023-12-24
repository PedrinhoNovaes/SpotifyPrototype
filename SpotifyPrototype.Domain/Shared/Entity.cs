using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyPrototype.Domain.Shared
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public DateTime Creation { get; set; }
        public DateTime Update { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
            Creation = DateTime.UtcNow;
            Update = Creation;
        }
    }
}