using Contracts;
using Entities;

namespace Repository;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _context;
    private ICompanyRepository? _companyRepository;
    private IEmployeeRepository? _employeeRepository;

    public RepositoryManager(RepositoryContext context)
    {
        _context = context;

    }

    public ICompanyRepository Company => _companyRepository ??= new CompanyRepository(_context);

    public IEmployeeRepository Employee => _employeeRepository ??= new EmployeeRepository(_context);

    public void Save() => _context.SaveChanges();
}