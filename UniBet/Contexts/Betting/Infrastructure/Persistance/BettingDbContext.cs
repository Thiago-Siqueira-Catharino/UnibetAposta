using Microsoft.EntityFrameworkCore;
using UniBet.Contexts.Betting.Domain.Entities;
using UniBet.Contexts.Betting.Domain.ValueObjects;

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

        modelBuilder.Entity<Player>()
            .Property(u => u.Amount)
            .HasConversion(
                v => v.Value, // Conversão: Objeto -> String (Para o Banco)
                v => new Amount(v) // Conversão: String -> Objeto (Para o C#)
            );

        modelBuilder.Entity<Bet>()
            .HasKey(usr => usr.Id);

        modelBuilder.Entity<Bet>()
            .HasOne(bet => bet.player)
            .WithMany(usr => usr.Bets)
            .HasForeignKey(bet => bet.UserId);
        
        modelBuilder.Entity<Bet>()
            .Property(u => u.Team)
            .HasConversion(
                v => v.Value, // Conversão: Objeto -> String (Para o Banco)
                v => new Team(v) // Conversão: String -> Objeto (Para o C#)
            );
        
        modelBuilder.Entity<Bet>()
            .Property(u => u.Amount)
            .HasConversion(
                v => v.Value, // Conversão: Objeto -> String (Para o Banco)
                v => new Amount(v) // Conversão: String -> Objeto (Para o C#)
            );
        
        modelBuilder.Entity<Game>()
            .HasKey(game  => game.Id);
        
        modelBuilder.Entity<Game>()
            .Property(u => u.ATeam)
            .HasConversion(
                v => v.Value, // Conversão: Objeto -> String (Para o Banco)
                v => new Team(v) // Conversão: String -> Objeto (Para o C#)
            );
        
        modelBuilder.Entity<Game>()
            .Property(u => u.BTeam)
            .HasConversion(
                v => v.Value, // Conversão: Objeto -> String (Para o Banco)
                v => new Team(v) // Conversão: String -> Objeto (Para o C#)
            );
        
        modelBuilder.Entity<Game>()
            .Navigation(g => g.Bets)
            .HasField("_bets") // Nome exato do seu campo privado
            .UsePropertyAccessMode(PropertyAccessMode.Field);
        
        modelBuilder.Entity<Bet>()
            .HasOne(bet => bet.Game)
            .WithMany(game => game.Bets)
            .HasForeignKey(bet => bet.GameId);
        
        base.OnModelCreating(modelBuilder);
    }
}