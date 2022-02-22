namespace Roulette.Api.Entities
{
    public class Payout
    {
        public int Id { get; set; }
        public int BetId { get; set; }
        public double Amount { get; set; }

    }
}