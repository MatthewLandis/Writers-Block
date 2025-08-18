using Microsoft.AspNetCore.Mvc;
using WritersBlock.Server.Services;
using WritersBlock.Server.Models;

namespace WritersBlock.Server.Controllers
{
    [ApiController]
    [Route("api/Story")]
    public class StoryController(IStoryService storyService) : ControllerBase
    {
        private readonly IStoryService _storyService = storyService;

        [HttpGet("GetStory")]
        public async Task<IActionResult> GetStory()
        {
            Story? story = await _storyService.GetStory();

            return story != null ? Ok(story) : BadRequest();
        }

        [HttpPost("AddStory")]
        public async Task<IActionResult> AddStory(Story storyToAdd)
        {
            bool success = await _storyService.AddStory(storyToAdd);

            return success ? Ok(true) : BadRequest();
        }

        [HttpGet("SearchStory")]
        public async Task<IActionResult> SearchStory([FromQuery] string title)
        {
            var story = await _storyService.SearchStory(title);
            if (story == null)
                return NotFound();
            return Ok(story);
        }

        [HttpGet("Rando")]
        public async Task<IActionResult> Rando()
        {
            Story? story = await _storyService.Rando();

            return story != null ? Ok(story) : BadRequest();
        }
    }
}
