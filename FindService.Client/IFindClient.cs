using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TextService.Entities.Models;

namespace FindService.Client
{
    public interface IFindClient
    {
        /// <summary>
        /// Поиск слова во всех текстах
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        [Get("/api/findservice/{word}")]
        Task<IEnumerable<TextModel>> FindWord(string word); //, [Header("Authorization")] string token

        /// <summary>
        /// Поиск слов в указанном тексте
        /// </summary>
        /// <param name="id">Text id</param>
        /// <param name="words"></param>
        /// <returns></returns>
        [Get("/api/findservice/{id}/{words}")]
        Task<IEnumerable<string>> FindWords(Guid id, string[] words);

        /// <summary>
        /// Получаем все файлы
        /// </summary>
        /// <returns></returns>
        [Get("/api/findservice")]
        Task<IEnumerable<TextModel>> GetAllTexts();
    }
}
