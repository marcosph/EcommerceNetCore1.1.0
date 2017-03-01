using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gzt.Infra.CrossCutting.Identity.Models
{
    public class PessoaFisica : User
    {
        public string NomeCompleto { get; set; }
        public string CPF { get; set; }
        public string DataNascimento { get; set; }
        public Genero Genero { get; set; }       
    }
    public enum Genero
    {
        Masculino, Feminino
    }
}
