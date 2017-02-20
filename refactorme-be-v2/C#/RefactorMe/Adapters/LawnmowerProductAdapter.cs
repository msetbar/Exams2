using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefactorMe.DontRefactor.Models;
using RefactorMe.Interfaces;

namespace RefactorMe.Adapters
{
    public class LawnmowerProductAdapter : IProductAdapter<Lawnmower>
    {
        public Product Adapt(Lawnmower from)
        {
            return new Product()
            {
                Id = from.Id,
                Name = from.Name,
                Price = from.Price,
                Type = "Lawnmower"
            };
        }
    }
}
