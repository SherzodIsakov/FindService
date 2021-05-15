using FindService.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FindServiceController : ControllerBase
    {
        private readonly IFindService _findService;
        private readonly ILogger<FindServiceController> _logger;

        public FindServiceController(
            IFindService findService,
            ILogger<FindServiceController> logger)
        {
            _findService = findService;
            _logger = logger;
        }

        [HttpGet("{word}")]
        public async Task<IEnumerable<TextModel>> FindWord(string word)
        {
            if (word != null)
            {
                var getText = await _findService.FindWordAsync(word);
                if (getText != null)
                {
                    var selectText = getText.Where(x => x.Text.Contains(word));
                    return selectText;
                }
            }

            return null;
        }

        [HttpGet("{id}/{words}")]
        public async Task<IEnumerable<string>> FindWords(Guid id, string[] words)
        {
            if (words != null)
            {
                var getText = await _findService.FindWordsAsync(id, words);
                return getText;
            }

            return null;
        }

        [HttpGet]
        public async Task<IEnumerable<TextModel>> GetAllTexts()
        {
            try
            {
                var getText = await _findService.GetAllFilesAsync();
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
