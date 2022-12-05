using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace araujo.Domain.Entities;

public class Role : IdentityRole<string>
{
    public ICollection<UserRole> UserRoles { get; set; }
}
