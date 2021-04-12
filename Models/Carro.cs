using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteProduto.Models
{
    public class Carro
    {
        [Key]
        public long? CarroId { get; set; }
        [Required]
        public string Marca { get; set; }
        [Required]
        public string Modelo { get; set; }
        [Required]
        public string Cor { get; set; }

        [Display(Name = "Numero de Rodas")]
        [Required]
        public int NumRodas { get; set; }

        [Display(Name = "Numero Chassi")]
        [Required]
        public int NumChassi { get; set; }

    }
}
