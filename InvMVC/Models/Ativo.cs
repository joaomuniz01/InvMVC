using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InvMVC.Models
{
    public class Ativo
    {
        public int AtivoId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Deve possuir no mínimo 5 caractéres", MinimumLength = 5)]
        public string Descricao { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Deve possuir no mínimo 3 caractéres", MinimumLength = 3)]
        public string Tipo { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Deve possuir no mínimo 5 caractéres", MinimumLength = 5)]
        public string Local { get; set; }

        public int UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}