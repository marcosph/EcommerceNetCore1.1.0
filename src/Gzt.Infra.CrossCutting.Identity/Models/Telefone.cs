using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gzt.Infra.CrossCutting.Identity.Models
{
    public class Telefone
    {
        public int Id { get; set; }
        public User User { get; set; }       
        public string Numero { get; set; }
        public TelefoneTipo TelefoneTipo { get; set; }
    }

    public enum TelefoneTipo
    {
        Residencial, Celular, Comercial
    }
}
