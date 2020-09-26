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
    public class ClienteApplication : IClienteApplication
    {
        private readonly IClienteDomain _clientesDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<ClienteApplication> _logger;

        public ClienteApplication(IClienteDomain clienteDomain, IMapper mapper, IAppLogger<ClienteApplication> logger)
        {
            _clientesDomain = clienteDomain;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<string>> InsertAsync(ClienteDTO model)
        {
            var response = new Response<string>();

            try
            {
                var resp = _mapper.Map<Cliente>(model);
                response.Data = await _clientesDomain.InsertAsync(resp);
                if (response.Data == "success")
                {
                    response.IsSuccess = true;
                    response.Message = "Se ha registrado el cliente exitosamente.";
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

        public async Task<Response<string>> UpdateAsync(ClienteDTO model)
        {
            var response = new Response<string>();

            try
            {
                var resp = _mapper.Map<Cliente>(model);
                response.Data = await _clientesDomain.UpdateAsync(resp);
                if (response.Data == "success")
                {
                    response.IsSuccess = true;
                    response.Message = "Se ha registrado el cliente exitosamente.";
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
                response.Data = await _clientesDomain.DeleteAsync(Id);
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

        public async Task<Response<IEnumerable<ClienteDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<ClienteDTO>>();
            try
            {
                var resp = await _clientesDomain.GetAllAsync();

                response.Data = _mapper.Map<IEnumerable<ClienteDTO>>(resp);
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

        public async Task<Response<ClienteDTO>> GetAsync(int? Id)
        {
            var response = new Response<ClienteDTO>();
            try
            {
                var clase = await _clientesDomain.GetAsync(Id);

                response.Data = _mapper.Map<ClienteDTO>(clase);
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
