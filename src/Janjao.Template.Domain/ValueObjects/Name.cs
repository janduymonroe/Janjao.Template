namespace Janjao.Template.Domain.ValueObjects;

public record Name
{
    public string Value { get; private set; }
    private Name(string value)
    {
        Value = value;
    }
    
    public static implicit operator Name(string value) => Create(value);
    
    public static Name Create(string Name)
    {
        if (string.IsNullOrWhiteSpace(Name))
        {
            throw new ArgumentException("Name is required", nameof(Name));
        }
        return new Name(Name);
    }

}