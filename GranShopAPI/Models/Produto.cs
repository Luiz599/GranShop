using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GranShopAPI.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }

        [Required]
        [StringLength(30)]
        public string Nome { get; set; }

        [Required]
        [StringLength(100)]
        public string Descrição { get; set; }

        [Required]
        public int Estoque { get; set; }

        [Required]
        public decimal ValorCusto { get; set; }

        [Required]
        public decimal ValorVenda { get; set; }

        [Required]
        public Boolean Destaque { get; set; }
    }
}