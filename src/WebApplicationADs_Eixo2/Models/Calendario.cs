using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationADs_Eixo2.Models
{
    [Table("Calendario")]
    public class Calendario
    {

        public int Id { get; set; }
        public int IdUser { get; set; }

        public int Ano { get; set; }

        public int Mes { get; set; }

        public int Dia { get; set; }

        public int DiaSemana { get; set; }
        
        [Column(TypeName = "time")]
        [Display(Name = "Horário Inicial")]
        public TimeSpan HoraInicio { get; set; }

        [Column(TypeName = "time")]
        [Display(Name = "Horário Final")]
        public TimeSpan HoraFim { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public DateTime DtInclusao { get; set; }
        public DateTime DtAlteracao { get; set; }

        // Relações com Usuários (Deficiente e Colaborador)
        public Usuarios? Usuario { get; set; }
    
    }
}
