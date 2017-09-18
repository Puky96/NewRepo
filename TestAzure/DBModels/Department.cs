using System;
using System.Collections.Generic;

namespace TestAzure.DBModels
{
    public partial class Department
    {
        public Department()
        {
            Area = new HashSet<Area>();
            Investigator2Department = new HashSet<Investigator2Department>();
            Qcategory = new HashSet<Qcategory>();
            Report = new HashSet<Report>();
            Supplier = new HashSet<Supplier>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Area> Area { get; set; }
        public ICollection<Investigator2Department> Investigator2Department { get; set; }
        public ICollection<Qcategory> Qcategory { get; set; }
        public ICollection<Report> Report { get; set; }
        public ICollection<Supplier> Supplier { get; set; }
    }
}
