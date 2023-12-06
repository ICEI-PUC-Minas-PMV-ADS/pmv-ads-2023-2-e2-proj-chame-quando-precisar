using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationADs_Eixo2.Models
{
    [Table("Calendario")]
    public class Calendario
    {

        public int Id { get; set; }
        public int IdUsuario { get; set; }
        [Display(Name = "Titulo")]
        public string Titulo { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Data Inicial")]
        public DateTime DtInicioEvento { get; set; }

        [Column(TypeName = "time")]
        [Display(Name = "Horário Inicial")]
        public TimeSpan? HoraInicio { get; set; }

        [Display(Name = "Data Final")]
        public DateTime DtFimEvento { get; set; }

        [Column(TypeName = "time")]
        [Display(Name = "Horário Final")]
        public TimeSpan? HoraFim { get; set; }

        [Display(Name = "Abrir um chamado")]
        public bool PedindoAjuda { get; set; }

        [Display(Name = "Data de Inclusão")]
        public DateTime DtInclusao { get; set; }

        [Display(Name = "Data de Alteração")]
        public DateTime? DtAlteracao { get; set; }

        // Relações com Usuários (IdUser - Deficiente e Colaborador)
        public Usuarios? Usuario { get; set; }
        public Agendamento? Agendamento { get; set; }
      

    }
}
