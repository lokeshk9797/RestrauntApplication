﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestrauntApplication.Class.BaseRestro;
using RestrauntApplication.Model.BaseRestro;
using RestrauntApplication.Interface;
using RestrauntApplication.Class;
using ConsoleTables;

namespace RestrauntApplication.Class.Customer
{
    public class Customer
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public int TableId { get; set; }

        List<OrderModel> orderedItems = new List<OrderModel>();
        Dictionary<int, string> customersMenuList = new Dictionary<int, string>();

        public IRestro restro = null;

        
        public Customer(Guid userId)
        {
            UserId = userId;
            
        }
        

        public void CustomerActions()
        {
            PaymentSubscriber payee = new PaymentSubscriber((Restro)restro);
            GetCustomerName();
            SelectTable();
            OrderItems();
            ShowOrderedItemsList();
            
        }
        
        
        private void GetCustomerName()
        {
            Console.Write("Enter Name : ");
            Name = Console.ReadLine();

        }
        private void SelectTable()
        {
            int count = restro.ShowTableList(true);
            
            Console.Write("Select Table : ");
            TableId = Convert.ToInt32(Console.ReadLine());

            restro.ReserveTable(TableId);
        }
        private void ShowOrderedItemsList()
        {
            restro.ShowOrderedItems(UserId);
            
        }

        private void OrderItems()
        {
            
            while (true)
            {
                restro.ShowItemList(true);

                Console.Write("Select Item : ");
                int selectedItemId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Select Quantity: ");
                int quantity = Convert.ToInt32(Console.ReadLine());

                restro.SetOrder(selectedItemId,quantity);

                Console.Write("Do you want to order something (Y/N): ");
                string choice = Console.ReadLine();

                if (choice.Equals("N", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
            }
            restro.OrderCompleted(UserId,Name);
        }






    }
}
