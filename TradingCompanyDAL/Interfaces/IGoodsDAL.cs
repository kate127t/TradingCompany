using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompanyDTO;

namespace TradingCompanyDAL.Interfaces
{
    public interface IGoodsDAL
    {
        GoodsDTO CreateGoods(GoodsDTO goods);

        GoodsDTO GetGoodsByID(int id);
        List<GoodsDTO> GetAllGoods();
        void UpdateGoods(GoodsDTO goods);
        void DeleteGoods(int id);
    }
}
