
namespace Model
{
    public record EmployeeRec(string FirstName, string LastName): PersonRec(FirstName, LastName)
    {
        public string FullName { get => $"{FirstName} {LastName}"; }
    }
}
