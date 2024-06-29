using System.ComponentModel.DataAnnotations;

namespace ProyectoExamenU1API.Dtos.Entity
{
    public class StudentCreateDto
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El {0} del Estuddiante es requerido.")]
        public string Name { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El {0} del Estuddiante es requerido.")]
        public string LastName { get; set; }
    }
}
