using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationFromOnlineStore.Models
{
    public class DBManufacturer
    {
        [Key]
        public int ManufacturerId { get; set; }

        public string ManufacturerName { get; set; }

        public IEnumerable<DBProduct> Products { get; set; }

        public IEnumerable<DBProductAvailability> productAvailabilities { get; set; }
    }
}