using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCompanyDTO
{
    public class GoodsInStockDTO
    {
        public int GoodsInStockID { get; set; }
        public int GoodsID { get; set; }
        public int ProviderID { get; set; }
        public int Quantity { get; set; }
    }
}
