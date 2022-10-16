using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingCompanyDTO;

namespace TradingCompanyDAL.Interfaces
{
    public interface IProviderDAL
    {
        ProviderDTO CreateProvider(ProviderDTO provider);

        ProviderDTO GetProviderByID(int id);
        List<ProviderDTO> GetAllProviders();
        void UpdateProvider(ProviderDTO provider);
        void DeleteProvider(int id);
    }
}
