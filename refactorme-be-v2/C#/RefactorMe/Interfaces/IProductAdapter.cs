using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefactorMe.DontRefactor.Models;

namespace RefactorMe.Interfaces
{
    public interface IProductAdapter<FromType>  
    {
        Product Adapt(FromType fromType); 
    }
}
