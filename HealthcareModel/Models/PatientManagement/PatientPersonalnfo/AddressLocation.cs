using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareModel.Models.PatientManagement.PatientPersonalnfo
{
    public class AddressLocation
    {
        public Guid AddressLocationId { get; set; }
        public Guid PatientAddressId { get; set; }
        public string City { get; set; } = null!;
        public string? State { get; set; }
        public string ZipCode { get; set; } = null!;
        public string Country { get; set; } = null!;

        // Navigation
        //public PatientAddress Address { get; set; } = null!;
    }
}
