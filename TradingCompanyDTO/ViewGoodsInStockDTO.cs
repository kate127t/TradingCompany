using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCompanyDTO
{
    public class ViewGoodsInStockDTO
    {
        public int GoodsInStockID { get; set; }
        public string GoodsName { get; set; }
        public string ProviderName { get; set; }
        public int Quantity { get; set; }
    }
}
