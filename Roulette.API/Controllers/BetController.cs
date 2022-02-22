using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Roulette.Api.Repositories.Contracts;
using Roulette.Api.Entities;

namespace Roulette.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BetController : ControllerBase
    {
        private readonly IBetRepository betRepository;

        public BetController(IBetRepository betRepository)
        {
            this.betRepository = betRepository;
        }
        
        [HttpPost]
        public async Task<IActionResult> PlaceBet(string [] numbers);
        {
                var bet = await this.betRepository.PlaceBet(numbers);
                return Ok(bet);
        }
        
        [HttpGet]
        public async Task<ActionResult<Spin>> Spin()
        {
                var spin = await this.betRepository.Spin();
                return Ok(spin);
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payout>>> Payout()
        {
                var payouts = await this.betRepository.Payout();
                return Ok(products);
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Spin>>> ShowPreviousSpins()
        {
                var spins = await this.betRepository.ShowPreviousSpins();
                return Ok(spins);
        }
        
        [Route("/error")]
        public IActionResult HandleError()
        {
              return Problem();
        }
        
    }
}