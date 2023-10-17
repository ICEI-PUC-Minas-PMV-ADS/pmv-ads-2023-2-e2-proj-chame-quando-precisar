using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationADs_Eixo2.Models
{
    [Table("Notificacoes")]
    public class Notificacoes
    {
        [Key]
        public int Id { get; set; }


        public int IdDestinatario { get; set; }


        public DateTime DataEnvio { get; set; }

        public string TextoMensagem { get; set; }

        public bool lido { get; set; }


        public DateTime DtInclusao { get; set; }
        public DateTime DtAlteracao { get; set; }


        // Relações com Usuários (Deficiente e Colaborador)
        
        public Usuarios UsuarioDestinatario { get; set; }
    }
}
