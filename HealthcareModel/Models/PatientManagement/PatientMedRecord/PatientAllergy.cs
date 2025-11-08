using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareModel.Models.PatientManagement.PatientMedRecord
{
    public class PatientAllergy
    {
        public Guid AllergyId { get; set; }
        public Guid MedicalRecordId { get; set; }
        public string AllergyName { get; set; } = null!;
        public string Severity { get; set; } = null!;
        public string? Notes { get; set; }
    }
}
