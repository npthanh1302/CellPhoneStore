using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CellphoneStoreWebAPI.Models
{
    [Table("Manufacturer")]
    public class Manufacturer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Key]
        public int ManufacturerID { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

    }
}
