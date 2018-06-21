using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Entities
{
    class Order : EntityBase
    {
        public string InvoiceNumber { get; set; }
        public IList<OrderProductUnits> Items { get; set; }
        public Customer Customer { get; set; }

        public Order()
        {
            Items = new List<OrderProductUnits>();
        }
    }
}
