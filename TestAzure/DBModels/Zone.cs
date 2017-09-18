using System;
using System.Collections.Generic;

namespace TestAzure.DBModels
{
    public partial class Zone
    {
        public Zone()
        {
            Equipment = new HashSet<Equipment>();
        }

        public int Id { get; set; }
        public int AreaId { get; set; }
        public string Name { get; set; }

        public Area Area { get; set; }
        public ICollection<Equipment> Equipment { get; set; }
    }
}
