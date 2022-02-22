using Microsoft.EntityFrameworkCore;
using Roulette.Api.Data;
using Roulette.Api.Entities;
using Roulette.Api.Repositories.Contracts;

namespace Roulette.Api.Repositories
{
    public class BetRepository : IBetRepository
    {
        private readonly RouletteDbContext rouletteDbContext;

        public BetRepository(RouletteDbContext rouletteDbContext)
        {
            this.rouletteDbContext = rouletteDbContext;
        }
        
        public async Task<Bet> PlaceBet(int[] numbers)
        {
                var newBet = new Bet
                                  {
                                      UserId = 1,
                                      BetType = 1
                                  };
                                  
                    var result = await this.rouletteDbContext.Bets.AddAsync(newBet);
                    await this.rouletteDbContext.SaveChangesAsync();
                    
                    foreach (int num in numbers)
                    {
                           var detail = new BetDetail
                           {
                                 BetId = result.Entity.Id,
                                 SelectedNumber = num
                           }
                           var item = await this.rouletteDbContext.BetDetail.AddAsync(detail);
                    }
                    await this.rouletteDbContext.SaveChangesAsync();
                    return result.Entity;
                    
          }

        public async Task<Spin> Spin()
        {
            Random rnd = new Random ();
            var spin = new Spin
            {
                 LandedNumber = rnd.Next(0, 37)
            };
            var item = await this.rouletteDbContext.Spin.AddAsync(spin);
            await this.rouletteDbContext.SaveChangesAsync();      
            return item;
        }
        
        public async Task<IEnumerable<Payout>> Payout()
        {
            var bets = await  this.rouletteDbContext.Spin.ToListAsync();
            foreach(var item in bets)
            {
                var payout = new Payout
                {
                    BetId = item.Id,
                    Amount = 123
                };
                await this.rouletteDbContext.Payout.AddAsync(payout);
            }
            await this.rouletteDbContext.SaveChangesAsync();
            var payouts = await this.rouletteDbContext.Payout.ToListAsync();
            return payouts; 
        
        }
        
        public async Task<IEnumerable<Spin>> ShowPreviousSpins()
        {
            var spins = await this.rouletteDbContext.Spin.ToListAsync();
            return spins; 
        
        }
        
    }
}