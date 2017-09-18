using System;
using System.Collections.Generic;

namespace TestAzure.DBModels
{
    public partial class Equipment
    {
        public int Id { get; set; }
        public int ZoneId { get; set; }
        public string Name { get; set; }

        public Zone Zone { get; set; }
    }
}
