using AutoMapper;

using Domain.Application.Services.Interfaces;
using Domain.Domain.Models;
using Domain.Domain.RepositoriesContracts;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _ClienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository ClienteRepository, IMapper mapper)
        {
            _ClienteRepository = ClienteRepository;
            _mapper = mapper;
        }

        public Task<IEnumerable<Cliente>> AddAllAsync(IEnumerable<Cliente> source)
        {
            return _ClienteRepository.GetAllAsync();
        }

        public Task<Cliente> AddAsync(Cliente source)
        {
            return _ClienteRepository.AddAsync(source);
        }

        public Task DeleteAllAsync(IEnumerable<Cliente> source)
        {
            return _ClienteRepository.DeleteAllAsync(source);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            return _ClienteRepository.DeleteAsync(id);
        }

        public Task<IEnumerable<Cliente>> GetAllAsync(Func<Cliente, bool> predicate = null, string[] includes = null)
        {
            return _ClienteRepository.GetAllAsync(predicate);
        }

        public Task<Cliente> GetByIdAsync(Guid id)
        {
            return _ClienteRepository.GetByIdAsync(id);
        }

        public Task<Cliente> GetFirstOrDefaultAsync(Func<Cliente, bool> predicate)
        {
            return _ClienteRepository.GetFirstOrDefaultAsync(predicate);
        }

        public Task<Cliente> UpdateAsync(Cliente source)
        {
            return _ClienteRepository.UpdateAsync(source);
        }
    }
}
