using System;
using System.Collections.Generic;

namespace TestAzure.DBModels
{
    public partial class Questions2Reports
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int ReportId { get; set; }

        public Question Question { get; set; }
        public Report Report { get; set; }
    }
}
