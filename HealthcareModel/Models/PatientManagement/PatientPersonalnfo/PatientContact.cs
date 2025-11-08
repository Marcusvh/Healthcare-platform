using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareModel.Models.PatientManagement.PatientPersonalnfo
{
    public class PatientContact
    {
        public Guid PatientContactId { get; set; }
        public Guid PatientId { get; set; }
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string EmergencyContactName { get; set; } = null!;
        public string EmergencyContactPhone { get; set; } = null!;

        // Navigation
        //public Patient Patient { get; set; } = null!;
    }
}
