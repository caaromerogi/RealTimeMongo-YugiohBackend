using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.UseCases;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class CardController : ControllerBase
    {
        private readonly IGetAllCardsUseCase _getCardsUseCase;

        public CardController(IGetAllCardsUseCase getCardsUseCase)
        {
            _getCardsUseCase = getCardsUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCards()
        {
            return Ok(await _getCardsUseCase.GetAllCards());
        }

    }
}
