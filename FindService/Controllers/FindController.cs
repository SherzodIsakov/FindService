using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TextService.Client;
using TextService.Entities;

namespace FindService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FindController : ControllerBase
    {
        private readonly ITextClient _textClient;
        private readonly ILogger<FindController> _logger;

        public FindController(ITextClient textClient, ILogger<FindController> logger)
        {
            _textClient = textClient;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TextFile>> GetById(Guid id)
        {
            return await _textClient.GetById(id);
        }
    }
}
