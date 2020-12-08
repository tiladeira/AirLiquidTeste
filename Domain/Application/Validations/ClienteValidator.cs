using Domain.Application.Requests;

using FluentValidation;

namespace Domain.Application.Validations
{
    public class ClienteValidator : AbstractValidator<ClienteRequest>
    {
        public ClienteValidator()
        {
            RuleFor(p => p.Id).NotEmpty().NotNull();
            RuleFor(p => p.Nome).NotEmpty().NotNull();
            RuleFor(p => p.Idade).NotEmpty().NotNull();
        }
    }
}
