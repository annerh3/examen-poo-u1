using ProyectoExamenU1API.Dtos.Student;

namespace ProyectoExamenU1API.Dtos.Qualification
{
    public class QualificationDto
    {
        public Guid SubjectId { get; set; }
        public Guid StudentId { get; set; }
        public string Subject { get; set; }
        public double Score { get; set; }
        
    }
}
