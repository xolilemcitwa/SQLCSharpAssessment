using Roulette.Api.Entities;

namespace Roulette.Api.Repositories.Contracts
{
    public interface IBetRepository
    {
        Task<Bet> PlaceBet(int[] numbers);
        Task<Spin> Spin();
        Task<IEnumerable<Payout>> Payout();
        Task<IEnumerable<Spin>> ShowPreviousSpins();

    }
}