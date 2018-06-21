using RepositoryPattern.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RepositoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new Ctx();
            var productIds = new[] { 1, 41, 64 };
            var products = ctx.Products
                                .Include(product => product.Attributes)
                                .Where(product => productIds.Contains(product.ID))
                                .ToList();
            var customer = new Customer { Name = "John Smith" };
            ctx.Customers.Add(customer);

            var order = new Order();
            var orderItems = products.Select(product => new OrderProductUnits { Product = product, Units = 4 }).ToList();
            foreach (var item in orderItems)
            {
                order.Items.Add(item);
            }
            
        }
    }
}
