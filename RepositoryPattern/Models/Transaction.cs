using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Models
{
    public class Transaction
    {
        public string RecordId { get; set; }
        public string Location { get; set; }
        public string Product { get; set; }
        public string Customer { get; set; }
        public double Volume { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
