using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationADs_Eixo2.Models
{

    [Table("Amigos")]
    public class Amigos
    {

        [Key] public int Usuario1 { get; set; }
        [Key] public int Usuario2 { get; set; }
        public DateTime DataAmizade { get; set; }
        public DateTime DtInclusao { get; set; }
        public DateTime DtAlteracao { get; set; }

        // Relações com Usuários (Deficiente e Colaborador)
        public Usuarios UsuarioUsuario1 { get; set; }
        public Usuarios UsuarioUsuario2 { get; set; }
    }
}
