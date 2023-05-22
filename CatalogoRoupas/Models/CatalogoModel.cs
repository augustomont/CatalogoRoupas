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
        [Display(Name = "Sexo")]
        public bool Marculino { get; set; }

        [Column("Peca")]
        [Display(Name = "Peça")]
        public string Peca { get; set; }
    }
}
