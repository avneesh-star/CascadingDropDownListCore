using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ddl_test.Models
{
    public class Sutdent
    {
        [Key]
        public int StudentId { get; set; }
        [Required(ErrorMessage ="Name is Required")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [StringLength(50)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Mobile is Required")]
        [StringLength(13)]
        public string Mobile { get; set; }

        [ForeignKey("Country")]
        [Display(Name ="Country")]
        [Required(ErrorMessage = "Country is Required")]
        public int CountryId { get; set; }
        [ForeignKey("State")]
        [Display(Name = "State")]
        [Required(ErrorMessage = "State is Required")]
        public int StateId { get; set; }
        [ForeignKey("City")]
        [Display(Name = "City")]
        [Required(ErrorMessage = "City is Required")]
        public int CityId { get; set; }
       
    }
}
