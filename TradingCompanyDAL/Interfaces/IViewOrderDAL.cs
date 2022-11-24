using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompanyDTO;

namespace TradingCompanyDAL.Interfaces
{
    public interface IViewOrderDAL
    {
        List<ViewOrderDTO> GetListViewOrder();
        ViewOrderDTO GetViewOrderByID(int orderID);
    }
}
