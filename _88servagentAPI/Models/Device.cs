using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _88servagentAPI.Models
{
    public class Device
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Localization { get; set; }

        public virtual ICollection<HeatHumidity> HeatHumidities { get; set; }

    }
}
