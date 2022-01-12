using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationFromOnlineStore.Models
{
    public class DBDiscount
    {
        [Key]
        public int DiscountId { get; set; }

        public string DiscountName { get; set; }

        public int DiscountAmount { get; set; }
    }
}