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
    public class MesaApplication : IMesaApplication
    {
        private readonly IMesaDomain _MesasDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<MesaApplication> _logger;

        public MesaApplication(IMesaDomain MesaDomain, IMapper mapper, IAppLogger<MesaApplication> logger)
        {
            _MesasDomain = MesaDomain;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<string>> InsertAsync(MesaDTO model)
        {
            var response = new Response<string>();

            try
            {
                var resp = _mapper.Map<Mesa>(model);
                response.Data = await _MesasDomain.InsertAsync(resp);
                if (response.Data == "success")
                {
                    response.IsSuccess = true;
                    response.Message = "Se ha registrado la Mesa exitosamente.";
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

        public async Task<Response<string>> UpdateAsync(MesaDTO model)
        {
            var response = new Response<string>();

            try
            {
                var resp = _mapper.Map<Mesa>(model);
                response.Data = await _MesasDomain.UpdateAsync(resp);
                if (response.Data == "success")
                {
                    response.IsSuccess = true;
                    response.Message = "Se ha actualizado la Mesa exitosamente.";
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
                response.Data = await _MesasDomain.DeleteAsync(Id);
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

        public async Task<Response<IEnumerable<MesaDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<MesaDTO>>();
            try
            {
                var resp = await _MesasDomain.GetAllAsync();

                response.Data = _mapper.Map<IEnumerable<MesaDTO>>(resp);
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

        public async Task<Response<MesaDTO>> GetAsync(int? Id)
        {
            var response = new Response<MesaDTO>();
            try
            {
                var clase = await _MesasDomain.GetAsync(Id);

                response.Data = _mapper.Map<MesaDTO>(clase);
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
