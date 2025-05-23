using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GranShopAPI.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Nome { get; set; }
    }
}