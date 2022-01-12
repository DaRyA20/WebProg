using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationFromOnlineStore.Models
{
    public class DBEmployee
    {
        [Key]
        public int EmployeeId { get; set; }

        public string EmployeeSurname { get; set; }
        
        public string EmployeeName { get; set; }
        
        public string EmployeePatronymic { get; set; }

        public DateTime EmployeeDate { get; set; }

        [ForeignKey("Position")]
        public int EmployeePositionId { get; set; }

        public string EmployeePhone { get; set; }

        public DBPosition Position { get; set; }
    }
}