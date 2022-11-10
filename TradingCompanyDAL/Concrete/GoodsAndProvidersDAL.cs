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
    public class GoodsAndProvidersDAL : IGoodsAndProvidersDAL
    {
        private readonly IMapper mapper;
        public GoodsAndProvidersDAL(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public GoodsAndProvidersDTO CreateGoodsAndProviders(GoodsAndProvidersDTO goodsAndProviders)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var goodsAndProvidersInDB = mapper.Map<GoodsAndProviders>(goodsAndProviders);
                entities.GoodsAndProviders.Add(goodsAndProvidersInDB);
                entities.SaveChanges();
                return mapper.Map<GoodsAndProvidersDTO>(goodsAndProvidersInDB);
            }
        }

        public void DeleteGoodsAndProviders(int id)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var goodsAndProvidersToDelete = entities.GoodsAndProviders.FirstOrDefault(x => x.GoodsAndProvidersID == id);
                entities.GoodsAndProviders.Remove(goodsAndProvidersToDelete);
                entities.SaveChanges();
            }
        }

        public List<GoodsAndProvidersDTO> GetAllGoodsAndProviders()
        {
            using (var entities = new TradingCompanyEntities())
            {
                var listGoodsAndProviders = entities.GoodsAndProviders.ToList();
                return mapper.Map<List<GoodsAndProvidersDTO>>(listGoodsAndProviders);
            }
        }

        public GoodsAndProvidersDTO GetGoodsAndProvidersByID(int id)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var goodsAndProviders = entities.GoodsAndProviders.FirstOrDefault(x => x.GoodsAndProvidersID == id);
                return mapper.Map<GoodsAndProvidersDTO>(goodsAndProviders);
            }
        }

        public void UpdateGoodsAndProviders(GoodsAndProvidersDTO goodsAndProviders)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var goodsAndProvidersInDB = entities.GoodsAndProviders.FirstOrDefault(x => x.GoodsAndProvidersID == goodsAndProviders.GoodsAndProvidersID);
                goodsAndProvidersInDB.GoodsID = goodsAndProviders.GoodsID;
                goodsAndProvidersInDB.ProviderID = goodsAndProviders.ProviderID;
                goodsAndProviders.Price = goodsAndProvidersInDB.Price;
                entities.SaveChanges();
            }
        }
    }
}
