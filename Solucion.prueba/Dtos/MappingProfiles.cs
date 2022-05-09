using AutoMapper;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solucion.prueba.Dtos
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<Cliente, ClienteWithCuentasDto>().ReverseMap();
            CreateMap<Cuenta, CuentaDto>()
               .ReverseMap();
            CreateMap<Cuenta, CuentaDetailDto>()
                .ForMember(c => c.TipoCuentaDescripcion, x => x.MapFrom(t => t.TipoCuenta.Descripcion))
                .ForMember(c => c.ClienteNombre, x => x.MapFrom(t => t.Cliente.Nombre + " " + t.Cliente.ApellidoP))
                .ReverseMap();
            CreateMap<Cuenta, CuentaShowDto>()
                .ForMember(c => c.ClienteNombre, x => x.MapFrom(t => t.Cliente.Nombre+" "+t.Cliente.ApellidoP)).ReverseMap();
            CreateMap<Movimiento, MovimientoDto>()
                .ReverseMap(); 
            CreateMap<TipoMovimiento, TipoMovimientoDto>().ReverseMap();
            CreateMap<TipoCuenta, TipoCuentaDto>().ReverseMap();





        }
    }
}
