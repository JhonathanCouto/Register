using System.Net;

namespace Register.Domain;

public class User : Entity
{
    public User
    (
        string name,
        string email,
        string cpf,
        long addressId
    )
    {
        Name = name;
        Email = email;
        Cpf = cpf;
        AddressId = addressId;
        CreatedAt = DateTime.Now;
    }

    public User(long id) => Id = id;

    public string Name { get; private set; }

    public string Email { get; private set; }

    public string Cpf { get; private set; }

    public long AddressId { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public void UpdateName(string name) => Name = name;

    public void UpdateEmail(string email) => Email = email;

    public void UpdateCpf(string cpf) => Cpf = cpf;
}
