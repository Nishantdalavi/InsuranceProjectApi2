﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EInsuranceProject.Model
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [Required(ErrorMessage = "This Field is required.")]
        [StringLength(50, ErrorMessage = " First Name should not exceed 50 characters")]
        public string AdminFirstName { get; set; }

        [Required(ErrorMessage = "This Field is required.")]
        [StringLength(50, ErrorMessage = " Last Name should not exceed 50 characters")]
        public string AdminLastName { get; set; }
        public bool Status { get; set; }

        

        //[ForeignKey("User")]
       // public int UserId { get; set; }
        //public User? User { get; set; }
    }
}
