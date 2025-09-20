using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.Application.Commands.AddStudent;
using Student.Application.Commands.GetStudent;
using Student.Domain.Entities;

namespace Student.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StudentController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<ActionResult<StudentEntity>> AddStudent([FromBody] StudentRequest request)
        {
            if (request == null)
                return BadRequest("Requête invalide");

            try
            {
                var student = await _mediator.Send(request);
                return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erreur serveur : {ex.Message}");
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<StudentEntity>> GetStudentById(int id)
        {
            var studentQuery = new GetStudentQuery(id);

            var student = await _mediator.Send(studentQuery);

            return student;
        }
    }
}
