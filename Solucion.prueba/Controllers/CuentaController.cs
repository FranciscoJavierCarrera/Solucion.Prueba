using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solucion.prueba.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solucion.prueba.Controllers
{

    public class CuentaController : BaseApiController
    {
        private readonly IGenericRepository<Cuenta> _cuentaRepository;
        private readonly IGenericRepository<TipoCuenta> _tcuentaRepository;
        private readonly IGenericRepository<TipoMovimiento> _tmovRepository;
        private readonly IMapper _mapper;
        public CuentaController(IGenericRepository<Cuenta> cuentaRepository, IGenericRepository<TipoCuenta> tcuentaRepository, IGenericRepository<TipoMovimiento> tmovRepository, IMapper mapper)
        {
            _cuentaRepository = cuentaRepository;
            _tcuentaRepository = tcuentaRepository;
            _tmovRepository = tmovRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CuentaDetailDto>>> GetCuentasAll()
        {
            var spec = new CuentaWithMovimientosSpecification();
            var cuentas = await _cuentaRepository.GetAllWithSpectAsync(spec);
            var result = _mapper.Map<IReadOnlyList<Cuenta>, IReadOnlyList<CuentaDetailDto>>(cuentas);
            return Ok(result);
        }
        [HttpGet]
        [Route("~/api/TipoCuentas")]
        public async Task<ActionResult<IReadOnlyList<TipoCuentaDto>>> GetTipoCuentasAll()
        {
            var cuentas = await _tcuentaRepository.GetAllAsync();
            var result = _mapper.Map<IReadOnlyList<TipoCuenta>, IReadOnlyList<TipoCuentaDto>>(cuentas);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CuentaDetailDto>> GetCuentaById(int id)
        {
            var spec = new CuentaWithMovimientosSpecification(id);
            var cuenta = await _cuentaRepository.GetByIdAsyncWithSpecAsync(spec);
            if (cuenta == null)
                return Ok(new CuentaDetailDto());
            var result = _mapper.Map<Cuenta, CuentaDetailDto>(cuenta);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CuentaDetailDto>> Post(CuentaDto cuenta)
        {
            var Cuenta = new Cuenta
            {
                Id = 0,
                ClienteId = cuenta.ClienteId,
                NumeroCuenta = cuenta.NumeroCuenta,
                TipoCuentaId = cuenta.TipoCuentaId,
                FechaApertura = DateTime.Now,
                FechaUltimoMov = DateTime.Now,
                Saldo = cuenta.Saldo
            };
            Cuenta.TipoCuenta = await _tcuentaRepository.GetByIdAsync(cuenta.TipoCuentaId);
            var resultado = await _cuentaRepository.AddAsync(Cuenta);

            if (resultado == 0)
            {
                throw new Exception("No se inserto la cuenta");
            }
            var spec = new CuentaWithMovimientosSpecification(Cuenta.Id);
            var cuentaDetalle = _mapper.Map<Cuenta, CuentaDetailDto>(await _cuentaRepository.GetByIdAsyncWithSpecAsync(spec));
            return Ok(cuentaDetalle);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CuentaDetailDto>> Put(int id, CuentaDto cuenta)
        {
            var spec = new CuentaWithMovimientosSpecification(id);
            var Cuenta = await _cuentaRepository.GetByIdAsyncWithSpecAsync(spec);
            var tmovs = await _tmovRepository.GetAllAsync();
            // Solo campos que se actuaalizan
            Cuenta.FechaUltimoMov = DateTime.Now;
            Cuenta.Saldo = Cuenta.Movimientos.Sum(x=> x.Monto*tmovs.First(t=> t.Id==x.TipoMovimientoId).Signo);


            var resultado = await _cuentaRepository.UpdateAsync(Cuenta);
            if (resultado == 0)
            {
                throw new Exception("No se actualizo la cuenta");
            }
            
            var cuentaDetalle = _mapper.Map<Cuenta, CuentaDetailDto>(Cuenta);
            return Ok(cuentaDetalle);
        }
    }
}
