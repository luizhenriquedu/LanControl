using Isopoh.Cryptography.Argon2;
using LanControl.Shared.ViewModels;

namespace LanControl.Core.Models;

public class User
{
    public required int Id;
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }

    public bool IsValidPassword(string password)
    {
        return Argon2.Verify(PasswordHash, password);
    }

    public UserViewModel ToViewModel()
    {
        return new UserViewModel(Name, Id);
        
    }
}