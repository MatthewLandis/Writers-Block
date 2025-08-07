using WritersBlock.Server.Models;
using WritersBlock.Server.Databases;
using Dapper;

namespace WritersBlock.Server.Services
{
    public class StoryService(ISql sql) : IStoryService
    {
        private readonly ISql _sql = sql;

        public async Task<List<Story>> GetStories()
        {
            try
            {
                using Microsoft.Data.SqlClient.SqlConnection con = _sql.WritersBlock;
                List<Story> stories = (await con.QueryAsync<Story>("SELECT * FROM Stories")).ToList();

                return stories;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return [];
        }
    }
}
