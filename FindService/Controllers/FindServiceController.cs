using FindService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TextService.Entities.Models;

namespace FindService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FindServiceController : ControllerBase
    {
        private readonly IFindService _findService;
        private readonly ILogger<FindServiceController> _logger;

        public FindServiceController(IFindService findService, ILogger<FindServiceController> logger)
        {
            _findService = findService;
            _logger = logger;
        }

        [HttpGet("find/{word}")]
        public async Task<IEnumerable<TextModel>> FindWord(string word)
        {
            var result = await _findService.FindWordAsync(word);
            return result;
        }

        [HttpGet("find/{id}/{words}")]
        public async Task<IEnumerable<string>> FindWords(Guid id, string[] words)
        {
            var result = await _findService.FindWordsAsync(id, words);
            return result;
        }

        [HttpGet("find/GetAllTexts")]
        public async Task<IEnumerable<TextModel>> GetAllTexts()
        {
            var result = await _findService.GetAllFilesAsync();
            return result;
        }
    }
}
