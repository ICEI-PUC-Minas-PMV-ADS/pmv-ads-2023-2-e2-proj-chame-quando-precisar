using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplicationADs_Eixo2.Models.Attributes;

namespace WebApplicationADs_Eixo2.Models
{

    [Table("Usuarios")]
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Campo Obrigatório")]
        public string Nome { get; set; }

        [Required (ErrorMessage ="Campo Obrigatório")]
        public string SobreNome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]        
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public int IdPerfil { get; set; }

        public bool Ativo { get; set; }
        public DateTime DtInclusao { get; set; }
        public DateTime DtAlteracao { get; set; }


        // Relação usuário e perfil
        [ForeignKey("IdPerfil")]
        public Perfil? Perfil { get; set; }

        public DadosUsuarios? DadosUsuarios { get; set; }

        public ICollection<Notificacoes>? Notificacoes { get; set; }

        public ICollection<Calendario>? AllCalendario { get; set; }
    }
}
