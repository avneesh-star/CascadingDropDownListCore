using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ddl_test.Models
{
    public class City
    {
        [Key]
        
        public int CityId { get; set; }
        public string CityName { get; set; }
        [ForeignKey("State")]
        public int StateId { get; set; }
        public bool Active { get; set; }
        public State State { get; set; }
       
    }
}
