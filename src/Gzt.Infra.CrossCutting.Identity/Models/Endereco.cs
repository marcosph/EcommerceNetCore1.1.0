using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gzt.Infra.CrossCutting.Identity.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public ICollection<UsuarioEndereco> UsuarioEnderecos { get; set; }
        public string CEP { get; set; }
    }
}
