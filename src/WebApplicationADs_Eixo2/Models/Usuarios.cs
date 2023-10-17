using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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


        // Relações com Usuários (Deficiente e Colaborador)
        public Perfil PerfilIdPerfil { get; set; }
        public Deficiencia DeficienciaIdDeficiencia { get; set; }

    }
}
