using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestrauntApplication.Model.BaseRestro;
using ConsoleTables;
using RestrauntApplication.Interface;
using RestrauntApplication.Class;

namespace RestrauntApplication.Class.BaseRestro
{

    public abstract class Restro : IRestro
    {
        protected Dictionary<int, string> menu = new Dictionary<int, string>();
        protected List<ItemModel> itemList = new List<ItemModel>();
        protected List<TableModel> tableList = new List<TableModel>();
        protected List<OrderedItemModel> orderedItems = new List<OrderedItemModel>();
        protected List<OrderModel> currentOrder = new List<OrderModel>();

        public delegate void MyDelegate(string message);
        public event EventHandler<PayBillEvent> BillPaid ;

        public abstract string RestroName { get; }
        public abstract string RestroBranch { get; }

        public Restro()
        {
            SetMenu();
            SetItems();
            SetTables();
        }

        public abstract void SetTables();


        public void SetMenu()
        {
            menu.Add(1, "Menu Card");
            menu.Add(2, "Items Available Today");
            menu.Add(3, "Table Details");
            menu.Add(4, "Restraunt Name");
            menu.Add(5, "Branch Name");
            menu.Add(6, "All Customer List");
            menu.Add(7, "Go back");
           
        }

        private void Restro_BillPaid(object sender, PayBillEvent e)
        {
            throw new NotImplementedException();
        }

        public abstract void SetItems();


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
        public int ShowTableList(bool availability)
        {
            if (availability)
            {
                Console.WriteLine();
                var tables = tableList.Where(s => s.IsTableAvailable);
                ConsoleTable displayTable = new ConsoleTable("Sr.no", "Table Capacity");
                foreach(var table in tables)
                {
                    displayTable.AddRow(table.TableId, table.TableCapacity);
                }
                displayTable.Write(Format.Alternative);
                return tableList.Count;

            }
            else
            {
                Console.WriteLine();
                ConsoleTable displayTable = new ConsoleTable("Sr.no", "Table Capacity","Availability");
                foreach (var table in tableList)
                {
                    string tableAvailibilty = table.IsTableAvailable ? "Free" : "Booked";
                    displayTable.AddRow(table.TableId, table.TableCapacity,tableAvailibilty);
                }
                displayTable.Write(Format.Alternative);
                return tableList.Count;
            }

        }
        public void ReserveTable(int tableId)
        {
            tableList[tableId - 1].IsTableAvailable = false;

        }
        public void ShowItemList(bool availability)
        {
            if (availability)
            {
                Console.WriteLine();
                var items = itemList.Where(s => s.IsAvailable);
                ConsoleTable displayItems = new ConsoleTable("Sr.no", "Item Name","Price");
                foreach (var item in items)
                {
                    displayItems.AddRow(item.ItemId,item.ItemName,item.ItemPrice);
                }
                displayItems.Write(Format.Alternative);


            }
            else
            {
                Console.WriteLine();
                ConsoleTable displayItems = new ConsoleTable("Sr.no", "Item Name", "Price","Availability");
                foreach (var item in itemList)
                {
                    string itemAvailibilty = item.IsAvailable ? "Free" : "Booked";
                    displayItems.AddRow(item.ItemId, item.ItemName, item.ItemPrice,itemAvailibilty);
                }
                displayItems.Write(Format.Alternative);

            }

        }

        public void SetOrder(int itemId, int quantity)
        {

            currentOrder.Add(new OrderModel { ItemName = itemList[itemId - 1].ItemName.ToString(), ItemPrice = Convert.ToInt32(itemList[itemId - 1].ItemPrice), Quantity = quantity });

        }

        public void OrderCompleted(Guid userId,String CustomerName)
        {
            long totalBill = 0;
            foreach(var order in currentOrder)
            {
                totalBill += order.ItemPrice * order.Quantity;
            }
            orderedItems.Add(new OrderedItemModel { CustomerId = userId,CustomerName=CustomerName, OrderedItems = currentOrder ,TotalBill=totalBill});

        }

        public void ShowCustomers()
        {
            int count = 1;
            ConsoleTable table = new ConsoleTable("sr.no","CusomerId", "Name", "Total Bill");
            foreach (var orderServed in orderedItems)
            {
                table.AddRow(count++, orderServed.CustomerId,orderServed.CustomerName, orderServed.TotalBill);
            }
            table.Write(Format.Alternative);
        }

        

        public void ShowOrderedItems(Guid userId)
        {
            int count = 1;
            
            var orders = orderedItems.Where(s=>s.CustomerId == userId).Select(s => s.OrderedItems).FirstOrDefault();
            var bill = orderedItems.Where(s => s.CustomerId == userId).Select(s => s.TotalBill).FirstOrDefault();
            var name = orderedItems.Where(s => s.CustomerId == userId).Select(s => s.CustomerName).FirstOrDefault();
            Console.WriteLine("Ordered Item List : ");
            ConsoleTable table = new ConsoleTable("Name ", name,"","");
            table.AddRow("Sr.no", "Item", "Price", "Quantity");
             foreach (var order in orders)
            {
                table.AddRow(count++,order.ItemName,order.ItemPrice,order.Quantity);
            }
            table.AddRow("", "", "Total Bill", bill);
            table.Write(Format.Alternative);
            PayBillEvent(name,bill.ToString());
                        
        }
        public void ActionToPerformedByAdminChoice(int choice)
        {
           
                switch (choice)
                {
                    case 1:
                        ShowItemList(false);
                        break;
                    case 2:
                        ShowItemList(true);
                        break;
                    case 3:
                        ShowTableList(false);
                        break;
                    case 4:
                        ConsoleTable DisplayName = new ConsoleTable("Restaurant Name : ", RestroName);
                        DisplayName.Write(Format.Alternative);
                        break;
                    case 5:
                        ConsoleTable DisplayBranch = new ConsoleTable("Restaurant Branch : ", RestroBranch);
                        DisplayBranch.Write(Format.Alternative);
                        break;
                    case 6:
                        ShowCustomers();
                        break;
                    case 7:
                        break;
                default: Console.WriteLine("Enter Correct Choice");
                    break;

               
            }
        }

        private void PayBillEvent(String name , String bill)
        {
            while (true)
            {
                Console.Write("Please press Y to Pay bill.. :");
                var choice =Console.ReadLine();
                if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                    break;
            }
            RaiseBillPaymentEvent(new PayBillEvent(name,bill));

        }
        
        public virtual void RaiseBillPaymentEvent(PayBillEvent eventArgs)
        {
            BillPaid?.Invoke(this, eventArgs);
        }
        
    }
}
