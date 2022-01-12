using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationFromOnlineStore.Models
{
    public class DBSales 
    {
        [Key]
        public int SalesId { get; set; }

        public int Sales_ProductId { get; set; }

        public int Sales_EmployeeId { get; set; }

        public int Sales_PremisesId { get; set; }

        public int Sales_ProductCount { get; set; }

        public decimal Sales_Cost { get; set; }

        public decimal Sales_TotalCost { get; set; }

        public DateTime Sales__Data { get; set; }

        public int Sales_DiscountId { get; set; }
    }
}