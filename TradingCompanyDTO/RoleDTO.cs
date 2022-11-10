using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCompanyDTO
{
    public class RoleDTO
    {
        public int RoleID { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return RoleID.ToString()+"\t"+Name;
        }
    }
}
