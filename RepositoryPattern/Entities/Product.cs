using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Entities
{
    class Product : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double UnitPrice { get; set; }
        public IList<OrderProductUnits> OrderProductUnits { get; set; }
        public IList<ProductAttribute> Attributes { get; set; }

        public Product()
        {
            OrderProductUnits = new List<OrderProductUnits>();
            Attributes = new List<ProductAttribute>();
        }
    }
}
