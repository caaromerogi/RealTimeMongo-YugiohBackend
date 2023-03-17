using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.UseCases
{
    public interface IGetAllCardsUseCase
    {
        Task<IEnumerable<Card>> GetAllCards();
    }
}
