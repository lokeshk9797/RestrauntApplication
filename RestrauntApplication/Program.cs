using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestrauntApplication.Model.BaseRestro;
using RestrauntApplication.Class.BaseRestro;
using RestrauntApplication.Class.OtherRestro;
using RestrauntApplication.Class.Customer;
using RestrauntApplication.Interface;
using RestrauntApplication.Class;
using Unity;


namespace RestrauntApplication
{
    class Program
    {
        
        
        static void Main(string[] args)
        {
            //Restro restro = new Restro {restroName="Happy Food Junction",restroBranch="Mihan, Nagpur" };
            IRestro restro = new Haldirams();
            IUnityContainer container = new UnityContainer();
            ContainerActions.RegisterElements(container);



            while (true)
            {
                Console.WriteLine("Select which menu to display");
                Console.WriteLine("1 : Admin");
                Console.WriteLine("2 : Customer");
                Console.WriteLine("3 : Exit");
                var a = Convert.ToInt32(Console.ReadLine());
                switch (a)
                {
                    case 1:
                        {
                            string selectedRestraunt = "2";
                            
                            restro = container.Resolve<IRestro>(selectedRestraunt);
                            int choice = restro.ShowMenuList();
                            restro.ActionToPerformedByAdminChoice(choice);

                        };
                        break;
                    case 2:
                        {
                            restro = container.Resolve<IRestro>("2");
                            Customer customer = new Customer(new Guid())
                            {
                                restro = restro                     //is this good or passing it as parameter in function calling
                        };

                            customer.CustomerActions();


                        }
                        break;
                    case 3: Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please select from above options only ");
                        break;

                } 
            }






            






          
        }
    }
}
