using GalaxySoftwareCRM.Shared;
using Npgsql;

namespace GalaxySoftwareCRM.Server.DataAccess
{
    public class DbHelper
    {
        public static string? SqlConnectionString { get; set; }

        /// <summary>
        /// Execute By StringQuery.
        /// </summary>
        /// <param name="query">SQL query</param>
        public static async Task<int> ExecuteSqlNonQueryAsync(string query)
        {
            int  result = 0;

            using (NpgsqlConnection connection = new NpgsqlConnection(SqlConnectionString))
            {
                try
                {
                    NpgsqlCommand command = new();

                    command.CommandText = query;
                    command.CommandTimeout = 3600;
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;

                    connection.Open();
                    result = await command.ExecuteNonQueryAsync();
                    connection.Close();              
                }
                catch (Exception ex)
                {
                    throw new(ex.Message,ex.InnerException);
                }
            }
            return result;
        }

        /// <summary>
        /// Execute By StringQuery And Return Result
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static async Task<T?> ExecuteSqlScalarAsync<T>(string query)
        {
            dynamic? result;
  
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlConnectionString))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand();

                    command.CommandText = query;
                    command.CommandTimeout = 3600;
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;

                    connection.Open();
                    result = await command.ExecuteScalarAsync();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new(ex.Message, ex.InnerException);
                }
            }
            return result;
        }

        /// <summary>
        /// Get Online Data By Procedure For All Generic Types.
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static async Task<string> GetDataByProcedure(string? procedureName, List<ParameterHelper>? parameters)
        {
            string? result;
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlConnectionString))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand();

                    command.CommandText = procedureName;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandTimeout = 3600;
                    command.Connection = connection;
                    connection.Open();


                    if (parameters?.Count > 0)
                    {
                       
                        foreach (var item in parameters)
                        {
                            command.Parameters.Add(new NpgsqlParameter { ParameterName = item.PsqlParameterName, NpgsqlValue = item.PsqlParameterValue ?? DBNull.Value, Direction = item.PsqlParameterDirection, NpgsqlDbType = item.PsqlDbTypes });
                        }
                    }

                    
                    dynamic? jsonresult = await command.ExecuteScalarAsync();

                    result = jsonresult == null ? string.Empty : jsonresult?.ToString() ?? String.Empty;

                   
                }
                catch (Exception ex)
                {
                    throw new(ex.Message, ex.InnerException);
                }
            }
            return result;
        }

        /// <summary>
        /// Set Data By Procedure
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="parameters"></param>
        /// <returns>Effected Row By Execution</returns>
        public static async Task<int?> SetDataByProcedure(string? procedureName, List<ParameterHelper>? parameters)
        {
            int? result;

            using (NpgsqlConnection connection = new NpgsqlConnection(SqlConnectionString))
            {
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand();

                    command.CommandText = procedureName;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandTimeout = 3600;
                    command.Connection = connection;
                    connection.Open();


                    if (parameters?.Count > 0)
                    {
                        foreach (var item in parameters)
                        {
                            command.Parameters.Add(new NpgsqlParameter { ParameterName = item.PsqlParameterName, NpgsqlValue = item.PsqlParameterValue ?? DBNull.Value, Direction = item.PsqlParameterDirection, NpgsqlDbType = item.PsqlDbTypes });
                        }
                    }

                    result = await command.ExecuteNonQueryAsync();
                   
                }
                catch (Exception ex)
                {
                    throw new(ex.Message, ex.InnerException);
                }
            }

            return result;
        }
    }
}
