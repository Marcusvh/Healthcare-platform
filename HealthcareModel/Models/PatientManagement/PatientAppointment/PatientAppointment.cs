using HealthcareModel.Enums;
using HealthcareModel.Models.PatientManagement.PatientPersonalnfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareModel.Models.PatientManagement.PatientAppointment
{
    public class PatientAppointment
    {
        public Guid AppointmentId { get; set; }
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public DateOnly AppointmentDate { get; set; }
        public TimeOnly AppointmentTime { get; set; }
        public int DurationInMinutes { get; set; }
        public PatientEnum.AppointmentStatus Status { get; set; } = PatientEnum.AppointmentStatus.Scheduled;
        public string? RoomNumber { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }
        public Guid? DeletedBy { get; set; }

        public Patient? Patient { get; set; }
        public PatientAppointmentDetail? AppointmentDetail { get; set; }
        public PatientAppointmentCancellation? AppointmentCancellation { get; set; }
        public ICollection<PatientAppointmentReminder>? AppointmentReminders { get; set; }
    }
}
