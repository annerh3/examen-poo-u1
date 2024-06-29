using Newtonsoft.Json;
using ProyectoExamenU1API.Database.Entities;
using ProyectoExamenU1API.Dtos.Qualification;
using ProyectoExamenU1API.Dtos.Student;
using ProyectoExamenU1API.Services.Interfaces;
using System.Net.WebSockets;
namespace ProyectoExamenU1API.Services
{
    public class QualificationsServices : IQualificationsService 
    {
        public readonly string _JSON_STUDENTS_FILE;
        public readonly string _JSON_Qualifications_FILE;
        public QualificationsServices()
        {
            _JSON_STUDENTS_FILE = "SeedData/students.json";
            _JSON_Qualifications_FILE = "SeedData/qualifications.json";
        }
        public async Task<double> GetStudentScoreByStudentIdAndSubjectIdAsync(Guid studentId)
        {
            var studentsDto = await ReadStudentsFromFilesAsync();

            var studentDto = studentsDto.FirstOrDefault(s => s.StudentId == studentId);
            if (studentDto == null)
            {
                return 0.0;
            }

            var qualificationsDto = await ReadQualificationsFromFilesAsync();

            var studentQualifications = qualificationsDto.Where(q => q.StudentId == studentId).ToList();
            if (!studentQualifications.Any())
            {
                return 0.0;
            }

            double averageScore = studentQualifications.Average(q => q.Score);
            return averageScore;
        }


        public async Task<List<QualificationDto>> GetQualificationsOfAllAtudentsListAsync()
        {
            return await ReadQualificationsFromFilesAsync();
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


        private async Task<List<QualificationDto>> ReadQualificationsFromFilesAsync()
        {
            if (!File.Exists(_JSON_Qualifications_FILE))
            {
                return new List<QualificationDto>();
            }

            var json = await File.ReadAllTextAsync(_JSON_Qualifications_FILE);

            var qualifications = JsonConvert.DeserializeObject<List<Qualification>>(json);

            var dtos = qualifications.Select(q => new QualificationDto
            {
                SubjectId = q.SubjectId,
                StudentId = q.StudentId,
                Subject = q.Subject,
                Score = q.Score
            }).ToList();

            return dtos;
        }
    }
}
