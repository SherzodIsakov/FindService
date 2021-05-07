using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TextService.Entities.Models;

namespace FindService.Client
{
    public interface IFindClient
    {
        [Get("/text/find/{word}")]
        Task<IEnumerable<TextModel>> FindWord(string word);

        [Get("/text/find/{id}/{words}")]
        Task<IEnumerable<string>> FindWords(Guid id, string[] words);
    }
}
