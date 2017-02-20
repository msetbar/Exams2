using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefactorMe.DontRefactor.Data.Implementation;
using RefactorMe.DontRefactor.Models;
using RefactorMe.Models;

namespace RefactorMe.Interfaces
{
    public interface IProductConsolidator
    {
        List<ProductEx> Consolidate<TProductType>(IQueryable<TProductType> products) where TProductType : class;
        List<ProductEx> GetAll();

    }
}
