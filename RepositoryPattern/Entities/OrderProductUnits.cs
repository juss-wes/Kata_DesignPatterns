using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Entities
{
    class OrderProductUnits : EntityBase
    {
        public Product Product { get; set; }
        public Order Order { get; set; }
        public int Units { get; set; }
    }
}
