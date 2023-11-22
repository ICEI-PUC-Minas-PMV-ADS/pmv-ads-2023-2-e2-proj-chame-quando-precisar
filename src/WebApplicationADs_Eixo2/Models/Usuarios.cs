using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplicationADs_Eixo2.Models.Attributes;

namespace WebApplicationADs_Eixo2.Models
{

    [Table("Usuarios")]
    public class Usuarios
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage ="Campo Obrigatório")]
        public string Nome { get; set; }

        [Required (ErrorMessage ="Campo Obrigatório")]
        [Display(Name = "Sobre Nome")]
        public string SobreNome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]        
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Perfil")]
        public int IdPerfil { get; set; }

        public bool Ativo { get; set; }
        public DateTime DtInclusao { get; set; }
        public DateTime? DtAlteracao { get; set; }

        //[ForeignKey("IdPerfil")]
        public Perfil? Perfil { get; set; }        
        public DadosUsuarios? DadosUsuarios { get; set; }

        //public ICollection<Notificacoes>? Notificacoes { get; set; }

        public ICollection<Calendario>? Calendarios { get; set; }
    }
}
