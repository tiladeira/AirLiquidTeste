using Domain.Domain.Models.Base;

using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Domain.Models
{
    public class Cliente : IBaseEntity
    {
        [Key]
        [Required(ErrorMessage = "Propriedade {0} é obrigatória.")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Propriedade {0} é obrigatória.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Propriedade {0} é obrigatória.")]
        public int Idade { get; set; }
    }
}
