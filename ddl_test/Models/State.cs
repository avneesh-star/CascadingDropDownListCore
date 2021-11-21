using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ddl_test.Models
{
    public class State
    {
        [Key]
       
        public int StateId { get; set; }
        public string StateName { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public bool Active { get; set; }
        public Country Country { get; set; }
        public List<City> cities { get; set; }
      
    }
}
