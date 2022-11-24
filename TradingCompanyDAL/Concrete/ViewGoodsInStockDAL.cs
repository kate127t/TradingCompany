using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TradingCompanyDAL.Interfaces;
using TradingCompanyDTO;

namespace TradingCompanyDAL.Concrete
{
    public class ViewGoodsInStockDAL: IViewGoodsInStockDAL
    {
        private readonly IMapper mapper;
        public ViewGoodsInStockDAL(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public List<ViewGoodsInStockDTO> GetListViewGoodsInStock()
        {
            using (var entities = new TradingCompanyEntities())
            {
                var viewGoodsInStock = entities.View_GoodsInStock.ToList();
                return mapper.Map<List<ViewGoodsInStockDTO>>(viewGoodsInStock);
            }
        }

        public ViewGoodsInStockDTO GetViewGoodsInStockByID(int id)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var viewGoodsInStock = entities.View_GoodsInStock.FirstOrDefault(x => x.GoodsInStockID == id);
                return mapper.Map<ViewGoodsInStockDTO>(viewGoodsInStock);
            }
        }

        public List<ViewGoodsInStockDTO> GetSortedByGoodsProviderViewGoodsInStock()
        {
            using (var entities = new TradingCompanyEntities())
            {
                var viewGoodsInStock = entities.View_GoodsInStock.OrderBy(x => x.GoodsName).ThenBy(x=>x.ProviderName).ToList();
                return mapper.Map<List<ViewGoodsInStockDTO>>(viewGoodsInStock);
            }
        }
        public List<ViewGoodsInStockDTO> GetSortedByQuantityViewGoodsInStock()
        {
            using (var entities = new TradingCompanyEntities())
            {
                var viewGoodsInStock = entities.View_GoodsInStock.OrderBy(x => x.Quantity).ToList();
                return mapper.Map<List<ViewGoodsInStockDTO>>(viewGoodsInStock);
            }
        }

        public List<ViewGoodsInStockDTO> FindByNameViewGoodsInStock(string name)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var viewGoodsInStock = entities.View_GoodsInStock.Where(x => x.GoodsName.Contains(name)).ToList();
                return mapper.Map<List<ViewGoodsInStockDTO>>(viewGoodsInStock);
            }
        }
    }
}
