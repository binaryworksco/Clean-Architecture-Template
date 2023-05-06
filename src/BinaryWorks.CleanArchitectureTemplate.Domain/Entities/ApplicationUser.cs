namespace BinaryWorks.CleanArchitectureTemplate.Domain.Entities;

public class ApplicationUser : EntityBase
{
    public Guid AccountId { get; private set; }
    public Guid Id { get; private set; }
    public string Email { get; private set; }
    public string FirstName { get; private set; }
    public string? LastName { get; private set; }

    private ApplicationUser(string email, string firstName, string? lastName)
    {
        // Id = id;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
    }
    
    public static ApplicationUser Create(string email, string firstName, string? lastName)
    {
        ArgumentException.ThrowIfNullOrEmpty(email);
        ArgumentException.ThrowIfNullOrEmpty(firstName);
        
        return new ApplicationUser(email, firstName, lastName);
    }
}