﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CellphoneStoreWebAPI.Models
{
    [Table("Items")]
    public class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ItemID { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        public string Image { get; set; }

        public string Description { get; set; }

        public string DetailedDescription { get; set; }
        public int CurrentQuantity { get; set; }
        [Required]
        public int ManufacturerID { get; set; }
    }

}
