using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationFromOnlineStore.Models
{
    public class DBPremises
    {
        [Key]
        public int PremisesId { get; set; }

        public string PremisesName { get; set; }

        public string PremisesAdress { get; set; }

        [ForeignKey("PremisesTypeId")]
        public int PremisesType { get; set; }

        public DBPremisesType PremisesTypeId { get; set; }

        public IEnumerable<DBProductAvailability> ProductAvailabilities { get; set; }

    }
}