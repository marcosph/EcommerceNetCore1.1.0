﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;

namespace Gzt.Infra.CrossCutting.Identity.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class User : IdentityUser
    {
        public string Nome { get; set; }
        public ICollection<UsuarioEndereco> UsuarioEnderecos { get; set; }
        public ICollection<Telefone> Telefones { get; set; }

    }
}
