using ProyectoExamenU1API.Dtos.Entity;
using ProyectoExamenU1API.Dtos.Student;

namespace ProyectoExamenU1API.Services.Interfaces
{
    public interface IStudentsService
    {
        Task<List<StudentDto>> GetStudentsListAsync();
        Task<StudentDto> GetStudentByIdAsync(Guid id);
        Task<bool> CreateStudent(StudentCreateDto dto);
        Task<bool> EditStudentAsync(StudentEditDto dto, Guid id);
        Task<bool> DeleteStudentAsync(Guid id);
    }
}
