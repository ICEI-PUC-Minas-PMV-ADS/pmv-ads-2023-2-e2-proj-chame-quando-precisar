using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationADs_Eixo2.Models
{

    [Table("Agendamento")]
    public class Agendamento
    {
        [Key] public int Id { get; set; }
        
        public int Deficiente { get; set; }

        public int Colaborador { get; set; }

        public int IdCalendario { get; set; }

        public string Descricao { get; set; }

        public DateTime DtInclusao { get; set; }
        public DateTime DtAlteracao { get; set; }

        // Relações com Usuários (Deficiente e Colaborador)
        public Usuarios UsuarioDeficiente { get; set; }
        public Usuarios UsuarioColaborador { get; set; }
        public Calendario CalendarioIdCalendario { get; set; }

    }
}
