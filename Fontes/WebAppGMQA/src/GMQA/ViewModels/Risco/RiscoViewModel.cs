﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCoreGMQA.ViewModels.Risco
{
    [Table("Riscos")]
    public class RiscoViewModel
    {
        // Chave
        [Key]
        public int IdRisco { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string DescricaoRisco { get; set; }

        [Required]
        [Display(Name = "Projeto")]
        public int IdProjeto { get; set; }

        [Required]
        [Display(Name = "Ciclo")]
        public int IdCiclo { get; set; }

        [Required]
        [Display(Name = "Categoria")]
        public int Categoria { get; set; }

        [Required]
        [Display(Name = "Probabilidade de Ocorrência")]
        public int ProbabilidadeOcorrencia { get; set; }

        [Required]
        [Display(Name = "Efeito de Ocorrência")]
        public int EfeitoOcorrencia { get; set; }

        [Required]
        [Display(Name = "Ação")]
        public string Acao { get; set; }

        [Required]
        [Display(Name = "Responsavel pela Ação")]
        public string ResponsavelAcao { get; set; }

        [Required]
        [Display(Name = "Status")]
        public int Status { get; set; }
    }

    public enum EnumRiscoEfeito
    {
        Catastroficos = 1,
        Serios = 2,
        Toleraveis = 3,
        Insignificantes = 4
    }

    public enum EnumCategoria
    {
        Tecnologia = 1,
        Equipe = 2,
        Organizacionais = 3,
        Ferramentas = 4,
        Estimativa = 5
    }

    public enum Status
    {
        EmAndamento = 1,
        Sanado = 2,
        Mitigado = 3
    }

    public enum EnumProbabilidadeOcorrencia
    {
        Alta = 1,
        Media = 2,
        Baixa = 3
    }
}