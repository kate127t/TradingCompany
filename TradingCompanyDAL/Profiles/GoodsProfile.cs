using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompanyDTO;

namespace TradingCompanyDAL.Profiles
{
    public class GoodsProfile : Profile
    {
        public GoodsProfile()
        {
            CreateMap<Goods, GoodsDTO>().ReverseMap();
        }
    }
}
