using HealthcareModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareApplication.Patients.DTOs
{
    public record PatientDTO
    {
        public PatientDTO(string firstName, string lastName, DateTime dateOfBirth, string? gender, PatientEnum.MaritalStatus maritalStatus, string occupation)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            MaritalStatus = maritalStatus;
            Occupation = occupation;
        }
        public PatientDTO()
        {
            
        }

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public PatientEnum.MaritalStatus MaritalStatus { get; set; }
        public string Occupation { get; set; }
    }
}
