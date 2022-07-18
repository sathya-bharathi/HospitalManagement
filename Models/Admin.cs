using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Models
{
    public class Admin
    {
        [Key]
        public string EmailId { get; set; }

        public string Name { get; set; }
        public string Password { get; set; }
    }
}
