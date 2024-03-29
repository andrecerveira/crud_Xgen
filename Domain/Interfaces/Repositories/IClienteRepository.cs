﻿using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    public interface IClienteRepository : IRepositoryBase<Client>
    {
        IEnumerable<Client> SearchForName(string name);
    }
}
