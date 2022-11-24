using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompanyDTO;

namespace TradingCompanyDAL.Profiles
{
    public class ViewGoodsInStockProfile : Profile
    {
        public ViewGoodsInStockProfile()
        {
            CreateMap<View_GoodsInStock, ViewGoodsInStockDTO>().ReverseMap();
        }
    }
}
