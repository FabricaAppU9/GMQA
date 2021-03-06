﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace WebAppCoreGMQA.ViewModels.Projeto
{
    [Table("Projetos")]
    public class ProjetoViewModel
    {
        [Key]
        public int IdProjeto { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Cliente do Projeto")]
        public string ClienteProjeto { get; set; }

        [Required]
        [Display(Name = "Data de Inicio")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataInicio { get; set; }
        
        [Required]
        [Display(Name = "Data de Fim ")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataFim { get; set; }

        [Required]
        [Display(Name = "Data Real ")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataReal { get; set; }

        [Required]
        [Display(Name = "Usuário Responsável")]
        public string  IdUserResponsavelProjeto { get; set; }

        [Required]
        [Display(Name = "Usuário adm ")]
        public string IdUserAdmProjeto { get; set; }

        [Required]
        [Display(Name = "Status")]
        public string Status { get; set;}
        // public IList<UsuarioViewModel>  ListaUsuarios { get; set; }

    }
}