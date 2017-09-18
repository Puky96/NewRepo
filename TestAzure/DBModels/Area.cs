using System;
using System.Collections.Generic;

namespace TestAzure.DBModels
{
    public partial class Area
    {
        public Area()
        {
            LineCoordinator = new HashSet<LineCoordinator>();
            Zone = new HashSet<Zone>();
        }

        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }

        public Department Department { get; set; }
        public ICollection<LineCoordinator> LineCoordinator { get; set; }
        public ICollection<Zone> Zone { get; set; }
    }
}
