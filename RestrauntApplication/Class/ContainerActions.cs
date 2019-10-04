using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using RestrauntApplication.Interface;
using RestrauntApplication.Class.OtherRestro;
using Unity.Lifetime;

namespace RestrauntApplication.Class
{
    class ContainerActions
    {
        public static void RegisterElements(IUnityContainer conatiner)
        {
            conatiner.RegisterType<IRestro, Haldirams>("1",new ContainerControlledLifetimeManager());
            conatiner.RegisterType<IRestro, BarbequeNation>("2", new ContainerControlledLifetimeManager());
            conatiner.RegisterType<IRestro, BurgerKing>("3", new ContainerControlledLifetimeManager());
            conatiner.RegisterType<IRestro, Dominos>("4", new ContainerControlledLifetimeManager());
        }
    }
}
