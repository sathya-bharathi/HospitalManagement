using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HospitalManagement.Models
{
    public class AppointmentSlot
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        [JsonIgnore()]
        public Doctor Doctor { get; set; }
        [JsonIgnore()]
        public Patient Patient { get; set; }
        public string Status { get; set; } = "free";

        [NotMapped]
        public int Resource { get { return Doctor.Id; } }

        //[NotMapped]
        //public string DoctorName { get { return Doctor.Name; } }

    }
}
