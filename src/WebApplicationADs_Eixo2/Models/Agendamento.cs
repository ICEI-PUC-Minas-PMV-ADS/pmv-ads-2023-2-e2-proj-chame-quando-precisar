using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationADs_Eixo2.Models
{

    [Table("Agendamento")]
    public class Agendamento
    {
       
        public int Id { get; set; }
        public int IdCalendario { get; set; }
        public int IdColaborador { get; set; }

        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }

        [Display(Name = "Data de Inclusão")]
        public DateTime DtInclusao { get; set; }

        [Display(Name = "Data de Alteração")]
        public DateTime? DtAlteracao { get; set; } 
        
        //relacionamentos
        public Usuarios Colaborador { get; set; }
        public Calendario? Calendario { get; set; }
        public ICollection<Avaliacao>? Avaliacoes { get; set; }

    }
}
