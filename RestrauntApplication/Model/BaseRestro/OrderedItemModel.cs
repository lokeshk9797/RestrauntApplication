using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestrauntApplication.Model.BaseRestro
{
    public class OrderedItemModel
    {
        
        public Guid CustomerId{ get; set; }
        public string CustomerName { get; set; }
        public long TotalBill { get; set; }
        public List<OrderModel> OrderedItems { get; set; }
    }
}
