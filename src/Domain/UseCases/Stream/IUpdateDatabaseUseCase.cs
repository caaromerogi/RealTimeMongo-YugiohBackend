using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DTO;

namespace UseCases.Stream
{
    public interface IUpdateDatabaseUseCase
    {
        public Task<CardModifiedDTO> UpdateDatabaseAsync();
    }
}
