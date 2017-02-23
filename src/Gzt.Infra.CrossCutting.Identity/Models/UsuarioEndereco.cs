namespace Gzt.Infra.CrossCutting.Identity.Models
{
    public class UsuarioEndereco
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
    }
}
