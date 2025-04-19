using Microsoft.EntityFrameworkCore;
using Physics.DAL.Models.Entities;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Device> Devices { get; set; }
    public DbSet<Maintenance> Maintenances { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Alert> Alerts { get; set; }
    public DbSet<AlertRecipient> AlertRecipients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // AlertRecipient (many-to-many بين User و Alert)
        modelBuilder.Entity<AlertRecipient>()
            .HasKey(ar => new { ar.UserId, ar.AlertId });

        modelBuilder.Entity<AlertRecipient>()
            .HasOne(ar => ar.User)
            .WithMany(u => u.AlertRecipients)
            .HasForeignKey(ar => ar.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<AlertRecipient>()
            .HasOne(ar => ar.Alert)
            .WithMany(a => a.AlertRecipients)
            .HasForeignKey(ar => ar.AlertId)
            .OnDelete(DeleteBehavior.NoAction);

        // Maintenance -> User
        modelBuilder.Entity<Maintenance>()
            .HasOne(m => m.user)
            .WithMany(u => u.Maintenances)
            .HasForeignKey(m => m.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        // Maintenance -> Device
        modelBuilder.Entity<Maintenance>()
            .HasOne(m => m.Device)
            .WithMany(d => d.MaintenanceReports)
            .HasForeignKey(m => m.DeviceId)
            .OnDelete(DeleteBehavior.NoAction);

        // Reservation -> User
        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.User)
            .WithMany(u => u.Reservations)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        // Reservation -> Device
        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Device)
            .WithMany(d => d.Reservations)
            .HasForeignKey(r => r.DeviceId)
            .OnDelete(DeleteBehavior.NoAction);

        // Alert -> Device
        modelBuilder.Entity<Alert>()
            .HasOne(a => a.Device)
            .WithMany(d => d.Alerts)
            .HasForeignKey(a => a.DeviceId)
            .OnDelete(DeleteBehavior.NoAction);

      
    }
}