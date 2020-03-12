using HistoryService.API.Infrastructure.Repositories;
using HistoryService.API.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoryService.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly IRecordsService _recordsService;

        public RecordsController(IRecordsService recordsService)
        {
            _recordsService = recordsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRecords(int skip = 0, int limit = 50)
        {
            return Ok(await _recordsService.GetRecordsAsync(skip,limit));
        }

    }
}
