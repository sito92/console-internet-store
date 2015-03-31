using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarAndHorseStore.Core.CommandParser;
using CarAndHorseStore.Core.CommandParser.Abstract;
using CarAndHorseStore.Core.System;
using CarAndHorseStore.Core.System.Abstract;
using CarAndHorseStore.Domain.Models;
using CarAndHorseStore.Domain.Repository;
using CarAndHorseStore.Domain.Repository.Interfaces;
using Ninject;

namespace CarAndHorseStore.Infrastructure
{
    public class NinjectContainer
    {
        private IKernel ninjectKernel;

        public NinjectContainer()
        {
            ninjectKernel = new StandardKernel();
            InitializeBindings();
        }

        public T Get<T>()
        {
            return ninjectKernel.Get<T>();
        }
        private void InitializeBindings()
        {
            ninjectKernel.Bind<IProductRepository>().To<ProductRepository>();
            ninjectKernel.Bind<IUserBaseRepository>().To<UserBaseRepository>();
            ninjectKernel.Bind<IStoreSystem>().To<StoreSystem>();
            ninjectKernel.Bind<ICommandParser>().To<CommandParser>();
        }
    }
}
