using System;
using System.ComponentModel.DataAnnotations;

namespace ModelValidation.Models
{

    public class Appointment
    {
        
        [Required]
        [Display(Name = "name")]   
        public string ClientName { get; set; }

        [UIHint("Date")]
        [Required(ErrorMessage ="Please enter Date")]
        public DateTime Date { get; set; }
        
        [Range(typeof(bool), "true", "true", ErrorMessage = "You mast accept the Terms" )]
        public bool TermsAccepted { get; set; }
    }
}