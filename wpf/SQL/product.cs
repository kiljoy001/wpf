using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf.SQL
{
    class product
    {
        public int Number { get; set; }
        public string Product_name { get; set; }
        public decimal Amount { get; set; }
        public bool Show_Item { get; set; }
        public Guid ID { get; set; }
    }
}
