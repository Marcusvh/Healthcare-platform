using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareModel.Models.PatientManagement.PatientAppointment
{
    public class PatientAppointmentCancellation
    {
        public Guid CancellationId { get; set; }
        public Guid AppointmentId { get; set; }
        public string CancellationReason { get; set; } = null!;
        public DateTime? CancelledAt { get; set; }
        public Guid? CancelledBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }
        public Guid? DeletedBy { get; set; }
    }
}
