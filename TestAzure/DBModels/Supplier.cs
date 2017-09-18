using System;
using System.Collections.Generic;

namespace TestAzure.DBModels
{
    public partial class Supplier
    {
        public Supplier()
        {
            Tracking = new HashSet<Tracking>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
        public ICollection<Tracking> Tracking { get; set; }
    }
}
