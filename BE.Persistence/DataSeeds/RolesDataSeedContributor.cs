using BE.Domain.Entities.Roles;
using Microsoft.EntityFrameworkCore;

namespace BE.Persistence.DataSeeds;

public class RolesDataSeedContributor : IDataSeedContributor
{
    private readonly ApplicationDbContext context;

    public RolesDataSeedContributor(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task SeedAsync()
    {
        if (await context.Roles.AnyAsync()) return;
        
        IList<Role> roles = new List<Role>()
        {
            new Role
            {
                RoleName = "Admin",
                RoleDescription = "Description", 
            },
            
            new Role
            {
                RoleName = "Memeber",
                RoleDescription = "Description", 
            },
        }; 
        await context.Roles.AddRangeAsync(roles);
        await context.SaveChangesAsync();
    }
}
