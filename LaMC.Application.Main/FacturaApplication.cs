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
    public class FacturaApplication : IFacturaApplication
    {
        private readonly IFacturaDomain _FacturasDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<FacturaApplication> _logger;

        public FacturaApplication(IFacturaDomain FacturaDomain, IMapper mapper, IAppLogger<FacturaApplication> logger)
        {
            _FacturasDomain = FacturaDomain;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<string>> InsertAsync(FacturaDTO model)
        {
            var response = new Response<string>();

            try
            {
                var resp = _mapper.Map<Factura>(model);
                response.Data = await _FacturasDomain.InsertAsync(resp);
                if (response.Data == "success")
                {
                    response.IsSuccess = true;
                    response.Message = "Se ha registrado la Factura exitosamente.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Ha ocurrido un error inesperado, por favor intente nuevamente";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<string>> UpdateAsync(FacturaDTO model)
        {
            var response = new Response<string>();

            try
            {
                var resp = _mapper.Map<Factura>(model);
                response.Data = await _FacturasDomain.UpdateAsync(resp);
                if (response.Data == "success")
                {
                    response.IsSuccess = true;
                    response.Message = "Se ha actualizado la Factura exitosamente.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Ha ocurrido un error inesperado, por favor intente nuevamente";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<string>> DeleteAsync(int? Id)
        {
            var response = new Response<string>();

            try
            {
                response.Data = await _FacturasDomain.DeleteAsync(Id);
                if (response.Data == "success")
                {
                    response.IsSuccess = true;
                    response.Message = "Se ha borrado el registro exitosamente.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Ha ocurrido un error inesperado, por favor intente nuevamente";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<IEnumerable<FacturaDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<FacturaDTO>>();
            try
            {
                var resp = await _FacturasDomain.GetAllAsync();

                response.Data = _mapper.Map<IEnumerable<FacturaDTO>>(resp);
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

        public async Task<Response<FacturaDTO>> GetAsync(int? Id)
        {
            var response = new Response<FacturaDTO>();
            try
            {
                var clase = await _FacturasDomain.GetAsync(Id);

                response.Data = _mapper.Map<FacturaDTO>(clase);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Ha ocurrido un inconveniente al consultar los registros.";
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
