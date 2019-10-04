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
using ConsoleTables;


namespace RestrauntApplication
{
    class Program
    {


        static void Main(string[] args)
        {
            //Restro restro = new Restro {restroName="Happy Food Junction",restroBranch="Mihan, Nagpur" };
            IRestro restro = null;
            IUnityContainer container = new UnityContainer();
            ContainerActions.RegisterElements(container);



            while (true)
            {
                Console.WriteLine("Select which menu to display");
                Console.WriteLine("1 : Admin");
                Console.WriteLine("2 : Customer");
                Console.WriteLine("3 : Exit");
                var a = Console.ReadLine();
                switch (a)
                {
                    case "1":
                        {
                            restro = container.Resolve<IRestro>(ChooseRestraunt());
                            DisplayAdminMenu(restro);                 

                        };
                        break;
                    case "2":
                        {
                            restro = container.Resolve<IRestro>(ChooseRestraunt());
                            Customer customer = new Customer( Guid.NewGuid())
                            {
                                restro = restro     
                            };

                            customer.CustomerActions();
                        }
                        break;
                    case "3": Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please select from above options only ");
                        break;

                } 
            }
          
        }

        private static void DisplayAdminMenu(IRestro restro)
        {
            while (true)
            { 
            int choice = restro.ShowMenuList();
                restro.ActionToPerformedByAdminChoice(choice);
                if (choice == 7)
                    break;
            }

        }
        private static string ChooseRestraunt()
        {
            List<string> RestrauntNames = new List<string>();
            RestrauntNames.Add("Haldirams");
            RestrauntNames.Add("Barbeque Nation ");
            RestrauntNames.Add("BurgerKing");
            RestrauntNames.Add("Dominos");


            Console.WriteLine(" Restraunt List");
            int count = 1;
            ConsoleTable table = new ConsoleTable("Sr.no", "Restraunt Name");
            foreach(var restraunt in RestrauntNames)
            {
                table.AddRow(count++,restraunt );
            }
           
            table.Write(Format.Alternative);
            string result =null;
            
            //while ( !Int32.TryParse(choice, out result))
            //{
            //    Console.WriteLine("Not a valid number, try again.");
            //    Console.Write("Please select a Restaurant : ");
            //    choice = Console.ReadLine();
            //}
            while(true)
            {
                
                Console.Write("Please select a Restaurant : ");
                String choice = Console.ReadLine();
                switch (
                    choice)
                {

                    case "1":
                        result = "1";
                        return result;
                        
                    case "2":
                        result = "2";
                        return result;
                        
                    case "3":
                        result = "3";
                        return result;

                    case "4":
                        result = "4";
                        return result;

                    default:
                        Console.WriteLine("Please Enter Correct Value");
                        break;
                }
                
            }

            
        }
    }
}
