using HealthcareModel.Enums;
using HealthcareModel.Models.PatientManagement.PatientPersonalnfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareModel.Models.PatientManagement
{
    public class PatientTreatmentPlan
    {
        public Guid TreatmentPlanId { get; set; }
        public Guid PatientId { get; set; }
        public string Diagnosis { get; set; } = null!;
        public List<string> PrescribedMedications { get; set; } = new List<string>();
        public string TreatmentDescription { get; set; }
        public string? RecommendedTests { get; set; }
        public string? FollowUpInstructions { get; set; }
        public DateTime NextReviewDate { get; set; }
        public PatientEnum.TreatmentStatus Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }
        public Guid? DeletedBy { get; set; }

        public Patient? Patient { get; set; }

    }
}
