﻿using Contracts;
using Entities;
using Entities.Models;

namespace Repository;

public class EmployeeRepository : RepositoryBase<Employee>, IEmoloyeeRepository
{
    public EmployeeRepository(RepositoryContext context)
        : base(context)
    {
    }
}