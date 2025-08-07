using Microsoft.Data.SqlClient;

namespace WritersBlock.Server.Databases
{
    public interface ISql
    {
        SqlConnection WritersBlock { get; }
    }
}
