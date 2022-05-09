using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente> GetClienteByIdAsync(int id);
        Task<IReadOnlyList<Cliente>> GetClienteByNombreAsync(string nombre, string Apellido);
        Task<IReadOnlyList<Cliente>> GetClientesAsync();
    }
}
