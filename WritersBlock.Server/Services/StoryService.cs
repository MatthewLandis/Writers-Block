using WritersBlock.Server.Models;
using WritersBlock.Server.Databases;
using Dapper;

namespace WritersBlock.Server.Services
{
    public class StoryService(ISql sql) : IStoryService
    {
        private readonly ISql _sql = sql;

        public async Task<Story?> GetStory()
        {//              returns story or null
            try
            {
                using Microsoft.Data.SqlClient.SqlConnection con = _sql.WritersBlock;
                Story? story = await con.QuerySingleOrDefaultAsync<Story>("SELECT TOP 1 * FROM Stories");

                return story; //look
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null; //look | Djas was here, he's standing next to me. (9:48pm, 8/13/2025) 
        }

        public async Task<bool> AddStory(Story storyToAdd)
        {
            try
            {
                using Microsoft.Data.SqlClient.SqlConnection con = _sql.WritersBlock;
                int rowsAffected = await con.ExecuteAsync(
                    @"INSERT INTO Stories (Title, Author, Text)
                    VALUES (@Title, @Author, @Text);", storyToAdd
                );

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return false;
        }

        public async Task<Story?> SearchStory(string title)
        {
            try
            {
                using Microsoft.Data.SqlClient.SqlConnection con = _sql.WritersBlock;
                var story = await con.QueryFirstOrDefaultAsync<Story>(
                    "SELECT * FROM stories WHERE title LIKE '%' + @title + '%';",
                    new { title }
                );

                return story;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        public async Task<Story?> Rando()
        {
            try
            {
                using Microsoft.Data.SqlClient.SqlConnection con = _sql.WritersBlock;
                Story? story = await con.QuerySingleOrDefaultAsync<Story>("SELECT TOP 1 * FROM Stories ORDER BY NEWID();");

                return story;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex); //always breakpoint here
            }

            return null;
        }
    }
}
