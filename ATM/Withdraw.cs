//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ATM
{
    using System;
    using System.Collections.Generic;
    
    public partial class Withdraw
    {
        public string WithdrawCode { get; set; }
        public System.DateTime WithdrawDate { get; set; }
        public int WithdrawAmount { get; set; }
        public string AccountCode { get; set; }
    
        public virtual Account Account { get; set; }
    }
}