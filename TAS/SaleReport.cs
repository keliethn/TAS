//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TAS
{
    using System;
    using System.Collections.Generic;
    
    public partial class SaleReport
    {
        public SaleReport()
        {
            this.SaleReportDetails = new HashSet<SaleReportDetail>();
        }
    
        public int ReportID { get; set; }
        public System.DateTime ReportDate { get; set; }
        public int GameID { get; set; }
        public int Status { get; set; }
    
        public virtual Game Game { get; set; }
        public virtual ICollection<SaleReportDetail> SaleReportDetails { get; set; }
        public virtual SaleReportStatus SaleReportStatus { get; set; }
    }
}
