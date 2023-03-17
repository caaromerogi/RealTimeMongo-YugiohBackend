using Model.Entity;
using Model.Entity.CardInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DTO
{
    public class CardModifiedDTO
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? InInventory { get; set; }
        public string? Type { get; set; }
        public string? FrameType { get; set; }
        public string? Desc { get; set; }
        public int? Atk { get; set; }
        public int? Def { get; set; }
        public int? Level { get; set; }
        public string? Race { get; set; }
        public string? Attribute { get; set; }
        public IEnumerable<CardImage>? Card_Images { get; set; }
        public IEnumerable<CardPrice>? Card_Prices { get; set; }
        public string? CurrentOwner { get; set; }
        public IEnumerable<PastOwner>? LastOwners { get; set; }
        public string MongoOperationType { get; set; }

        public Card AsModelEntity()
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
                Card_Images = Card_Images,
                Card_Prices = Card_Prices,
                CurrentOwner = CurrentOwner,
                LastOwners = LastOwners,
            };
        }

    }
}
