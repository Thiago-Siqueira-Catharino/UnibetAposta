using Microsoft.EntityFrameworkCore;
using UniBet.Contexts.Betting.Domain.Entities;

namespace UniBet.Contexts.Betting.Infrastructure.Persistance;

public class BettingDbContext : DbContext
{
    public DbSet<Bet> Bets { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Player> Users { get; set; }
    
    public BettingDbContext(DbContextOptions<BettingDbContext> options) : base(options) 
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>()
            .HasKey(usr => usr.Id);

        modelBuilder.Entity<Bet>()
            .HasKey(usr => usr.Id);

        modelBuilder.Entity<Bet>()
            .HasOne(bet => bet.player)
            .WithMany(usr => usr.Bets)
            .HasForeignKey(bet => bet.UserId);
        
        modelBuilder.Entity<Game>()
            .HasKey(game  => game.Id);
        
        modelBuilder.Entity<Bet>()
            .HasOne(bet => bet.Game)
            .WithMany(game => game.Bets)
            .HasForeignKey(bet => bet.GameId);
        
        base.OnModelCreating(modelBuilder);
    }
}