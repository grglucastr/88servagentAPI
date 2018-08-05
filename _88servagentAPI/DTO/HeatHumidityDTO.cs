using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _88servagentAPI.DTO
{
    public class HeatHumidityDTO
    {
        public string Temperature { get; set; }
        public string Humidity { get; set; }

        [Range(1, Int32.MaxValue)]
        public int DeviceId { get; set; }
        public int PreventiveAction { get; set; }
    }
}
