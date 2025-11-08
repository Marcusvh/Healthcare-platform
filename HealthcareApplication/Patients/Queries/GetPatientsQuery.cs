using HealthcareApplication.Patients.DTOs;
using HealthcareModel.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareApplication.Patients.Queries
{
    public record GetPatientsQuery() : IRequest<List<PatientDTO>>;
}
