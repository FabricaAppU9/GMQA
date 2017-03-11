﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCoreGMQA.ViewModels.Ciclo
{   
    [Table ("Ciclos")]
    public class CicloViewModel
    {
        [Key]
        public int IdCiclos { get; set; }

        [Required]
        [Display(Name = "Numero Ciclos")]
        public int NumeroCiclo { get; set; }

        [Required]
        [Display(Name = "Fase do Ciclo")]
        public string FaseCiclo { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data de Inicio")]
        public DateTime DataInicio { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data Final")]
        public DateTime DataFim { get; set; }

        [Required]
        [Display(Name = "Projeto")]
        public int IdProjeto { get; set; }

        [Required]
        [Display(Name = "Etapa")]
        public int IdEtapas { get; set; }

    }
}
