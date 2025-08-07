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

        [HttpGet("GetStories")]
        public async Task<IActionResult> GetStories()
        {
            List<Story> stories = await _storyService.GetStories();

            return stories.Count > 0 ? Ok(stories) : BadRequest();
        }
    }
}
