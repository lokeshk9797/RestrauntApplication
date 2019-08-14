using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestrauntApplication.Class.BaseRestro;
using RestrauntApplication.Model.BaseRestro;

namespace RestrauntApplication.Class.OtherRestro
{
    class BarbequeNation : Restro
    {
        public override string RestroName => "BarbequeNation";

        public override string RestroBranch => "Manish Nagar, Nagpur";
        public override void SetItems()
        {
            itemList.Add(new ItemModel { ItemId = 1, ItemName = "Veg", ItemPrice = 600.00, IsAvailable = true });
            itemList.Add(new ItemModel { ItemId = 2, ItemName = "Non-Veg", ItemPrice = 700.00, IsAvailable = true });
           
        }
        public override void SetTables()
        {
            tableList.Add(new TableModel { TableId = 1, TableCapacity = 1, IsTableAvailable = true });
            tableList.Add(new TableModel { TableId = 2, TableCapacity = 2, IsTableAvailable = true });
            tableList.Add(new TableModel { TableId = 3, TableCapacity = 3, IsTableAvailable = true });
            tableList.Add(new TableModel { TableId = 4, TableCapacity = 4, IsTableAvailable = true });
        }
    }
}
