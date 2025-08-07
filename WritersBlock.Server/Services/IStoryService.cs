using WritersBlock.Server.Models;

namespace WritersBlock.Server.Services
{
    public interface IStoryService
    {
        Task<List<Story>> GetStories();
    }
}
