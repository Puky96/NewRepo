using System;
using System.Collections.Generic;

namespace TestAzure.DBModels
{
    public partial class Report
    {
        public Report()
        {
            Questions2Reports = new HashSet<Questions2Reports>();
            ReportApproval = new HashSet<ReportApproval>();
            Tracking = new HashSet<Tracking>();
        }

        public int Id { get; set; }
        public string IdentitifcationNumber { get; set; }
        public string ImagePath { get; set; }
        public string ImagePath1 { get; set; }
        public string ImagePath2 { get; set; }
        public string EtiqueteImagePath { get; set; }
        public string Originator { get; set; }
        public int EquipmentId { get; set; }
        public string LineCoordinator { get; set; }
        public int DepartmentId { get; set; }
        public int AreaId { get; set; }
        public DateTime DateHour { get; set; }
        public string Gcas { get; set; }
        public string VendorBatch { get; set; }
        public string BatchSap { get; set; }
        public string Po { get; set; }
        public TimeSpan DownTime { get; set; }
        public int NumberOfStops { get; set; }
        public bool Sample { get; set; }
        public bool BlockedBatch { get; set; }
        public string BatchNo { get; set; }
        public int Quantity { get; set; }
        public int PhenomenaCategory { get; set; }
        public bool PendingApproval { get; set; }

        public Department Department { get; set; }
        public Qcategory PhenomenaCategoryNavigation { get; set; }
        public ICollection<Questions2Reports> Questions2Reports { get; set; }
        public ICollection<ReportApproval> ReportApproval { get; set; }
        public ICollection<Tracking> Tracking { get; set; }
    }
}
