using HealthcareApplication.Patients.DTOs;
using HealthcareInfrastructure.EF;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareApplication.Patients.Queries
{
    public record GetPatientByIdQuery(Guid PatientId) : IRequest<PatientDTO>;
    public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, PatientDTO>
    {
        private readonly PatientContext _context;
        public GetPatientByIdQueryHandler(PatientContext context)
        {
            _context = context;
        }
        public async Task<PatientDTO> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Patients
                .AsNoTracking()
                .Where(p => p.PatientId == request.PatientId)
                .Select(p => new PatientDTO
                {
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    DateOfBirth = p.DateOfBirth,
                    Gender = p.Gender,
                    MaritalStatus = p.MaritalStatus,
                    Occupation = p.Occupation
                })
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
