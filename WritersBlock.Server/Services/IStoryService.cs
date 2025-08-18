using System;
using WritersBlock.Server.Models;

namespace WritersBlock.Server.Services
{
    public interface IStoryService
    {
        Task<Story?> GetStory();
        Task<bool> AddStory(Story storyToAdd);
        Task<Story?> SearchStory(string title);
        Task<Story?> Rando();
    }
}
