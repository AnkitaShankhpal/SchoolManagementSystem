using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;




namespace SchoolManagementSystem.Models
{
    public class Membership
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter your email address")]
        [EmailAddress]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Enter your password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password required")]
        [CompareAttribute("Password", ErrorMessage = "Password doesn't match.")]
        public string RepeatPassword { get; set; }

        [Required(ErrorMessage = "Enter first name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter last name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

    }
}