namespace Nilvera.Application.Repository
{
    public class DBUtils
    {
        public static string? ConnectionString;
        public static SqlDbBase? DbBase;
        public static void SetConnectionString(string connstr)
        {
            ConnectionString = connstr;
            DbBase = new SqlDbBase(connstr);
        }
    }
}
