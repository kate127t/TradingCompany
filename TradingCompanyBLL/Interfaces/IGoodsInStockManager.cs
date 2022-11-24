using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompanyDAL.Concrete;
using TradingCompanyDTO;

namespace TradingCompanyBLL.Interfaces
{
    public interface IGoodsInStockManager
    {
        List<GoodsInStockDTO> GetAllGoodsInStock();

        List<ViewGoodsInStockDTO> GetAllViewGoodsInStock();

        List<ViewGoodsInStockDTO> GetSortedByGoodsProviderViewGoodsInStock();
        List<ViewGoodsInStockDTO> GetSortedByQuantityViewGoodsInStock();
        List<ViewGoodsInStockDTO> FindByNameViewGoodsInStock(string name);
    }
}
