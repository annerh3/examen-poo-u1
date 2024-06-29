using System.ComponentModel.DataAnnotations;

namespace ProyectoExamenU1API.Dtos.Qualification
{
    public class QualificationCreateDto
    {
        [Display(Name = "ID")]
        [Required(ErrorMessage = "El {0} del estudiante es requerido.")]
        public Guid StudentId { get; set; }


        [Display(Name = "Materia")]
        [Required(ErrorMessage = "La {0} es requerida.")]
        public string Subject { get; set; }

        [Display(Name = "Nota")]
        [Required(ErrorMessage = "La {0} de la materia es requerida.")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        [StringLength(2, ErrorMessage = "La {0} de la materia no es valida.")]
        public double Score { get; set; }

    }
}
