using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationADs_Eixo2.Models
{

    [Table("AvaliacaoAgendamento")]
    public class AvaliacaoAgendamento
    {

        
        [Key]
        [ForeignKey("IdAgendamento")]
        public int IdAgendamento { get; set; }
        [Key]
        [ForeignKey("Avaliador")]
        public int Avaliador { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string Conteudo { get; set; }
        public DateTime DtInclusao { get; set; }
        public DateTime DtAlteracao { get; set; }

        // Relações com Usuários (Deficiente e Colaborador)
        public Agendamento? Agendamento { get; set; }
        public Usuarios? UserAvaliador { get; set; }
    }
}
