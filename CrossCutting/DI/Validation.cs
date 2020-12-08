using Domain.Application.Requests;
using Domain.Application.Validations;

using FluentValidation;

using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DI
{
    public static class ValidationRegister
    {
        public static IServiceCollection AddValidations(this IServiceCollection validate)
        {
            validate.AddTransient<IValidator<ClienteRequest>, ClienteValidator>();

            return validate;
        }
    }
}
