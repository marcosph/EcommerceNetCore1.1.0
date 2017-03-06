using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gzt.Infra.CrossCutting.Identity.Models.AccountViewModels
{
    public class RegisterViewModel
    {
       
        [Required]
        public PessoaTipo PessoaTipo { get; set; }
     
        public EnumTelefoneTipo? EnumTelefoneTipo { get;set; }

        [Required]
        [Display(Name = "Razao Social")]
        public string RazaoSocial { get; set; }
        [Required]
        [Display(Name = "Nome Fantasia")]
        public string NomeFantasia { get; set; }

        [Required]
        [Display(Name = "Inscrição Estadual")]
        public string IncricaoEstadual { get; set; }

        [Required]
        [Display(Name = "CNPJ")]
        public string CNPJ { get; set; }
        //-----------------------------
        [Required]
        [Display(Name = "Nome Completo")]
        public string NomeCompleto { get; set; }

        [Required]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        //-----------------------
        [Required]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }


        [Required(ErrorMessageResourceName ="dddddd")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        [EmailAddress]
        [Display(Name = "Confirmar Email")]
        [Compare("Email", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmEmail { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Senha")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


    }
    [Flags]
    public enum PessoaTipo
    {
        [Display(Name = "Pessoa Fisica")]
        Fisica,
        [Display(Name = "Pessoa Juridica")]
        Juridica
    }

    public enum EnumTelefoneTipo
    {
        [Display(Name = "Residencial")]
        Residencial= 1,
        [Display(Name = "Celular")]
        Celular = 2,
        [Display(Name = "Comercial")]
        Comercial =3,

    }
    
}
