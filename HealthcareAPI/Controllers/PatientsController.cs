using HealthcareModel.Models.PatientManagement.PatientPersonalnfo;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using HealthcareApplication.Patients.Commands;
using HealthcareApplication.Patients.Queries;
using HealthcareApplication.Patients.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthcareAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<PatientsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> Get()
        {
            var patients = await _mediator.Send(new GetPatientsQuery());
            return patients != null ? Ok(patients) : NotFound();
        }

        // GET api/<PatientsController>/5
        // 07c023a2-35b4-46d7-af71-6d81f499b5ea
        [HttpGet("{PatientId}")]
        public async Task<ActionResult<PatientDTO>> Get(Guid PatientId)
        {
            var patient = await _mediator.Send(new GetPatientByIdQuery(PatientId));
            return patient != null ? Ok(patient) : NotFound();
        }
        
        // POST api/<PatientsController>
        [HttpPost]
        public async Task<IActionResult> Post(CreatePatientCommand command)
        {
            var patient = await _mediator.Send(command);
            return patient != Guid.Empty ? Ok(patient) : NotFound();
        }

        // PUT api/<PatientsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PatientsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
