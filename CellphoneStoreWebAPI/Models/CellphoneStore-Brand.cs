using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CellphoneStoreWebAPI.Models
{
    [Table("Manufacturer")]
    public class Brand
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Key]
        public int ManufacturerID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Info { get; set; }
        public string ImageLogo { get; set; }
    }
}
