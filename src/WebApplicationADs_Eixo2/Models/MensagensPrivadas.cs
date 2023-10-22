using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationADs_Eixo2.Models
{

    [Table("MensagensPrivadas")]
    public class MensagensPrivadas
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("IdRemetente")]
        public int IdRemetente { get; set; }

        [ForeignKey("IdDestinatario")]
        public int IdDestinatario { get; set; }


        public DateTime DataEnvio { get; set; }

        public string TextoMensagem { get; set; }


        public DateTime DtInclusao { get; set; }
        public DateTime DtAlteracao { get; set; }

       
        
        // Relações com Usuários (Deficiente e Colaborador)
        public Usuarios? UsuarioRemetente { get; set; }

        public Usuarios? UsuarioDestinatario { get; set; }
    }
}
