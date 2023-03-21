using Model.Entity;
using Model.Entity.CardInfo;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.Entities
{
    public class CardBsonEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int? Id { get; set; }
        [BsonElement(elementName:"Name")]
        public string? Name { get; set; }
        [BsonElement(elementName: "InInventory")]
        public int? InInventory { get; set; }
        [BsonElement(elementName: "Type")]
        public string? Type { get; set; }
        [BsonElement(elementName: "FrameType")]
        public string? FrameType { get; set; }
        [BsonElement(elementName: "Desc")]
        public string? Desc { get; set; }
        [BsonElement(elementName: "Atk")]
        public int? Atk { get; set; }
        [BsonElement(elementName: "Def")]
        public int? Def { get; set; }
        [BsonElement(elementName: "Level")]
        public int? Level { get; set; }
        [BsonElement(elementName: "Race")]
        public string? Race { get; set; }
        [BsonElement(elementName: "Attribute")]
        public string? Attribute { get; set; }
        [BsonElement(elementName: "Card_Images")]
        public IEnumerable<CardImage>? Card_Images { get; set; }
        [BsonElement(elementName: "Card_Prices")]
        public IEnumerable<CardPrice>? Card_Prices { get; set; }
        [BsonElement(elementName: "CurrentOwner")]
        public string? CurrentOwner { get; set; }
        [BsonElement(elementName: "LastOwners")]
        public IEnumerable<PastOwner>? LastOwners { get; set; }

        public Card AsDomainEntity()
        {
            return new()
            {
                Id = Id,
                Name = Name,
                InInventory = InInventory,
                Type = Type,
                FrameType = FrameType,
                Desc = Desc,
                Atk = Atk,
                Def = Def,
                Level = Level,
                Race = Race,
                Attribute = Attribute,
                CardImages = Card_Images,
                CardPrices = Card_Prices,
                CurrentOwner = CurrentOwner,
                LastOwners = LastOwners,
            };
        }
    }
}
