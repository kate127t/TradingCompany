//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TradingCompanyDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class GoodsAndProviders
    {
        public int GoodsAndProvidersID { get; set; }
        public int GoodsID { get; set; }
        public int ProviderID { get; set; }
        public double Price { get; set; }
    
        public virtual Goods Goods { get; set; }
        public virtual Provider Provider { get; set; }
    }
}