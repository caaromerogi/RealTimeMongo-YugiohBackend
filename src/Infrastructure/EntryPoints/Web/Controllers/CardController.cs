using Microsoft.AspNetCore.Mvc;
using Mongo.DatabaseHelper;
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
        private readonly IDatabaseMigration _migration;

        public CardController(IGetAllCardsUseCase getCardsUseCase, IDatabaseMigration migration)
        {
            _getCardsUseCase = getCardsUseCase;
            _migration = migration;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCards()
        {
            return Ok(await _getCardsUseCase.GetAllCards());
        }

        [HttpGet("/migrate")]
        public async Task<IActionResult> MigrateDatabase()
        {
            await _migration.ReadCards();
            return Ok();
        }

    }
}
