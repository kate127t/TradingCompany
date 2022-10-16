using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompanyDTO;

namespace TradingCompanyDAL.Interfaces
{
    public interface IGoodsInStockDAL
    {
        GoodsInStockDTO CreateGoodsInStock(GoodsInStockDTO goodsInStock);

        GoodsInStockDTO GetGoodsInStockByID(int id);
        List<GoodsInStockDTO> GetAllGoodsInStock();
        void UpdateGoodsInStock(GoodsInStockDTO goodsInStock);
        void DeleteGoodsInStock(int id);
    }
}
