using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompanyDTO;

namespace TradingCompanyDAL.Profiles
{
    public class GoodsInStockProfile : Profile
    {
        public GoodsInStockProfile()
        {
            CreateMap<GoddsInStock, GoodsInStockDTO>().ReverseMap();
        }
    }
}
