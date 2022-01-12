using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationFromOnlineStore.Models
{
    public class DBProduct
    {
        [Key]
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        [ForeignKey("Categorys")]
        public int ProductType { get; set; }

        [ForeignKey("Manufacturer")]
        public int ManufacturerIds { get; set; }

        public decimal ProductPrice { get; set; }

        public DBCategory Categorys { get; set; }
        public DBManufacturer Manufacturer { get; set; }

        public IEnumerable<DBProductAvailability> ProductAvailabilities { get; set; }
    }


}