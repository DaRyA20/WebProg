using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationFromOnlineStore.Models
{
    public class DBPremisesType
    {
        [Key]
        public int PremisesTypeId { get; set; }

        public string PremisesTypeName { get; set; }

        public IEnumerable<DBPremises> Premises { get; set; }
    }
}