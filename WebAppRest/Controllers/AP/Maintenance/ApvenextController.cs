using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services;
using Common.ViewModels;

namespace WebAppRest.Controllers.AP.Maintenance
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApvenextController : ControllerBase
    {
        private readonly ApvenextService _apvenextService;
        public ApvenextController(ApvenextService apvenextService)
        {
            _apvenextService = apvenextService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(string searchQuery = "", int pageNumber = 1, int pageSize = 10)
        {
            var (items, totalCount) = await _apvenextService.GetAllAsync(searchQuery, pageNumber, pageSize);
            var result = new
            {
                items,
                totalCount,
                pageNumber,
                pageSize,
                totalPages = (int)Math.Ceiling((double)totalCount / pageSize)
            };
            return Ok(result);
        }
        [HttpGet("procedure")]
        public async Task<ActionResult<IEnumerable<ApvenextDTO>>> GetByStoredProcedure()
        {
            var result = await _apvenextService.GetByStoredProcedureAsync();
            return Ok(result);
        }
    }
}
