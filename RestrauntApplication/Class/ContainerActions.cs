using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using RestrauntApplication.Interface;
using RestrauntApplication.Class.OtherRestro;

namespace RestrauntApplication.Class
{
    class ContainerActions
    {
        public static void RegisterElements(IUnityContainer conatiner)
        {
            conatiner.RegisterType<IRestro, Haldirams>("1");
            conatiner.RegisterType<IRestro, BarbequeNation>("2");
            conatiner.RegisterType<IRestro, BurgerKing>("3");
        }
    }
}
