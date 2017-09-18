using System;
using System.Collections.Generic;

namespace TestAzure.DBModels
{
    public partial class Investigator2Department
    {
        public int Id { get; set; }
        public string InvestigatorId { get; set; }
        public int DepartmentId { get; set; }
        public bool IsInvestigator { get; set; }

        public Department Department { get; set; }
        public AspNetUsers Investigator { get; set; }
    }
}
