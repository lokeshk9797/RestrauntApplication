using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestrauntApplication.Class.BaseRestro;
using RestrauntApplication.Model.BaseRestro;

namespace RestrauntApplication.Class.OtherRestro
{
    class BurgerKing : Restro
    {
        public override string RestroName => "BurgerKing";

        public override string RestroBranch => "Mihan,Nagpur";
        public override void SetItems()
        {
            itemList.Add(new ItemModel { ItemId = 1, ItemName = "Veg Burger", ItemPrice = 40.00, IsAvailable = true });
            itemList.Add(new ItemModel { ItemId = 2, ItemName = "Chicken Burger", ItemPrice = 70.00, IsAvailable = true });
            itemList.Add(new ItemModel { ItemId = 3, ItemName = "Coke", ItemPrice = 200.00, IsAvailable = true });
            itemList.Add(new ItemModel { ItemId = 4, ItemName = "Mojito", ItemPrice = 120.00, IsAvailable = true });
            itemList.Add(new ItemModel { ItemId = 5, ItemName = "Ice Cream", ItemPrice = 15.00, IsAvailable = true });
        }

        public override void SetTables()
        {
            tableList.Add(new TableModel { TableId = 1, TableCapacity = 4, IsTableAvailable = true });
            tableList.Add(new TableModel { TableId = 2, TableCapacity = 6, IsTableAvailable = true });
            tableList.Add(new TableModel { TableId = 3, TableCapacity = 2, IsTableAvailable = true });
            tableList.Add(new TableModel { TableId = 3, TableCapacity = 2, IsTableAvailable = true });
        }
    }
}
