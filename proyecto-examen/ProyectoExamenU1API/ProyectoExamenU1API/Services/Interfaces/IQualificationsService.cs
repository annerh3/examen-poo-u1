using ProyectoExamenU1API.Dtos.Qualification;
using ProyectoExamenU1API.Dtos.Student;

namespace ProyectoExamenU1API.Services.Interfaces
{
    public interface IQualificationsService
    {
        Task<double> GetStudentScoreByStudentIdAndSubjectIdAsync(Guid studentId);

        Task<List<QualificationDto>> GetQualificationsOfAllAtudentsListAsync();

    }
}
