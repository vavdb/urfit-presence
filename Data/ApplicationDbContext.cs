using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace urfit_presence.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<TimeSlot> TimeSlots { get; set; }
    // public DbSet<Person> People { get; set; }
    public DbSet<Presence> Presences { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("urfit");
        
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Presence>()
                    .HasOne(p => p.ApplicationUser)
                    .WithMany(p => p.Presences)
                    .HasForeignKey(p => p.ApplicationUserId);

        modelBuilder.Entity<Presence>()
                    .HasOne(p => p.TimeSlot)
                    .WithMany(t => t.Presences)
                    .HasForeignKey(p => p.TimeSlotId);

        modelBuilder.Entity<TimeSlot>()
                    .HasData(
                             new TimeSlot { Id = 1, DayOfWeek = DayOfWeek.Monday, StartTime = new TimeOnly( 20,0) }
                             , new TimeSlot { Id = 2, DayOfWeek = DayOfWeek.Wednesday, StartTime = new TimeOnly( 8,45) }
                             , new TimeSlot { Id = 3, DayOfWeek = DayOfWeek.Wednesday, StartTime = new TimeOnly( 20,0)}
                             , new TimeSlot { Id = 4, DayOfWeek = DayOfWeek.Saturday, StartTime =new TimeOnly( 9,0) }
                            );
        
        // modelBuilder.Entity<Person>()
        //             .HasData(
        //                      new Person { Id = 1, Name = "Leydi van den Braken Breuls", Email = "leydi@urfit.nu" },
        //                      new Person { Id = 2, Name = "Vincent van den Braken Breuls", Email = "vincent@vandenbraken.com" }
        //                     );        
    }
}
