using Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Data
{
    public class SeguridadDbContextData
    {
        public static async Task SeedUserAsync(UserManager<Usuario> user)
        {
            if (!user.Users.Any())
            {
                var usuario = new Usuario
                {
                    Nombre = "Admin",
                    Apellidos = "Admin",
                    Email = "admin@mail.com",
                    UserName = "Admin"
                };
                await user.CreateAsync(usuario,"Admin123$");
            }
        }
    }
}
