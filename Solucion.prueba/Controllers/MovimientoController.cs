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

    public class MovimientoController : BaseApiController
    {
        private readonly IGenericRepository<Movimiento> _movimientoRepository;
        private readonly IGenericRepository<TipoMovimiento> _tmovimientoRepository;
        private readonly IMapper _mapper;

        public MovimientoController(IGenericRepository<Movimiento> movimientoRepository, IGenericRepository<TipoMovimiento> tmovimientoRepository, IMapper mapper)
        {
            _movimientoRepository = movimientoRepository;
            _tmovimientoRepository = tmovimientoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<MovimientoDto>>> GetCuentasAll()
        {
            var spec = new MovimientosSpecification();
            var movs = await _movimientoRepository.GetAllWithSpectAsync(spec);
            var result = _mapper.Map<IReadOnlyList<Movimiento>, IReadOnlyList<MovimientoDto>>(movs);
            return Ok(result);
        }
        [HttpGet]
        [Route("~/api/TipoMovimiento")]
        public async Task<ActionResult<IReadOnlyList<TipoMovimientoDto>>> GetTipoMovimientoAll()
        {
            var tmovs = await _tmovimientoRepository.GetAllAsync();
            var result = _mapper.Map<IReadOnlyList<TipoMovimiento>, IReadOnlyList<TipoMovimientoDto>>(tmovs);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IReadOnlyList<MovimientoDto>>> GetCuentaById(int id)
        {
            var spec = new MovimientosSpecification(id);
            var mov = await _movimientoRepository.GetByIdAsyncWithSpecAsync(spec);
            var result = _mapper.Map<Movimiento, MovimientoDto>(mov);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<MovimientoDto>> Post(MovimientoDto mov)
        {
            var Mov = _mapper.Map<MovimientoDto, Movimiento>(mov);
            Mov.Id = 0;
            Mov.Fecha = DateTime.Now;
            Mov.TipoMovimiento = await _tmovimientoRepository.GetByIdAsync(Mov.TipoMovimientoId);
            var resultado = await _movimientoRepository.AddAsync(Mov);

            if (resultado == 0)
            {
                throw new Exception("No se inserto la cuenta");
            }
            var spec = new MovimientosSpecification(Mov.Id);
            var movDetalle = _mapper.Map<Movimiento, MovimientoDto>(await _movimientoRepository.GetByIdAsyncWithSpecAsync(spec));
            return Ok(movDetalle);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MovimientoDto>> Put(int id, MovimientoDto mov)
        {
            var spec = new MovimientosSpecification(id);
            var Mov = await _movimientoRepository.GetByIdAsyncWithSpecAsync(spec);
            // Solo campos actualizados
            Mov.Monto = mov.Monto;
            Mov.TipoMovimientoId = mov.TipoMovimientoId;


            var resultado = await _movimientoRepository.UpdateAsync(Mov);
            if (resultado == 0)
            {
                throw new Exception("No se actualizo la cuenta");
            }

            var movDetalle = _mapper.Map<Movimiento, MovimientoDto>(Mov);
            return Ok(movDetalle);
        }
    }
}
