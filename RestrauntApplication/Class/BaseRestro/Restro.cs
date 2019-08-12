using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestrauntApplication.Model.BaseRestro;
using ConsoleTables;

namespace RestrauntApplication.Class.BaseRestro
{
    class Restro
    {
        Dictionary<int, string> menu = new Dictionary<int, string>();
        List<ItemModel> itemList = new List<ItemModel>();
        List<TableModel> tableList = new List<TableModel>();
        List<OrderedItemModel> orderedItems = new List<OrderedItemModel>();
        List<OrderModel> currentOrder = new List<OrderModel>();

        public string restroName { get; set; }
        public string restroBranch { get; set; }

        public Restro()
        {
            SetMenu();
            SetItems();
            SetTables();
        }

        private void SetTables()
        {
            tableList.Add(new TableModel { TableId = 1, TableCapacity = 4, IsTableAvailable = true });
            tableList.Add(new TableModel { TableId = 2, TableCapacity = 6, IsTableAvailable = true });
            tableList.Add(new TableModel { TableId = 3, TableCapacity = 2, IsTableAvailable = true });
            tableList.Add(new TableModel { TableId = 4, TableCapacity = 4, IsTableAvailable = true });
        }

        private void SetMenu()
        {
            menu.Add(1, "Menu Card");
            menu.Add(2, "Items Available Today");
            menu.Add(3, "Table Details");
            menu.Add(4, "Restraunt Name");
            menu.Add(5, "Branch Name");
            menu.Add(6, "Exit");
        }

        private void SetItems()
        {
            itemList.Add(new ItemModel { ItemId = 1, ItemName = "Idli   ", ItemPrice = 40.00, IsAvailable = true });
            itemList.Add(new ItemModel { ItemId = 2, ItemName = "Dosa   ", ItemPrice = 70.00, IsAvailable = true });
            itemList.Add(new ItemModel { ItemId = 3, ItemName = "Biryani", ItemPrice = 200.00, IsAvailable = true });
            itemList.Add(new ItemModel { ItemId = 4, ItemName = "Burger ", ItemPrice = 120.00, IsAvailable = true });
            itemList.Add(new ItemModel { ItemId = 5, ItemName = "Tea    ", ItemPrice = 15.00, IsAvailable =true});

        }

        //private int? getUserChoice()
        //{
        //    Console.WriteLine("Please select an Option");
             
        //    var input = Console.ReadLine();
        //    if(int.TryParse(input,out int choice))
        //    {
        //        return choice;
        //    }
        //    else
        //    {
        //        Console.WriteLine("Plese enter a number");
        //        return null;
        //    }
            
        //}

        public int ShowMenuList()
        {
            Console.WriteLine();
            foreach (var kyp in menu)
            {
                Console.WriteLine($"{kyp.Key} : {kyp.Value}");
            }
            Console.WriteLine("Please Enter a choice");
            int choice = Convert.ToInt32(Console.ReadLine());
            return choice;
            
        }
        public void ShowTableList(bool availability)
        {
            if (availability)
            {
                Console.WriteLine();
                var items = tableList.Where(s=>s.IsTableAvailable).Select(s => " TableId  :  " + s.TableId + " Table Capacity :  " + s.TableCapacity);
                Console.WriteLine(string.Join(Environment.NewLine, items)); 

            }
            else
            {
                Console.WriteLine();
                var items = tableList.Select(s => " TableId  :  " + s.TableId + " Table Capacity :  " + s.TableCapacity + "  :  "+s.IsTableAvailable);
                Console.WriteLine(string.Join(Environment.NewLine, items));
            }
            
        }
        public void ShowItemList(bool availability)
        {
            if (availability)
            {
                Console.WriteLine();
                var items = itemList.Where(s => s.IsAvailable).Select(s => s.ItemId + "  :  " + s.ItemName + "  :  " + s.ItemPrice);
                Console.WriteLine(string.Join(Environment.NewLine, items));

            }
            else
            {
                Console.WriteLine();
                var items = itemList.Select(s => s.ItemId + "  :  " + s.ItemName + "  :  " + s.ItemPrice);
                Console.WriteLine(string.Join(Environment.NewLine, items));
            }

        }
       
        public void SetOrder(int itemId,int quantity)
        {
            
            currentOrder.Add(new OrderModel { ItemName=itemList[itemId-1].ItemName.ToString(),ItemPrice=Convert.ToInt32(itemList[itemId-1].ItemPrice),Quantity=quantity});

        }

        public void OrderCompleted(Guid userId)
        {
            orderedItems.Add(new OrderedItemModel { CustomerId = userId, OrderedItems=currentOrder });
        }


        public void ReserveTable(int tableId)
        {
            tableList[tableId].IsTableAvailable = false;
        }

        public void ShowOrderedItems(Guid userId)
        {
            int count = 1;
            long totalBill = 0;
            var orders = orderedItems.Where(s=>s.CustomerId == userId).Select(s => s.OrderedItems).FirstOrDefault();

            Console.WriteLine("Ordered Item List : ");
            ConsoleTable table = new ConsoleTable("Sr.No", "Name", "Price","Quantity");
            foreach (var order in orders)
            {
                totalBill += order.ItemPrice * order.Quantity;
                table.AddRow(count++,order.ItemName,order.ItemPrice,order.Quantity);
            }
            table.AddRow("","","Total BIll ",totalBill);
            table.Write(Format.Alternative);

        }
        public void ActionToPerformedByAdminChoice(int choice)
        {
            switch(choice)
            {
                case 1:ShowItemList(false);
                    break;
                case 2: ShowItemList(true);
                    break;
                case 3:ShowTableList(false);
                    break;
                case 4:
                    Console.WriteLine($"Restraunt Name: {restroName}");
                    break;
                case 5: Console.WriteLine($"Restraunt Branch: {restroBranch}"); break;
                case 6: break;
                    
            }
        }


    }
}
