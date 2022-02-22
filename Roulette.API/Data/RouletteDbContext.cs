using Microsoft.EntityFrameworkCore;
using Roulette.Api.Entities;

namespace Roulette.Api.Data
{
    public class RouletteDbContext:DbContext
    {
        public RouletteDbContext(DbContextOptions<RouletteDbContext> options):base(options)
        {

        }

        public DbSet<Bet> Bets { get; set; }
        public DbSet<BetType> { get; set; }
        public DbSet<BetType> { get; set; }
        public DbSet<Spin> Spins { get; set; }
        public DbSet<Payout> Payouts { get; set; }

    }
}
