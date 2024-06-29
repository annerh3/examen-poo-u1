using Newtonsoft.Json;
using ProyectoExamenU1API.Database.Entities;
using ProyectoExamenU1API.Dtos.Qualification;
using ProyectoExamenU1API.Dtos.Student;
using ProyectoExamenU1API.Services.Interfaces;
namespace ProyectoExamenU1API.Services
{
    public class QualificationsServices : IQualifications 
    {
        public readonly string _JSON_STUDENTS_FILE;
        public readonly string _JSON_Qualifications_FILE;
        public QualificationsServices()
        {
            _JSON_STUDENTS_FILE = "SeedData/students.json";
            _JSON_Qualifications_FILE = "SeedData/qualifications.json";
        }
        public async Task<QualificationDto> GetStudentScoreByStudentIdAndSubjectIdAsync(StudentDto studentId, QualificationDto subjectId)
        {
            var studentsDto = await ReadStudentsFromFilesAsync();

           // var studentDto = new StudentDto
          //  {
                //StudentId = 
           // }
            return studentsDto.FirstOrDefault(s => s.StudentId == studentId);
        }




        private async Task<List<StudentDto>> ReadStudentsFromFilesAsync()
        {
            if (!File.Exists(_JSON_STUDENTS_FILE))
            {
                return new List<StudentDto>();
            }

            var json = await File.ReadAllTextAsync(_JSON_STUDENTS_FILE);

            var students = JsonConvert.DeserializeObject<List<Student>>(json);

            var dtos = students.Select(c => new StudentDto
            {
                StudentId = c.StudentId,
                Name = c.Name,
                LastName = c.LastName,
            }).ToList();

            return dtos;
        }
    }
}
