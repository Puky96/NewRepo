using System;
using System.Collections.Generic;

namespace TestAzure.DBModels
{
    public partial class ReportApproval
    {
        public int Id { get; set; }
        public int ReportId { get; set; }
        public bool Approved { get; set; }
        public string Reason { get; set; }
        public DateTime ApprovalDate { get; set; }

        public Report Report { get; set; }
    }
}
