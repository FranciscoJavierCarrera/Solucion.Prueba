using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solucion.prueba.Dtos;
using Solucion.prueba.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solucion.prueba.Controllers
{
    public class ClienteController : BaseApiController
    {
        private readonly IGenericRepository<Cliente> _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteController(IGenericRepository<Cliente> clienteRepository, IMapper mapper)
        {
            this._clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        
        /// <summary>
        /// Devuelve el listado de clientes
        /// </summary>
        /// <returns>Lista de clientes</returns>
        [HttpGet]
        public async Task<ActionResult<List<ClienteWithCuentasDto>>> GetClientes([FromQuery]PageSpecificationParams pageParams)
        {
            var spec = new ClienteWithCuentaSpecification(pageParams);
            var clientes = await _clienteRepository.GetAllWithSpectAsync(spec);
            var result = _mapper.Map<IReadOnlyList<Cliente>, IReadOnlyList<ClienteWithCuentasDto>>(clientes);
            return Ok(result);
        }

        /// <summary>
        /// Obtiene un cliente por ID
        /// </summary>
        /// <returns>Cliente</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteWithCuentasDto>> GetCliente(int id)
        {
            var spec = new ClienteWithCuentaSpecification(id);
            var cliente = await _clienteRepository.GetByIdAsyncWithSpecAsync(spec);
            if (cliente == null && id > 0)
            {
                return NotFound(new CodeErrorResponse(404,"No se encontro el cliente"));
            }else if( id == 0) {
                return Ok(new ClienteWithCuentasDto());
            }
            return Ok(_mapper.Map<Cliente, ClienteWithCuentasDto>(cliente));
        }
        /// <summary>
        /// Registro de un nuevo cliente
        /// </summary>
        /// <returns>Cliente</returns>
        [HttpPost]
        public async Task<ActionResult<ClienteDto>> Post(ClienteDto cliente)
        {
            var Cliente = new Cliente
            {
                Id = 0,
                Nombre = cliente.Nombre,
                ApellidoM = cliente.ApellidoM,
                ApellidoP = cliente.ApellidoP,
                NumeroIdentificacion = cliente.NumeroIdentificacion,
                Direcion = cliente.Direcion,
                Telefono = cliente.Telefono,
            };
            var resultado = await _clienteRepository.AddAsync(Cliente);
            if (resultado == 0)
            {
                throw new Exception("No se inserto el cliente");
            }
            return Ok(_mapper.Map<Cliente, ClienteDto>(Cliente));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClienteWithCuentasDto>> Put(int id, ClienteEditDto cliente)
        {
            var spec = new ClienteWithCuentaSpecification(id);
            var Cliente = await _clienteRepository.GetByIdAsyncWithSpecAsync(spec);
            // Solo campos que se actualizan
            Cliente.Telefono= cliente.Telefono;
            Cliente.Direcion = cliente.Direcion;
            var cuentas = _mapper.Map<ICollection<CuentaDto>, ICollection<Cuenta>>(cliente.Cuentas);
            foreach(var c in cuentas)
            {
                if (!Cliente.Cuentas.Contains(c))
                {
                    Cliente.Cuentas.Add(c);
                }
            }
            

            var resultado = await _clienteRepository.UpdateAsync(Cliente);
            if (resultado == 0)
            {
                throw new Exception("No se actualizo la cuenta");
            }

            var cuentaDetalle = _mapper.Map<Cliente, ClienteWithCuentasDto>(Cliente);
            return Ok(cuentaDetalle);
        }

    }
}
