using FindService.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TextService.Client;
using TextService.Entities.Models;

namespace FindService.Services.Services
{
    public class FindService : IFindService
    {
        private readonly ITextClient _textClient;
        public FindService(ITextClient textClient)
        {
            _textClient = textClient;
        }

        /// <summary>
        /// Поиск слова во всех файлах
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TextModel>> FindWordAsync(string word)
        {
            if (word != null)
            {
                var getText = await _textClient.GetAll();
                if (getText != null)
                {
                    var selectText = getText.Where(x => x.Text.Contains(word));
                    return selectText;
                }
            }

            return null;
        }

        /// <summary>
        /// Поиск слов в указанном файле
        /// </summary>
        /// <param name="id"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public async Task<IEnumerable<string>> FindWordsAsync(Guid id, string[] words)
        {
            if (words != null)
            {
                var getText = await _textClient.GetById(id);
                if (getText != null)
                {
                    var textArray = getText.Text.Replace('\r', ' ').Replace('\n', ' ').Replace("  ", " ").Split(" ");
                    var selectText = textArray.SelectMany(e => words.Where(x => x == e));
                    return selectText;
                }
            }

            return null;
        }

    }
}
