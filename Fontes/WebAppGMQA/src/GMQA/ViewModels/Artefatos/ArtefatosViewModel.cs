using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCoreGMQA.ViewModels.Artefatos
{
    [Table("Artefatos")]
    public class ArtefatosViewModel
    {
        [Key]
        public int IdArtefato { get; set; }

        [Required]
        public int IdCiclo { get; set; }

        [Required]
        public int IdProjeto { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Caminho")]
        public string Caminho { get; set; }

        [Required]
        [Display(Name = "Status")]
        public int Status { get; set; }

        [NotMapped]
        [Display(Name = "Projeto")]
        public string NomeProjeto { get; set; }

        [NotMapped]
        [Display(Name = "Ciclo")]
        public string NomeCiclo { get; set; }
    }
}
