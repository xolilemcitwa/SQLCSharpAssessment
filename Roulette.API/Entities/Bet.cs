namespace Roulette.Api.Entities
{
    public class Bet
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BetType { get; set; }
        public int SpinId { get; set; }

    }
}