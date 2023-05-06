namespace BinaryWorks.CleanArchitectureTemplate.Domain.ValueObjects;

public record AccountId
{
    public Guid Value { get; }

    public AccountId(Guid value)
    {
        Value = value;
    }
    
    public static implicit operator Guid(AccountId accountId) => accountId.Value;
    public static implicit operator AccountId(Guid value) => new(value);
}