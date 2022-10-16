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
    public class GoodsDAL : IGoodsDAL
    {
        private readonly IMapper mapper;
        public GoodsDAL(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public GoodsDTO CreateGoods(GoodsDTO goods)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var goodsInDB = mapper.Map<Goods>(goods);
                entities.Goods.Add(goodsInDB);
                entities.SaveChanges();
                return mapper.Map<GoodsDTO>(goodsInDB);
            }
        }

        public void DeleteGoods(int id)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var goodsToDelete = entities.Goods.FirstOrDefault(x => x.GoodsID == id);
                entities.Goods.Remove(goodsToDelete);
                entities.SaveChanges();
            }
        }

        public List<GoodsDTO> GetAllGoods()
        {
            using (var entities = new TradingCompanyEntities())
            {
                var listGoods = entities.Goods.ToList();
                return mapper.Map<List<GoodsDTO>>(listGoods);
            }
        }

        public GoodsDTO GetGoodsByID(int id)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var goods = entities.Goods.FirstOrDefault(x => x.GoodsID == id);
                return mapper.Map<GoodsDTO>(goods);
            }
        }

        public void UpdateGoods(GoodsDTO goods)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var goodsInDB = entities.Goods.FirstOrDefault(x => x.GoodsID == goods.GoodsID);
                goodsInDB.Name = goods.Name;
                goodsInDB.ProviderID = goods.ProviderID;
                entities.SaveChanges();
            }
        }
    }
}
