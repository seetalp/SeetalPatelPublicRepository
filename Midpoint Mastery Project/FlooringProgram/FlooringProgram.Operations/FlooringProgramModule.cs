using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringPogram.Data.Loaders;
using FlooringProgram.Models.Interfaces;
using Ninject;
using Ninject.Modules;//Need this in order to inherit Ninject 

namespace FlooringProgram.Operations
{
    public class FlooringProgramModule: NinjectModule
    {
        public override void Load()
        {
            Bind<ITaxRateRepository>().To<TaxLoader>();
            Bind<IProductRepository>().To<ProductLoader>();
            Bind<IOrderRepository>().To<OrderRepository>();
        }
    }
}
