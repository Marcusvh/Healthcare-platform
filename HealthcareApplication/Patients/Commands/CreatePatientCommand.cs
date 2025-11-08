using HealthcareModel.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareApplication.Patients.Commands
{
    public record CreatePatientCommand(
    string FirstName,
    string LastName,
    DateTime DateOfBirth,
    string? Gender,  
    PatientEnum.MaritalStatus MaritalStatus,  
    string Occupation  
) : IRequest<Guid>;
}
