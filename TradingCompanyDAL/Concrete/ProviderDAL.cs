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
    public class ProviderDAL : IProviderDAL
    {
        private readonly IMapper mapper;
        public ProviderDAL(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public ProviderDTO CreateProvider(ProviderDTO provider)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var providerInDB = mapper.Map<Provider>(provider);
                entities.Provider.Add(providerInDB);
                entities.SaveChanges();
                return mapper.Map<ProviderDTO>(providerInDB);
            }
        }

        public void DeleteProvider(int id)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var providerToDelete = entities.Provider.FirstOrDefault(x => x.ProviderID == id);
                entities.Provider.Remove(providerToDelete);
                entities.SaveChanges();
            }
        }

        public List<ProviderDTO> GetAllProviders()
        {
            using (var entities = new TradingCompanyEntities())
            {
                var providers = entities.Provider.ToList();
                return mapper.Map<List<ProviderDTO>>(providers);
            }
        }

        public ProviderDTO GetProviderByID(int id)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var provider = entities.Provider.FirstOrDefault(x => x.ProviderID == id);
                return mapper.Map<ProviderDTO>(provider);
            }
        }

        public void UpdateProvider(ProviderDTO provider)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var providerInDB = entities.Provider.FirstOrDefault(x => x.ProviderID == provider.ProviderID);
                //providerInDB = mapper.Map<Role>(provider);
                providerInDB.Name = provider.Name;
                providerInDB.PhoneNumber = provider.PhoneNumber;
                entities.SaveChanges();
            }
        }
    }
}
