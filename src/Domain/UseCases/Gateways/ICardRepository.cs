﻿using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Gateways
{
    public interface ICardRepository
    {
        Task<Card> GetCardById(int id);
        Task<IEnumerable<Card>> GetAllCards();
    }
}
