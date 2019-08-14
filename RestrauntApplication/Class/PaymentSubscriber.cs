using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestrauntApplication.Class.BaseRestro;

namespace RestrauntApplication.Class
{
    class PaymentSubscriber
    {
        public PaymentSubscriber(Restro restro)
        {
            restro.BillPaid += OnBillPaid;
            
        }
        private void OnBillPaid(object sender, PayBillEvent e)
        {
            Console.WriteLine($"Bill of {e.TotalBill} paid by{e.CustomerName} ");
        }
    }
}
