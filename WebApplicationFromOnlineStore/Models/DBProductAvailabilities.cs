using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationFromOnlineStore.Models
{
    public class DBProductAvailability
    {
        [Key]
        public int ProductAvailabilityId { get; set; }
        [ForeignKey("Product")]
        public int ProductAvailability_ProductId { get; set; }
        [ForeignKey("Premises")]
        public int ProductAvailability_PremisesId { get; set; }

        public int ProductAvailability_ProductCount { get; set; }

        public DBProduct Product { get; set; }
        public DBPremises Premises { get; set; }

       
    }
}