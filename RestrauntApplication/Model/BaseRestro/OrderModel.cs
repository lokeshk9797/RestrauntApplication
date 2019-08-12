using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestrauntApplication.Model.BaseRestro
{
    public class OrderModel
    {
        public int ItemPrice { get; set; }
        public int Quantity { get; set; }
        public string ItemName { get; set; }

    }
}
