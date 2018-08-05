using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _88servagentAPI.Models
{
    public class HeatHumidity
    {
        [Key]
        public int Id { get; set; }
        public string Temperature { get; set; }
        public string Humidity { get; set; }
        public DateTime dateTime { get; set; }
        public virtual Device Device { get; set; }
        public virtual PreventiveAction PreventiveAction { get; set; }
    }
}
