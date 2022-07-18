using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagement.Models
{
    public class DoctorRegistration
    {
        [Key]
        public string EmailId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }
        public string Specialization { get; set; }
        [NotMapped]
        public string ConfirmPassword { get; set; }


    }
}
