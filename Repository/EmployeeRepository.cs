using Contracts;
using Entities;
using Entities.Models;

namespace Repository;

public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
{
    public EmployeeRepository(RepositoryContext context)
        : base(context)
    {
    }

    public IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges)
        => FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
            .OrderBy(e => e.Name);

    public Employee? GetEmployee(Guid companyId, Guid employeeId, bool trackChanges)
        => FindByCondition(c => c.CompanyId.Equals(companyId) && c.Id.Equals(employeeId)
                , trackChanges: trackChanges)
            .SingleOrDefault();
}