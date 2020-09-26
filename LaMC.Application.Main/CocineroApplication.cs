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
    public class CocineroApplication : ICocineroApplication
    {
        private readonly ICocineroDomain _CocinerosDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<CocineroApplication> _logger;

        public CocineroApplication(ICocineroDomain CocineroDomain, IMapper mapper, IAppLogger<CocineroApplication> logger)
        {
            _CocinerosDomain = CocineroDomain;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<string>> InsertAsync(CocineroDTO model)
        {
            var response = new Response<string>();

            try
            {
                var resp = _mapper.Map<Cocinero>(model);
                response.Data = await _CocinerosDomain.InsertAsync(resp);
                if (response.Data == "success")
                {
                    response.IsSuccess = true;
                    response.Message = "Se ha registrado el Cocinero exitosamente.";
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

        public async Task<Response<string>> UpdateAsync(CocineroDTO model)
        {
            var response = new Response<string>();

            try
            {
                var resp = _mapper.Map<Cocinero>(model);
                response.Data = await _CocinerosDomain.UpdateAsync(resp);
                if (response.Data == "success")
                {
                    response.IsSuccess = true;
                    response.Message = "Se ha actualizado el Cocinero exitosamente.";
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
                response.Data = await _CocinerosDomain.DeleteAsync(Id);
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

        public async Task<Response<IEnumerable<CocineroDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<CocineroDTO>>();
            try
            {
                var resp = await _CocinerosDomain.GetAllAsync();

                response.Data = _mapper.Map<IEnumerable<CocineroDTO>>(resp);
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

        public async Task<Response<CocineroDTO>> GetAsync(int? Id)
        {
            var response = new Response<CocineroDTO>();
            try
            {
                var clase = await _CocinerosDomain.GetAsync(Id);

                response.Data = _mapper.Map<CocineroDTO>(clase);
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
