using Isopoh.Cryptography.Argon2;
using LanControl.Shared.ViewModels;
using TakasakiStudio.Lina.Database.Models;

namespace LanControl.Core.Models;

public class User : BaseEntity<int>
{
    public new required string Id;
    public required string Name { get; init; }
    public required string Email { get; init; }
    public required string PasswordHash { get; init; }
    public required int ServerId { get; init; }
    public required Server Server { get; init; }
    public bool IsValidPassword(string password)
    {
        return Argon2.Verify(PasswordHash, password);
    }

    public UserViewModel ToViewModel()
    {
        return new UserViewModel(Name, Id);
    }

    public static User CreateAdmin(string email, string password, string name, Server server)
    {
        var user = new User()
        {
            Id = Guid.NewGuid().ToString(),
            Name = name,
            Email = email,
            PasswordHash = Argon2.Hash(password),
            ServerId = server.Id,
            Server = server,
        };
        return user;
    }
    
    
}