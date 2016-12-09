using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InvMVC.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60, ErrorMessage = "Deve possuir no mínimo 5 caractéres", MinimumLength = 5)]
        public string Nome { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Deve possuir no mínimo 5 caractéres", MinimumLength = 5)]
        public string Email { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Deve possuir no mínimo 8 caractéres", MinimumLength = 8)]
        public string Senha { get; set; }

        public virtual List<Ativo> Ativos { get; set; }
    }
}