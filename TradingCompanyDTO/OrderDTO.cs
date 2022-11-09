using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCompanyDTO
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public int GoodsID { get; set; }
        public int ProviderID { get; set; }
        public int ManagerID { get; set; }
        public System.DateTime DateOrdered { get; set; }
        public System.DateTime DateArrives { get; set; }
        public int Quantity { get; set; }
    }
}
