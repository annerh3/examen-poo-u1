using Microsoft.AspNetCore.Mvc;
using ProyectoExamenU1API.Dtos.Entity;
using ProyectoExamenU1API.Dtos.Student;
using ProyectoExamenU1API.Services.Interfaces;
namespace ProyectoExamenU1API.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsService _studentsService;
        public StudentsController(IStudentsService studentsService)
        {
            _studentsService = studentsService;
        }

        //Metodos HTTP:
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _studentsService.GetStudentsListAsync());
        }


        [HttpGet("{Id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var student = await _studentsService.GetStudentByIdAsync(id);

            if (student == null)
            {
                return NotFound(new { Message = $"No se encontró al estudante: {id}" });
            }

            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult> Create(StudentCreateDto dto)
        {
            bool flag = await _studentsService.CreateStudent(dto);

            if (!flag)
            {
                return BadRequest($"⚠ El estudiante '{dto.Name}' ya existe.");
            }

            return StatusCode(201, new { message = "✅ Estudinte registrado exitosamente." });
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult> Edit(StudentEditDto dto, Guid id)
        {
            var result = await _studentsService.EditStudentAsync(dto, id);

            if (!result)
            {
                return NotFound();
            }
            return Ok($"El estudiante con el Id: {id}, ha sido editado.\nContiene el nombre: '{dto.Name}'.");
        }
    }
}
