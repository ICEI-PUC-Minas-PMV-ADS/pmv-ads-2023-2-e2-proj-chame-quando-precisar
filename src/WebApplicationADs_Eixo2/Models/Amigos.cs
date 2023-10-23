using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationADs_Eixo2.Models
{

    [Table("Amigos")]
    public class Amigos
    {
        [ForeignKey("Usuario1")]
        [Key] public int Usuario1 { get; set; }
        [ForeignKey("Usuario2")]
        [Key] public int Usuario2 { get; set; }
        public DateTime DataAmizade { get; set; }
        public DateTime DtInclusao { get; set; }
        public DateTime DtAlteracao { get; set; }

        // Relações com Usuários (Deficiente e Colaborador)
        public Usuarios? User1 { get; set; }
        public Usuarios? User2 { get; set; }
    }
}
