using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompanyDAL.Concrete;
using TradingCompanyDTO;

namespace TradingCompanyDAL.Profiles
{
        public class GoodsAndProvidersProfile : Profile
        {
            public GoodsAndProvidersProfile()
            {
                CreateMap<GoodsAndProviders, GoodsAndProvidersDTO>().ReverseMap();
            }
        }
    
}
