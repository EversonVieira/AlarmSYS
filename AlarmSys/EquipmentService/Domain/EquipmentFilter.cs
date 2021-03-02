using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentService
{
    public class EquipmentFilter:Equipment
    {
        public DateTime StartDate { get; set; } = DateTime.MinValue;
        public DateTime EndDate { get; set; } = DateTime.MaxValue;
    }
}
