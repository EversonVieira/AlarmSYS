using System;
using System.Collections.Generic;
using System.Text;

namespace AlarmService
{
    public class Alarm
    {
        public int Id { get; set; } = 0;
        public int Id_Classification { get; set; } = 0;
        public int Id_Equipment { get; set; } = 0;
        public string Description { get; set; } = string.Empty;
        public DateTime RegisterDate { get; set; } = DateTime.MinValue;


    }
}
