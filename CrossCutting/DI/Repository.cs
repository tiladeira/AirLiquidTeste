using Domain.Domain.RepositoriesContracts;
using Domain.Domain.RepositoriesContracts.IBase;
using Domain.Infra.DBContext;
using Domain.Repositories;

using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DI
{
    public static class Repository
    {
        public static IServiceCollection AddRepositories(this IServiceCollection repository)
        {
            repository.AddScoped<ISystemContext, DBContext>();
            repository.AddScoped<IClienteRepository, ClienteRepository>();

            return repository;
        }
    }
}
