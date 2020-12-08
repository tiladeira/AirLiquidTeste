using AutoMapper;

using Domain.Application.Requests;
using Domain.Domain.Models;

using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.AutoMapping
{
    public static class AutoMapping
    {
        public static IServiceCollection AddAutoMapping(this IServiceCollection repository)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClienteRequest, Cliente>();
            });

            IMapper mapper = config.CreateMapper();
            repository.AddSingleton(mapper);

            return repository;
        }
    }
}
