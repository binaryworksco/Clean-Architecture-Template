namespace BinaryWorks.CleanArchitectureTemplate.Domain.Entities;

public class EntityBase
{
    public DateTime CreatedUtc { get; internal set; }
    public DateTime UpdatedUtc { get; internal set; }

    protected EntityBase()
    {
        CreatedUtc = DateTime.UtcNow;
        UpdatedUtc = DateTime.UtcNow;
    }
}