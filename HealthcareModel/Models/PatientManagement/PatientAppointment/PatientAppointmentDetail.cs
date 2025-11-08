using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareModel.Models.PatientManagement.PatientAppointment
{
    public class PatientAppointmentDetail
    {
        public Guid AppointmentDetailId { get; set; }
        public Guid AppointmentId { get; set; }
        public string ReasonForVisit { get; set; }
        public string? Notes { get; set; }
        public PatientTreatmentPlan? TreatmentPlan { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }
        public Guid? DeletedBy { get; set; }
    }
}
