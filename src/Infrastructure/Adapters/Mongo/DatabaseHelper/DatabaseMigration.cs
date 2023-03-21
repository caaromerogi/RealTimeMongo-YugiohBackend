using Mongo.Context;
using Mongo.DatabaseHelper.DTO;
using Mongo.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.DatabaseHelper
{
    public class DatabaseMigration : IDatabaseMigration
    {
        private readonly IMongoCollection<CardBsonEntity> _cardsCollection;
        HttpClient http;
        public DatabaseMigration(IContext context)
        {
            _cardsCollection = context.Cards;
            this.http = new HttpClient();
        }

        public async Task ReadCards()
        {
            var response = await http.GetAsync("https://db.ygoprodeck.com/api/v7/cardinfo.php");
            var fro = await response.Content.ReadFromJsonAsync<DAO>();


            var newCards = new List<CardBsonEntity>();
            for (var i = 0; i < 200; i++)
            {
                fro.Data[200 + i].InInventory = 5;
                newCards.Add(fro.Data[201 + i]);
            }

            await _cardsCollection.InsertManyAsync(newCards);

        }
    }
}
