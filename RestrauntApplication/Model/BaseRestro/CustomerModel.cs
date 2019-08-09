using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestrauntApplication.Model.BaseRestro
{
    class CustomerModel
    {
        public Guid CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int TableID { get; set; }
    }
}
