using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Models
{
    public class Patient
    {

        [Key]
        public int Id { get; set; }
        public string Password { get; set; }
    }
}
