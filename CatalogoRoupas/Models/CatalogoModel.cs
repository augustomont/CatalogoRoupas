using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogoRoupas.Models
{
    [Table("Catalogo")]
    public class CatalogoModel
    {
        [Column("Id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("Marca")]
        [Display(Name = "Marca")]
        public string Marca { get; set; }

        [Column("Masculino")]
        [Display(Name = "Masculino")]
        public bool Masculino { get; set; }

        [Column("Feminino")]
        [Display(Name = "Feminino")]
        public bool Feminino { get; set; }

        [Column("Peca")]
        [Display(Name = "Peça")]
        public string Peca { get; set; }
    }
}
