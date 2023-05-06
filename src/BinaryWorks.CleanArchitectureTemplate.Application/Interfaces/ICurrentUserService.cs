namespace BinaryWorks.CleanArchitectureTemplate.Application.Interfaces;

public interface ICurrentUserService
{
    Guid ApplicationUserId { get; }
    Guid AccountId { get; }
    string? Username { get; }
    string? Email { get; }
    string? Name { get; }
    string? FirstName { get; }
    string? LastName { get; }
    string? Sid { get; }
    string? Picture { get; }
}