using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestrauntApplication.Model.BaseRestro
{
    public class TableModel
    {
        
        public int TableId { get; set; }
        public int TableCapacity { get; set; }
        public bool IsTableAvailable { get; set; }
    }
}
