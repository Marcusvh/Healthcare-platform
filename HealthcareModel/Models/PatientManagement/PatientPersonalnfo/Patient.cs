using HealthcareModel.Enums;
using HealthcareModel.Models.PatientManagement.PatientMedRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareModel.Models.PatientManagement.PatientPersonalnfo
{
    public class Patient
    {
        public Guid PatientId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public PatientEnum.MaritalStatus MaritalStatus { get; set; }
        public string Occupation { get; set; }


        // Navigation properties
        public PatientContact? Contact { get; set; }
        public ICollection<PatientAddress> Addresses { get; set; }
        public PatientAudit Audits { get; set; }
        public ICollection<PatientMedicalRecord>? MedicalRecords { get; set; }
    }

}
