using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringPogram.Data.Loaders;
using FlooringPogram.Data.Mocks;
using FlooringProgram.Models.Interfaces;
using Ninject;
using Ninject.Modules;

namespace FlooringProgram.Operations
{
   public class FlooringProgramTestModule : NinjectModule
    {
               public override void Load()//Method name matter here?
        {
            Bind<ITaxRateRepository>().To<TaxRateRepositoryMock>();
            Bind<IProductRepository>().To<ProductRepositoryMock>();
            Bind<IOrderRepository>().To<TestOrderRepository>();
        }
    }
    
}
