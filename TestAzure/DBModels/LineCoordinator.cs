using System;
using System.Collections.Generic;

namespace TestAzure.DBModels
{
    public partial class LineCoordinator
    {
        public int Id { get; set; }
        public int AreaId { get; set; }
        public string LineCoordinatorName { get; set; }

        public Area Area { get; set; }
    }
}
