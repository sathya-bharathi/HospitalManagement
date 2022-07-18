using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Models
{
    public class HMSDBContext: DbContext
    {
        public HMSDBContext() { }
        public HMSDBContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<DoctorRegistration> DoctorRegistrations { get; set; }
        public DbSet<PatientRegistration> PatientRegistrations { get; set; }
        public DbSet<AppointmentSlot> AppointmentSlots { get; set; }


    }
}
