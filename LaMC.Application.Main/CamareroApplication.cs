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
    public class CamareroApplication : ICamareroApplication
    {
        private readonly ICamareroDomain _CamarerosDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<CamareroApplication> _logger;

        public CamareroApplication(ICamareroDomain CamareroDomain, IMapper mapper, IAppLogger<CamareroApplication> logger)
        {
            _CamarerosDomain = CamareroDomain;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<string>> InsertAsync(CamareroDTO model)
        {
            var response = new Response<string>();

            try
            {
                var resp = _mapper.Map<Camarero>(model);
                response.Data = await _CamarerosDomain.InsertAsync(resp);
                if (response.Data == "success")
                {
                    response.IsSuccess = true;
                    response.Message = "Se ha registrado el Camarero exitosamente.";
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

        public async Task<Response<string>> UpdateAsync(CamareroDTO model)
        {
            var response = new Response<string>();

            try
            {
                var resp = _mapper.Map<Camarero>(model);
                response.Data = await _CamarerosDomain.UpdateAsync(resp);
                if (response.Data == "success")
                {
                    response.IsSuccess = true;
                    response.Message = "Se ha actualizado el Camarero exitosamente.";
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
                response.Data = await _CamarerosDomain.DeleteAsync(Id);
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

        public async Task<Response<IEnumerable<CamareroDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<CamareroDTO>>();
            try
            {
                var resp = await _CamarerosDomain.GetAllAsync();

                response.Data = _mapper.Map<IEnumerable<CamareroDTO>>(resp);
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

        public async Task<Response<CamareroDTO>> GetAsync(int? Id)
        {
            var response = new Response<CamareroDTO>();
            try
            {
                var clase = await _CamarerosDomain.GetAsync(Id);

                response.Data = _mapper.Map<CamareroDTO>(clase);
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
