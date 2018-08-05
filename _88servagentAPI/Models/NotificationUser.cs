using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _88servagentAPI.Models
{
    public class NotificationUser
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public virtual Notification Notification { get; set; }
        public virtual NotificationRecipient Receipt { get; set; }

    }
}
