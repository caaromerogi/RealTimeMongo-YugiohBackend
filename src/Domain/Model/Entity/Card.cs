using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entity.CardInfo;

namespace Model.Entity
{
    public class Card
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
    }
}
