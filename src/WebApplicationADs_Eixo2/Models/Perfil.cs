﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationADs_Eixo2.Models
{

    [Table("Perfil")]
    public class Perfil
    {

        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Este campo é Obrigatório")]
        public string Descricao { get; set; }

        public bool Administrador { get; set; }

        public bool Deficiente { get; set; }

        public bool Colaborador { get; set; }

        public bool Ativo { get; set; }


        public DateTime DtInclusao { get; set; }
        public DateTime DtAlteracao { get; set; }
    }
}