using Microsoft.AspNetCore.Identity;

namespace Domain.Identities.Entities;

public class Role : IdentityRole<Ulid>
{
    public string? Description { get; set; }

    // EF Core requires a parameterless constructor for the entity type
    public Role()
    {
    }

    public Role(string name, string? description)
    {
        Name = name;
        Description = description;
    }
}
