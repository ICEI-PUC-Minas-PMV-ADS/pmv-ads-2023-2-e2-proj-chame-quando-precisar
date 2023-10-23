using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationADs_Eixo2.Models
{

    [Table("DadosUsuarios")]
    public class DadosUsuarios
    {

        [Key] public int IDUser { get; set; }

        public string SobreUsuario { get; set; }

        public byte[] Foto { get; set; }

        public string Cep { get; set; }

        public string Rua { get; set; }

        public int Numero { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public DateTime DataNacimento { get; set; }

        public string Telefone { get; set; }

        public string Celular { get; set; }

        public int IdDeficiencia { get; set; }

        public DateTime DtInclusao { get; set; }
        public DateTime DtAlteracao { get; set; }

        [ForeignKey("IDUser")]

        // Relações com Usuários (Deficiente e Colaborador)
        public Usuarios? Usuario { get; set; }
        public Deficiencia? Deficiencia { get; set; }
    }
}
