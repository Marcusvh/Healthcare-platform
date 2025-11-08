using HealthcareInfrastructure.EF;
using HealthcareModel.Models.PatientManagement.PatientPersonalnfo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareApplication.Patients.Commands
{
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, Guid>
    {
        private readonly PatientContext _context;
        public CreatePatientCommandHandler(PatientContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            Patient patient = new Patient
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender,
                MaritalStatus = request.MaritalStatus,
                Occupation = request.Occupation
            };
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync(cancellationToken);

            return patient.PatientId;
        }
    }
}
