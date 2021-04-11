using System.ComponentModel.DataAnnotations;

namespace TesteApi.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(60, ErrorMessage = "Campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Campo deve conter entre 3 e 60 caracteres")]
        public string Titulo { get; set; }
    }
}