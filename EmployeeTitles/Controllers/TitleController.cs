using EmployeeTitles.BLL.Models;
using EmployeeTitles.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTitles.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [RequireHttps]
    public class TitleController : ControllerBase
    {
        private readonly ITitleService _titleService;

        public TitleController(ITitleService titleService)
        {
            _titleService = titleService;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TitleModel>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTitles()
        {
            try
            {
                var result = await _titleService.GetAllAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TitleModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTitle(int id)
        {
            try
            {
                var result = await _titleService.GetByIdAsync(id);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddTitle(TitleModel title)
        {
            try
            {
                var result = await _titleService.AddAsync(title);

                if (result)
                {
                    return Ok();
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateTitle(TitleModel title)
        {
            try
            {
                var result = await _titleService.UpdateAsync(title);

                if (result)
                {
                    return Ok();
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteTitle(int id)
        {
            try
            {
                var result = await _titleService.DeleteByIdAsync(id);

                if (result)
                {
                    return Ok();
                }

                return Conflict();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
