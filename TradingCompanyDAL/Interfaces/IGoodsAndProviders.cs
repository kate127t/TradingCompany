using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompanyDAL.Concrete;
using TradingCompanyDTO;

namespace TradingCompanyDAL.Interfaces
{
    public interface IGoodsAndProvidersDAL
    {
        GoodsAndProvidersDTO CreateGoodsAndProviders(GoodsAndProvidersDTO goodsAndProviders);

        GoodsAndProvidersDTO GetGoodsAndProvidersByID(int id);
        List<GoodsAndProvidersDTO> GetAllGoodsAndProviders();
        void UpdateGoodsAndProviders(GoodsAndProvidersDTO goodsAndProviders);
        void DeleteGoodsAndProviders(int id);
    }
}
