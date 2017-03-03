using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gzt.Infra.CrossCutting.Identity.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public int EnderecoTipoId { get; set; }
        public EnderecoTipo EnderecoTipo { get; set; }
        public string IdentificaoDoEndereco { get; set; }
        public string NomeDestinatario { get; set; }
        [MaxLength(8)]
        public string CEP { get; set; }
        public string Endereco_ { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        [MaxLength(2)]
        public string UF { get; set; }
        public string PontoReferencia { get; set; } 
        public ICollection<UsuarioEndereco> UsuarioEnderecos { get; set; }        
    }
   
}
