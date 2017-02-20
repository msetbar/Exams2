using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefactorMe.Adapters;
using RefactorMe.DontRefactor.Models;
using RefactorMe.Interfaces;

namespace RefactorMe.Factories
{
    public class AdapterFactory
    {
        public static IProductAdapter<FromType> GetAdapter<FromType>()
        {
            if (typeof(FromType) == typeof(Lawnmower))
                return (IProductAdapter<FromType>)new LawnmowerProductAdapter();

            if (typeof(FromType) == typeof(TShirt))
                return (IProductAdapter<FromType>)new TShirtProductAdapter();

            return (IProductAdapter<FromType>)new PhoneCaseProductAdapter();
        }
    }
}