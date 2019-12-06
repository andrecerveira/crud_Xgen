using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Infra.Repositories
{
    public class ClientRepository : RepositoryBase<Client>, IClienteRepository
    {
        public IEnumerable<Client> SearchForName(string name)
        {
            return Db.Clients.Where(c => c.Name == name);
        }
    }
}
