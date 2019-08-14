using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestrauntApplication.Class.Customer;

namespace RestrauntApplication.Class
{
    public class PayBillEvent : EventArgs
    {
        public PayBillEvent(String name, String bill)
        {
            CustomerName=name;
            TotalBill = bill;

        }

        public String CustomerName { get; set; }
        public String TotalBill { get; set; }
    }
}
