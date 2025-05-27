using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Nilvera.Application.Repository
{
    public class SqlDbBase
    {
        protected string Connstr;

        public SqlDbBase(string connectionstring)
        {
            this.Connstr = connectionstring;
        }

        public T? Query<T>(string queryString, object parms)
        {
            using (IDbConnection conn = new SqlConnection(Connstr))
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    var result = conn.Query<T>(queryString, parms, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("Veritabanı sorgusu sırasında bir hata oluştu.", ex);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
        }


        public List<T> QueryList<T>(string queryString, object parms)
        {
            using (var conn = new SqlConnection(Connstr))
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    var result = conn.Query<T>(queryString, parms, commandType: CommandType.StoredProcedure).ToList();

                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception("Veritabanı sorgusu sırasında bir hata oluştu.", ex);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
        }
    }
}
