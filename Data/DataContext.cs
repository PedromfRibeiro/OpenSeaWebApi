
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OpenSeaWebApi.Models;

namespace OpenSeaWebApi.Data;
public class DataContext : IdentityDbContext<
                                 AppUser,
                                 IdentityRole<int>, int,
                                 IdentityUserClaim<int>,
                                 IdentityUserRole<int>,
                                 IdentityUserLogin<int>,
                                 IdentityRoleClaim<int>,
                                 IdentityUserToken<int>>
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        #region AppUser
        //Config
        builder.Entity<AppUser>()
           .HasOne(e => e.UserConfigs)
           .WithOne(c => c.AppUser)
           .OnDelete(DeleteBehavior.Cascade);
        //Config FK
        builder.Entity<AppUserConfig>()
            .HasOne(e => e.AppUser)
            .WithOne(c => c.UserConfigs)
            .HasForeignKey<AppUserConfig>(b => b.AppUser_id);
        

        builder.Entity<CustomDisplayData>()
            .Property(e => e.Images)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

        #endregion
    }

    #region DbSet
        public DbSet<AppUser> db_AppUser { get; set; }
        public DbSet<AppUserConfig> db_configUser { get; set; }
        public DbSet<CustomAssetEvent> db_AssetEvent { get; set; } 
        public DbSet<CustomCollection> db_Collection { get; set; }    
    #endregion

}