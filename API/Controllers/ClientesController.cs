using Domain.Application.Responses;
using Domain.Application.Services.Interfaces;
using Domain.Domain.Models;

using Microsoft.AspNetCore.Mvc;

using System;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _service;

        public ClientesController(IClienteService service)
        {
            _service = service;
        }

        [Route("Add")]
        [HttpPost]
        public object Add(Cliente cd)
        {
            try
            {
                if (cd.Id != null || cd.Id != Guid.Empty)
                {
                    _service.AddAsync(cd);

                    return new ClienteResponse
                    {
                        Status = "Sucesso",
                        Message = "Cadastro Realizado!"
                    };
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return new ClienteResponse
            {
                Status = "Erro",
                Message = "Cadastro não realizado!"
            };
        }


        [Route("Update")]
        [HttpPut]
        public object Update(Cliente cd)
        {
            try
            {
                _service.UpdateAsync(cd);

                return new ClienteResponse
                {
                    Status = "Atualizado",
                    Message = "Cadastro Atualizado!!"
                };
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return new ClienteResponse
            {
                Status = "Erro",
                Message = "Cadastro não realizado!"
            };
        }

        [Route("Detail")]
        [HttpGet]
        public object Detail()
        {
            var obj = _service.GetAllAsync();
            return obj; ;
        }

        [Route("DetailById")]
        [HttpGet]
        public object DetailById(Guid id)
        {
            var obj = _service.GetByIdAsync(id);
            return obj;
        }

        [Route("Delete")]
        [HttpDelete]
        public object Delete(Guid id)
        {
            _service.DeleteAsync(id);

            return new ClienteResponse
            {
                Status = "Deçetado",
                Message = "Deletado com sucesso!"
            };
        }
    }
}