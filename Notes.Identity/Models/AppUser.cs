using Microsoft.AspNetCore.Identity;

namespace Notes.Identity.Models;

public class AppUser: IdentityUser
{
    public string Login { get; set; }
    // public string PhoneNumber { get; set; }
    // public string Password { get; set; }
}