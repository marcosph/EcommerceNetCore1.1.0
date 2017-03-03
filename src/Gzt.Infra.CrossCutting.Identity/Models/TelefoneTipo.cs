using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gzt.Infra.CrossCutting.Identity.Models
{
    public class TelefoneTipo
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public Telefone Telefone { get; set; }
    }
}
