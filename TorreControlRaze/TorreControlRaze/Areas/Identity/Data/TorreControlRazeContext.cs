using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TorreControlRaze.Areas.Identity.Data;

namespace TorreControlRaze.Data;

public class TorreControlRazeContext : IdentityDbContext<TorreControlRazeUser>
{
    public TorreControlRazeContext(DbContextOptions<TorreControlRazeContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
