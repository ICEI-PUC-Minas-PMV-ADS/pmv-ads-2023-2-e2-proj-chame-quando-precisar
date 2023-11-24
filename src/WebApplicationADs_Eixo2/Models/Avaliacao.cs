using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationADs_Eixo2.Models
{
    [Table("Avaliacao")]
    public class Avaliacao
    {
        
        public int Id { get; set; }        
        public int IdUsuario { get; set; } 
        public int IdAgendamento { get; set; }

        [Range(1, 5)]
        public int Nota { get; set; }

        [MaxLength(500)]
        [Display(Name = "Comentário")]
        public string? Comentario { get; set; }

        [Display(Name = "Data de Inclusão")]
        public DateTime DtInclusao { get; set; }

        [Display(Name = "Data de Alteração")]
        public DateTime? DtAlteracao { get; set; }


        public Usuarios Usuario { get; set; }
        public Agendamento Agendamento { get; set; }
    }
}
