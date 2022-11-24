using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompanyBLL.Interfaces;
using TradingCompanyDAL.Interfaces;
using TradingCompanyDTO;

namespace TradingCompanyBLL.Concrete
{
    public class GoodsInStockManager : IGoodsInStockManager
    {
        private readonly IGoodsInStockDAL goodsInStockDAL;
        private readonly IViewGoodsInStockDAL viewGoodsInStockDAL;
        public GoodsInStockManager(IGoodsInStockDAL goodsInStockDAL, IViewGoodsInStockDAL viewGoodsInStockDAL)
        {
            this.goodsInStockDAL = goodsInStockDAL;
            this.viewGoodsInStockDAL=viewGoodsInStockDAL;
        }
        public List<GoodsInStockDTO> GetAllGoodsInStock()
        {
            return goodsInStockDAL.GetAllGoodsInStock();
        }

        public List<ViewGoodsInStockDTO> GetAllViewGoodsInStock()
        {
            return viewGoodsInStockDAL.GetListViewGoodsInStock();
        }

        public List<ViewGoodsInStockDTO> GetSortedByGoodsProviderViewGoodsInStock()
        {
            return viewGoodsInStockDAL.GetSortedByGoodsProviderViewGoodsInStock();
        }

        public List<ViewGoodsInStockDTO> GetSortedByQuantityViewGoodsInStock()
        {
            return viewGoodsInStockDAL.GetSortedByQuantityViewGoodsInStock();
        }

        public List<ViewGoodsInStockDTO> FindByNameViewGoodsInStock(string name)
        {
            return viewGoodsInStockDAL.FindByNameViewGoodsInStock(name);
        }
    }
}
