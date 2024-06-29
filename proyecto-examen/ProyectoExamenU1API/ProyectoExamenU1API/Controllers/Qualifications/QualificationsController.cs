using Microsoft.AspNetCore.Mvc;
using ProyectoExamenU1API.Database.Entities;
using ProyectoExamenU1API.Services;
using ProyectoExamenU1API.Services.Interfaces;

namespace ProyectoExamenU1API.Controllers.Qualifications
{
    [ApiController]
    [Route("api/qualifications")]
    public class QualificationsController : ControllerBase
    {
        private readonly IQualificationsService _qualificacionsService;

        public QualificationsController(IQualificationsService qualificacionsService)
        {
            _qualificacionsService = qualificacionsService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllQualifications()
        {
            return Ok(await _qualificacionsService.GetQualificationsOfAllAtudentsListAsync());
        }

        [HttpGet("{studentId}")]
        public async Task<ActionResult> GetQualificationStudent(Guid studentId)
        {
            var qualification = await _qualificacionsService.GetStudentScoreByStudentIdAndSubjectIdAsync(studentId);
            return Ok(new { Message = $"El promedio del estudiante con ID {studentId} es de: {qualification}" });
        }
    }
}
