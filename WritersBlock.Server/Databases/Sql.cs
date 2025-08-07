using Microsoft.Extensions.Options;
using Microsoft.Data.SqlClient;

namespace WritersBlock.Server.Databases
{
    public class Sql(IOptions<Settings> settings) : ISql
    {
        private readonly string _connectionString = settings!.Value.WritersBlock;

        public SqlConnection WritersBlock => new(_connectionString);
    }
}
