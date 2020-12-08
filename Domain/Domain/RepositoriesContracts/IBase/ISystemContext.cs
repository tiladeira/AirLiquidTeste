using Microsoft.EntityFrameworkCore;

namespace Domain.Domain.RepositoriesContracts.IBase
{
    public interface ISystemContext
    {
        DbContext Db { get; set; }
    }
}
