using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextService.Entities.Models;

namespace FindService.Services.Interfaces
{
    public interface IFindService
    {
        Task<IEnumerable<TextModel>> FindWordAsync(string word);
        Task<IEnumerable<string>> FindWordsAsync(Guid id, string[] words);
    }
}
