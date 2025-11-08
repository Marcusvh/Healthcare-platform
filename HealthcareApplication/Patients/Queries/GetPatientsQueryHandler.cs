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
    public class GetPatientsQueryHandler: IRequestHandler<GetPatientsQuery, List<PatientDTO>>
    {
        private readonly PatientContext _context;
        public GetPatientsQueryHandler(PatientContext context)
        {
            _context = context;
        }

        public async Task<List<PatientDTO>> Handle(GetPatientsQuery request, CancellationToken cancellationToken)
        {

            return await _context.Patients
            .AsNoTracking()
            .Select(p => new PatientDTO(
                p.FirstName,
                p.LastName,
                p.DateOfBirth,
                p.Gender,
                p.MaritalStatus,
                p.Occupation
            ))
            .ToListAsync(cancellationToken);
        }
    }
}
