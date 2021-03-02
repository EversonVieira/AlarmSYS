using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentService
{
    public class Equipment
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int SerialNumber { get; set; } = 0;
        public int Id_Type { get; set; } = 0;
        public DateTime RegisterDate { get; set; } = DateTime.MinValue;
    }
}
