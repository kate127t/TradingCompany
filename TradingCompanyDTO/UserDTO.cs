using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingCompanyDTO
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public string Login { get; set; }
        public byte[] Password { get; set; }

        public Guid Salt { get; set; } = Guid.NewGuid();
        
        public string FirstName { get ; set; }
        public string LastName { get; set; }
        public int RoleID { get; set; }
        public override string ToString()
        {
            return UserID.ToString() + "\t"+ FirstName +"\t"+ LastName +"\t" + Login +"\t"+ Password +RoleID.ToString();
        }
    }
}
