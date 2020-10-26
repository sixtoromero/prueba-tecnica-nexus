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
    public class UsuarioApplication : IUsuarioApplication
    {
        private readonly IUsuarioDomain _Domain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<UsuarioApplication> _logger;

        public UsuarioApplication(IUsuarioDomain Domain, IMapper mapper, IAppLogger<UsuarioApplication> logger)
        {
            _Domain = Domain;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<string>> InsertAsync(UsuarioDTO model)
        {
            var response = new Response<string>();

            try
            {
                var resp = _mapper.Map<Usuario>(model);
                response.Data = await _Domain.InsertAsync(resp);
                if (response.Data == "success")
                {
                    response.IsSuccess = true;
                    response.Message = "Se ha registrado el Usuario exitosamente.";
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

        public async Task<Response<string>> UpdateAsync(UsuarioDTO model)
        {
            var response = new Response<string>();

            try
            {
                var resp = _mapper.Map<Usuario>(model);
                response.Data = await _Domain.UpdateAsync(resp);
                if (response.Data == "success")
                {
                    response.IsSuccess = true;
                    response.Message = "Se ha actualizado el Usuario exitosamente.";
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
                response.Data = await _Domain.DeleteAsync(Id);
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

        public async Task<Response<IEnumerable<UsuarioDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<UsuarioDTO>>();
            try
            {
                var resp = await _Domain.GetAllAsync();

                response.Data = _mapper.Map<IEnumerable<UsuarioDTO>>(resp);
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

        public async Task<Response<UsuarioDTO>> GetAsync(int? Id)
        {
            var response = new Response<UsuarioDTO>();
            try
            {
                var clase = await _Domain.GetAsync(Id);

                response.Data = _mapper.Map<UsuarioDTO>(clase);
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

        public async Task<Response<UsuarioDTO>> getLogin(UsuarioDTO model)
        {
            var response = new Response<UsuarioDTO>();
            try
            {
                var resp = _mapper.Map<Usuario>(model);                
                var result = await _Domain.getLogin(resp);

                response.Data = _mapper.Map<UsuarioDTO>(result);
                if (response.Data != null)
                {                    
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Usuario o contraseña incorrecto";
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
