using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestrauntApplication.Class.BaseRestro;
using RestrauntApplication.Model.BaseRestro;

namespace RestrauntApplication.Class.OtherRestro
{
    class Haldirams : Restro
    {
        public override string RestroName => "Haldirams";

        public override string RestroBranch => "Nagpur";

        public override void SetItems()
        {
            itemList.Add(new ItemModel { ItemId = 1, ItemName = "Idli   ", ItemPrice = 40.00, IsAvailable = true });
            itemList.Add(new ItemModel { ItemId = 2, ItemName = "Dosa   ", ItemPrice = 70.00, IsAvailable = true });
            itemList.Add(new ItemModel { ItemId = 3, ItemName = "Biryani", ItemPrice = 200.00, IsAvailable = true });
            itemList.Add(new ItemModel { ItemId = 4, ItemName = "Namkeen ", ItemPrice = 120.00, IsAvailable = true });
            itemList.Add(new ItemModel { ItemId = 5, ItemName = "Bhel Puri    ", ItemPrice = 15.00, IsAvailable = true });

        }

        public override void SetTables()
        {
            tableList.Add(new TableModel { TableId = 1, TableCapacity = 4, IsTableAvailable = true });
            tableList.Add(new TableModel { TableId = 2, TableCapacity = 6, IsTableAvailable = true });
            tableList.Add(new TableModel { TableId = 3, TableCapacity = 8, IsTableAvailable = true });
            tableList.Add(new TableModel { TableId = 4, TableCapacity = 10, IsTableAvailable = true });
        }
        
    }

   
}
