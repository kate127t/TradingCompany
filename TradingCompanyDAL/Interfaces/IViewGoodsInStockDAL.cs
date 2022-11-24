using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompanyDTO;

namespace TradingCompanyDAL.Interfaces
{
    public interface IViewGoodsInStockDAL
    {
        List<ViewGoodsInStockDTO> GetListViewGoodsInStock();
        ViewGoodsInStockDTO GetViewGoodsInStockByID(int goodsInStockID);
        List<ViewGoodsInStockDTO> GetSortedByGoodsProviderViewGoodsInStock();
        List<ViewGoodsInStockDTO> GetSortedByQuantityViewGoodsInStock();
        List<ViewGoodsInStockDTO> FindByNameViewGoodsInStock(string name);
    }
}
