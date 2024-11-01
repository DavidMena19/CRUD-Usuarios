using System.ComponentModel.DataAnnotations;

namespace crudUsuariosMVC.Models
{
    public class Contacto2
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int numeroTelefonico { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Mail { get; set; }


        //public DateTime FechaCreacion { get; set; }
    }
}
