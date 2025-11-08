using HealthcareModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareModel.Models.PatientManagement.PatientPersonalnfo
{
    public class PatientAddress
    {
        public Guid PatientAddressId { get; set; }
        public Guid PatientId { get; set; }
        public string Address1 { get; set; } = null!;
        public string? Address2 { get; set; }
        public PatientEnum.AddressType Address1Type { get; set; }
        public PatientEnum.AddressType? Address2Type { get; set; }

        // Navigation
        public AddressLocation? Location { get; set; }
    }
}
