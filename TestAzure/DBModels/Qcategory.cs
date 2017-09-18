using System;
using System.Collections.Generic;

namespace TestAzure.DBModels
{
    public partial class Qcategory
    {
        public Qcategory()
        {
            Question = new HashSet<Question>();
            Report = new HashSet<Report>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
        public ICollection<Question> Question { get; set; }
        public ICollection<Report> Report { get; set; }
    }
}
