using AutoMapper;
using LaMC.Application.DTO;
using LaMC.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaMC.Transversal.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Camarero, CamareroDTO>().ReverseMap();
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Cocinero, CocineroDTO>().ReverseMap();
            CreateMap<DetalleFactura, DetalleFacturaDTO>().ReverseMap();
            CreateMap<Factura, FacturaDTO>().ReverseMap();
            CreateMap<Mesa, MesaDTO>().ReverseMap();
            CreateMap<ViewFactura, ViewFacturaDTO>().ReverseMap();
        }
    }
}
