using System;
using System.ComponentModel.DataAnnotations;
using DCD_Store.Models;

namespace post_add.Models
{
    public class Add : FullAuditModel
    {
        //public int Id { get; set; }

        public int UserId { get; set; }

        [Required(ErrorMessage = "Title is necessary")]
        [MaxLength(50, ErrorMessage = "Maximum 50 characters are allowed")]
        [MinLength(3, ErrorMessage = "Minimum of 3 characters are required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Dscription is necessary")]
        [MaxLength(50, ErrorMessage = "Maximum 500 characters are allowed")]
        [MinLength(3, ErrorMessage = "Minimum of 10 characters are required")]
        public string Description { get; set; }

        public string City { get; set; }
        public string Category { get; set; }
    }
}

