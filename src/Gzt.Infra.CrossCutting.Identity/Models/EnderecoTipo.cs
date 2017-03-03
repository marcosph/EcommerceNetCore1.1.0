using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gzt.Infra.CrossCutting.Identity.Models
{
    public class EnderecoTipo
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public Endereco Endereco { get; set; }
    }
}
