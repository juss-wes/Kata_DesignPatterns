using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Entities
{
    public abstract class EntityBase
    {
        public int ID { get; protected set; }
    }
}
