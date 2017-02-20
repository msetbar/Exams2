using RefactorMe.DontRefactor.Data.Implementation;
using RefactorMe.DontRefactor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefactorMe.Interfaces;
using RefactorMe.Models;
using RefactorMe.Factories;

namespace RefactorMe
{
    public class ProductDataConsolidator : IProductConsolidator, IProductCurrencyManager
    {
        private List<ProductEx> consolidatedProducts;

        public ProductDataConsolidator(double rate = 1 )
        {
            consolidatedProducts = new List<ProductEx>();
            Rate = rate;
        }

       

        public List<ProductEx> GetAll()
        {
            return consolidatedProducts;
        }

        public double Rate { get; set; }


        public List<ProductEx> Consolidate<TProductType>(IQueryable<TProductType> products) where TProductType : class 
        {
            var adapter = AdapterFactory.GetAdapter<TProductType>();

            products.ToList().ForEach(
                p => consolidatedProducts.Add(new ProductEx(adapter.Adapt(p), this)));

            return consolidatedProducts;
        }
    }
}
