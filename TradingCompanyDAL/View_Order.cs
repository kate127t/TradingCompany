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
    
    public partial class View_Order
    {
        public int OrderID { get; set; }
        public string GoodsName { get; set; }
        public string ProviderName { get; set; }
        public string ManagerFirstName { get; set; }
        public string ManagerLastName { get; set; }
        public System.DateTime DateOrdered { get; set; }
        public System.DateTime DateArrives { get; set; }
        public int Quantity { get; set; }
    }
}