using HealthcareModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareModel.Models.PatientManagement.PatientAppointment
{
    public class PatientAppointmentReminder
    {
        public Guid ReminderId { get; set; }
        public Guid AppointmentId { get; set; }
        public PatientEnum.AppointmentReminderMethod ReminderMethod { get; set; } // e.g., 'Email', 'SMS', 'Phone Call'
        public bool IsSent { get; set; } = false;
        public DateTime? SentAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }
        public Guid? DeletedBy { get; set; }
    }
}
