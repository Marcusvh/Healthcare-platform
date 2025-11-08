using HealthcareModel.Models.PatientManagement.PatientPersonalnfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareModel.Models.PatientManagement.PatientMedRecord
{
    public class PatientMedicalRecord
    {
        public Guid MedicalRecordId { get; set; }
        public Guid PatientId { get; set; }
        public string BloodType { get; set; } = null!;
        public string SmokingStatus { get; set; } = null!;
        public string AlcoholConsumption { get; set; } = null!;
        public double HeightInCm { get; set; }
        public double WeightInKg { get; set; }
        public double BMI { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }
        public Guid? DeletedBy { get; set; }

        public PatientMedicalRecord()
        {
            BMI = Math.Round(WeightInKg / Math.Pow(HeightInCm / 100, 2), 2);
        }

        public ICollection<PatientAllergy>? Allergies { get; set; }
        public ICollection<PatientMedication>? Medications { get; set; }
        //public Patient? Patient { get; set; }
    }
}
