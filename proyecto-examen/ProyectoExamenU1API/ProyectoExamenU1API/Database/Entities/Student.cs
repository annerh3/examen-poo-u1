using System.ComponentModel.DataAnnotations;

namespace ProyectoExamenU1API.Database.Entities
{
    public class Student
    {
        public Guid StudentId {get; set;}

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El {0} del Estuddiante es requerido.")]

        public string Name {get; set;}

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El {0} del Estuddiante es requerido.")]
        public string LastName { get; set;}
             
    }
}
