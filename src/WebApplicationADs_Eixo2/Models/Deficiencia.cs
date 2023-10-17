using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationADs_Eixo2.Models
{
    [Table("Deficiencia")]
    public class Deficiencia
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage ="Este campo é Obrigatório")]
        public string Descricao { get; set; }


        public DateTime DtInclusao { get; set; }
        public DateTime DtAlteracao { get; set; }

    }
}
