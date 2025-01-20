using Microsoft.EntityFrameworkCore;
using MLAgency.Models;

public class AppDbContext : DbContext
{
    public DbSet<Participant> Participants { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<ParticipantEvent> ParticipantEvents { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurer la clé composite pour ParticipantEvent
        modelBuilder.Entity<ParticipantEvent>()
            .HasKey(pe => new { pe.ParticipantId, pe.EventId });

        modelBuilder.Entity<ParticipantEvent>()
            .HasOne(pe => pe.Participant)
            .WithMany(p => p.ParticipantEvents)
            .HasForeignKey(pe => pe.ParticipantId);

        modelBuilder.Entity<ParticipantEvent>()
            .HasOne(pe => pe.Event)
            .WithMany(e => e.ParticipantEvents)
            .HasForeignKey(pe => pe.EventId);
    }
}
