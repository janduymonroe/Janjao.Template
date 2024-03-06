using System.ComponentModel.DataAnnotations;

namespace Janjao.Template.Domain.ValueObjects;

public record Email
{
    public string Value { get; private set; }
    private Email(string value)
    {
        Value = value;
    }
    
    public static implicit operator Email(string value) => Create(value);
    
    public static Email Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("Email is required", nameof(email));
        }

        if (!new EmailAddressAttribute().IsValid(email))
        {
            throw new ArgumentException("Email is invalid", nameof(email));
        }
        return new Email(email);
    }

}