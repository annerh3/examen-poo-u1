using ProyectoExamenU1API.Dtos.Qualification;
using ProyectoExamenU1API.Dtos.Student;

namespace ProyectoExamenU1API.Services.Interfaces
{
    public interface IQualifications
    {
        Task<QualificationDto> GetStudentScoreByStudentIdAndSubjectIdAsync(StudentDto studentId, QualificationDto subjectId);
    }
}
