using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Data;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Logic
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly SolucionDbContext _context;
        public ClienteRepository(SolucionDbContext context)
        {
            _context = context;
        }


        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            return await _context.Cliente.Include(c=> c.Cuentas).IgnoreAutoIncludes().FirstOrDefaultAsync(c=> c.Id==id);
        }

        
        public async Task<IReadOnlyList<Cliente>> GetClienteByNombreAsync(string nombre, string Apellido)
        {
            return await _context.Cliente.Where(x => x.Nombre == nombre && (x.ApellidoM == Apellido || x.ApellidoP == Apellido)).ToListAsync(); 
        }

        
        public async Task<IReadOnlyList<Cliente>> GetClientesAsync()
        {
            return await _context.Cliente.ToListAsync();
        }
    }
}
