using System;
using System.Collections.Generic;

namespace TestAzure.DBModels
{
    public partial class Tracking
    {
        public int Id { get; set; }
        public int ReportId { get; set; }
        public string Status { get; set; }
        public DateTime? DueDate { get; set; }
        public bool RepeteadIssue { get; set; }
        public bool Chronic { get; set; }
        public int Supplier { get; set; }
        public string BrandSize { get; set; }
        public DateTime LotProductionDate { get; set; }
        public TimeSpan? ClaimedDt { get; set; }
        public int? ClaimedOfStops { get; set; }
        public TimeSpan? ConfirmedDt { get; set; }
        public int? ConfirmedOfStops { get; set; }
        public string Owner { get; set; }
        public string BlockedMaterialDecision { get; set; }
        public string Issue { get; set; }
        public string ActionForClosingIssue { get; set; }
        public string Comments { get; set; }
        public string Objects { get; set; }

        public Report Report { get; set; }
        public Supplier SupplierNavigation { get; set; }
    }
}
