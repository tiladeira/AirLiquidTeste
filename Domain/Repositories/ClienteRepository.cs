using Domain.Domain.Models;
using Domain.Domain.RepositoriesContracts;
using Domain.Domain.RepositoriesContracts.IBase;
using Domain.Repositories.Base;

namespace Domain.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        private readonly ISystemContext _context;

        public ClienteRepository(ISystemContext context) : base(context)
        {
            _context = context;
        }
    }
}
