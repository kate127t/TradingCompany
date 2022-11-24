using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompanyDTO;

namespace TradingCompanyDAL.Profiles
{
    public class ViewOrderProfile : Profile
    {
        public ViewOrderProfile()
        {
            CreateMap<View_Order, ViewOrderDTO>().ReverseMap();
        }
    }
}
