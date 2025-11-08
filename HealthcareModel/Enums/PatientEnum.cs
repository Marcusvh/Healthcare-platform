using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareModel.Enums
{
    public class PatientEnum
    {
        public enum MaritalStatus
        {
            Single,
            Married,
            Divorced,
            Widowed,
            Separated,
            DomesticPartnership
        }
        public enum AddressType
        {
            Home,
            Work,
            Billing,
            Shipping,
            Other
        }
        public enum TreatmentStatus
        {
            Active,
            Completed,
            OnHold,
            Cancelled
        }
        public enum AppointmentStatus
        {
            Scheduled,
            Confirmed,
            Completed,
            Cancelled,
            NoShow
        }
        public enum AppointmentReminderMethod
        {
            Email,
            SMS,
            PhoneCall,
            PostalMail,
            InAppNotification,
        }

    }
}
