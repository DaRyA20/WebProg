using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationFromOnlineStore.Models
{
    public class DBPosition
    {
        [Key]
        public int PositionId { get; set; }

        public string PositionName { get; set; }

        public ICollection<DBEmployee> Employees { get; set; }
    }
}