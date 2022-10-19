using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompanyDAL.Interfaces;
using TradingCompanyDTO;

namespace TradingCompanyDAL.Concrete
{
    public class GoodsInStockDAL : IGoodsInStockDAL
    {
        private readonly IMapper mapper;
        public GoodsInStockDAL(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public GoodsInStockDTO CreateGoodsInStock(GoodsInStockDTO goodsInStock)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var goodsInStockInDB = mapper.Map<GoodsInStock>(goodsInStock);
                entities.GoodsInStock.Add(goodsInStockInDB);
                entities.SaveChanges();
                return mapper.Map<GoodsInStockDTO>(goodsInStockInDB);
            }
        }

        public void DeleteGoodsInStock(int id)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var goodsInStockToDelete = entities.GoodsInStock.FirstOrDefault(x => x.GoodsInStockID == id);
                entities.GoodsInStock.Remove(goodsInStockToDelete);
                entities.SaveChanges();
            }
        }

        public List<GoodsInStockDTO> GetAllGoodsInStock()
        {
            using (var entities = new TradingCompanyEntities())
            {
                var goodsInStockList = entities.GoodsInStock.ToList();
                return mapper.Map<List<GoodsInStockDTO>>(goodsInStockList);
            }
        }

        public GoodsInStockDTO GetGoodsInStockByID(int id)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var goodsInStock = entities.GoodsInStock.FirstOrDefault(x => x.GoodsInStockID == id);
                return mapper.Map<GoodsInStockDTO>(goodsInStock);
            }
        }

        public void UpdateGoodsInStock(GoodsInStockDTO goodsInStock)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var goodsInStockInDB = entities.GoodsInStock.FirstOrDefault(x => x.GoodsInStockID == goodsInStock.GoodsInStockID);
                //roleInDB = mapper.Map<Role>(role);
                goodsInStockInDB.GoodsID = goodsInStock.GoodsID;
                goodsInStockInDB.Quantity = goodsInStock.Quantity;
                entities.SaveChanges();
            }
        }
    }
}
