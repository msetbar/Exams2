using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefactorMe.DontRefactor.Models;
using RefactorMe.Interfaces;

namespace RefactorMe.Models
{
    public class ProductEx : Product
    {
        IProductCurrencyManager productCurrencyManager;

        public ProductEx(Product product, IProductCurrencyManager productCurrencyManager )
        {
            this.Id = product.Id;
            this.Name = product.Name;
            base.Price = product.Price;
            this.Type = product.Type;

            this.productCurrencyManager = productCurrencyManager;
        }

        public double Price
        {
            get
            {
                return base.Price * productCurrencyManager.Rate;
            }
        }
    }
}
