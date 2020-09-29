using AutoMapper;
using LaMC.Application.DTO;
using LaMC.Application.Interface;
using LaMC.Domain.Entity;
using LaMC.Domain.Interface;
using LaMC.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LaMC.Application.Main
{
    public class ViewFacturaApplication : IViewFacturaApplication
    {
        private readonly IViewFacturaDomain _Domain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<ViewFacturaApplication> _logger;

        public ViewFacturaApplication(IViewFacturaDomain Domain, IMapper mapper, IAppLogger<ViewFacturaApplication> logger)
        {
            _Domain = Domain;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<ViewFacturaDTO>>> getListFactura()
        {
            var response = new Response<IEnumerable<ViewFacturaDTO>>();
            try
            {
                var resp = await _Domain.getListFactura();

                response.Data = _mapper.Map<IEnumerable<ViewFacturaDTO>>(resp);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = string.Empty;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Ha ocurrido un error consultando los registros.";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<IEnumerable<ViewFacturaDTO>>> getListFacturaByFecha(DateTime FechaInicio, DateTime FechaFin)
        {
            var response = new Response<IEnumerable<ViewFacturaDTO>>();
            try
            {
                var resp = await _Domain.getListFacturaByFecha(FechaInicio, FechaFin);

                response.Data = _mapper.Map<IEnumerable<ViewFacturaDTO>>(resp);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = string.Empty;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Ha ocurrido un error consultando los registros.";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<IEnumerable<TotalesByCamareroDTO>>> getTotalesporCamarero()
        {
            var response = new Response<IEnumerable<TotalesByCamareroDTO>>();
            try
            {
                var resp = await _Domain.getTotalesporCamarero();

                response.Data = _mapper.Map<IEnumerable<TotalesByCamareroDTO>>(resp);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = string.Empty;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Ha ocurrido un error consultando los registros.";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }


    }
}
