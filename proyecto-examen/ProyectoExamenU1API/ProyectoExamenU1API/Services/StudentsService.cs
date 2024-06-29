using Newtonsoft.Json;
using ProyectoExamenU1API.Database.Entities;
using ProyectoExamenU1API.Dtos.Entity;
using ProyectoExamenU1API.Dtos.Student;
using ProyectoExamenU1API.Services.Interfaces;

namespace ProyectoExamenU1API.Services
{
    public class StudentsService : IStudentsService
    {
        public readonly string _JSON_STUDENTS_FILE;
        public StudentsService()
        {
            _JSON_STUDENTS_FILE = "SeedData/students.json";
        }

        public async Task<List<StudentDto>> GetStudentsListAsync()
        {
            return await ReadStudentsFromFilesAsync();
        }

        public async Task<StudentDto> GetStudentByIdAsync(Guid id)
        {
            var students = await ReadStudentsFromFilesAsync();
            return students.FirstOrDefault(c => c.StudentId == id);
        }

        public async  Task<bool> CreateStudent(StudentCreateDto dto)
        {
            var studentsDtos = await ReadStudentsFromFilesAsync();
            bool flag = await CheckEntity(dto);

            if (!flag)
            {
                return false;
            }

            var studentDto = new StudentDto
            {
                StudentId = Guid.NewGuid(),
                Name = dto.Name,
                LastName = dto.LastName
            };
            studentsDtos.Add(studentDto);

           
            var students = studentsDtos.Select(s => new Student
            {
                StudentId = s.StudentId,
                Name = s.Name,
                LastName = s.LastName,
            }).ToList();

            await WriteStudentsToFileAsync(students);

            return true;
        }

        public async Task<bool> EditStudentAsync(StudentEditDto dto, Guid id)
        {
            var studentsDto = await ReadStudentsFromFilesAsync();

            var existingStudent = studentsDto.FirstOrDefault(s => s.StudentId == id);

            bool flag = await CheckEntity(dto);

            if (existingStudent is null || !flag)
            {
                return false;
            }

            for (int i = 0; i < studentsDto.Count; i++)
            {
                if (studentsDto[i].StudentId == id)
                {
                    studentsDto[i].Name = dto.Name;
                    studentsDto[i].LastName = dto.LastName;
                }
            }

            //pasar de Product Dto a Products Entity
            var students = studentsDto.Select(s => new Student
            {
                StudentId = s.StudentId,
                Name = s.Name,
                LastName = s.LastName,
            }).ToList();


            await WriteStudentsToFileAsync(students);
            return true;
        }

        public  Task<bool> DeleteStudentAsync(Guid id)
        {
            throw new NotImplementedException();
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

        // Escribir Productos
        private async Task WriteStudentsToFileAsync(List<Student> students)
        {
            var json = JsonConvert.SerializeObject(students, Formatting.Indented);

            if (File.Exists(_JSON_STUDENTS_FILE))
            {
                await File.WriteAllTextAsync(_JSON_STUDENTS_FILE, json);
            }

        }

        //Metodo para comprobar si se repite el nombre de la entidad o no
        
        private async Task<bool> CheckEntity(StudentCreateDto dto)
        {
            var students = await ReadStudentsFromFilesAsync();
            var formattedStudentName = dto.Name.ToUpper().Trim();
            return !students.Any(p => p.Name.ToUpper().Trim() == formattedStudentName);
            // retorna TRUE si no se encuentra ningún producto con un nombre que coincida con el nombre del DTO; de lo contrario, retorna FALSE.
        }
    }
}
