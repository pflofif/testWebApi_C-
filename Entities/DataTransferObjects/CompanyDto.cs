using System.Runtime.CompilerServices;

namespace Entities.DataTransferObjects;

public class CompanyDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string FullAdress { get; set; }
}