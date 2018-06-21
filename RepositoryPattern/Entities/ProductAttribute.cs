using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Entities
{
    class ProductAttribute : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public Product Product { get; set; }
    }
}
