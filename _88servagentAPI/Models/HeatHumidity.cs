using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _88servagentAPI.Models
{
    public class HeatHumidity
    {
        [Key]
        public int Id { get; set; }
        public string Temperature { get; set; }
        public string TemperatureUnit { get; set; }
        public string Humidity { get; set; }

        public DateTime DateTime { get; set; }
        public virtual Device Device { get; set; }
        public virtual PreventiveAction PreventiveAction { get; set; }
    }
}
