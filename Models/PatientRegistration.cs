using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagement.Models
{
    public class PatientRegistration
    {
        [Key]
        public string EmailId { get; set; }   
        public string Name { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        [NotMapped]
        public string ConfirmPassword { get; set; }
    }
}
