using System.ComponentModel.DataAnnotations;

namespace TesteApi.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(60, ErrorMessage = "Campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string Titulo { get; set; }


        [MaxLength(1024, ErrorMessage = "Campo deve conter no max 1024 caracteres")]
        public string Descricao { get; set; }


        [Required(ErrorMessage = "Campo Obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public int Preco { get; set; }


        [Required(ErrorMessage = "Campo Obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Categoria Inválida")]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}