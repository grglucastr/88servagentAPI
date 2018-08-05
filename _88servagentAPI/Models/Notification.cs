using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _88servagentAPI.Models
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public virtual HeatHumidity HeatHumidity { get; set; }
    }
}
