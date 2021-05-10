using FindService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TextService.Client;
using TextService.Entities.Models;

namespace FindService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FindServiceController : ControllerBase
    {
        private readonly ITextClient _textClient;
        //private readonly IFindService _findService;
        private readonly ILogger<FindServiceController> _logger;

        public FindServiceController(
            ITextClient textClient, 
            /*IFindService findService,*/ 
            ILogger<FindServiceController> logger)
        {
            _textClient = textClient;
            //_findService = findService;
            _logger = logger;
        }

        [HttpGet("textservice/{word}")]
        public async Task<IEnumerable<TextModel>> FindWord(string word)
        {
            if (word != null)
            {
                var getText = await _textClient.GetAllTexts();
                if (getText != null)
                {
                    var selectText = getText.Where(x => x.Text.Contains(word));
                    return selectText;
                }
            }

            return null;
        }

        [HttpGet("textservice/{id}/{words}")]
        public async Task<IEnumerable<string>> FindWords(Guid id, string[] words)
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

        [HttpGet]
        public async Task<IEnumerable<TextModel>> GetAllTexts()
        {
            try
            {
                var getText = await _textClient.GetAllTexts();
                return getText;
            }

            catch (Exception ex)
            {

                throw;
            }
        }


        #region IFindService

        //[HttpGet("textservice/{word}")]
        //public async Task<IEnumerable<TextModel>> FindWord(string word)
        //{
        //    var result = await _findService.FindWordAsync(word);
        //    return result;
        //}

        //[HttpGet("textservice/{id}/{words}")]
        //public async Task<IEnumerable<string>> FindWords(Guid id, string[] words)
        //{
        //    var result = await _findService.FindWordsAsync(id, words);
        //    return result;
        //}

        //[HttpGet("textservice/text/GetAllTexts")]
        //public async Task<IEnumerable<TextModel>> GetAllTexts()
        //{
        //    var result = await _findService.GetAllFilesAsync();
        //    return result;
        //}
        #endregion
    }
}
