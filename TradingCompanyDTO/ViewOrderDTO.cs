using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCompanyDTO
{
    public class ViewOrderDTO
    {
        public int OrderID { get; set; }
        public string GoodsName { get; set; }
        public string ProviderName { get; set; }

        public string ManagerFirstName { get; set; }
        public string ManagerLastName { get; set; }
        public DateTime DateOrdered { get; set; }
        public DateTime DateArrives { get; set; }
        public int Quantity { get; set; }
    }
}
