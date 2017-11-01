using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CellphoneStoreWebAPI.Models
{
    [Table("Items")]
    public class Cellphone
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Key]
        public int ItemID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Int64 Price { get; set; }
        [Required]
        public string Description { get; set; }
        
        [Required]
        public string Image { get; set; }
    }
}
