using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace IWantKnowNet.Data.Services
{
    public interface IDataService
    {
        public int ExecuteNonQuery(string connectionString, string commandText, CommandType commandType, params MySqlParameter[] parameters);
        public Task<int> ExecuteNonQueryAsync(string connectionString, string commandText, CommandType commandType, params MySqlParameter[] parameters);
        public object ExecuteScalar(string connectionString, string commandText, CommandType commandType, params MySqlParameter[] parameters);
        public Task<object> ExecuteScalarAsync(string connectionString, string commandText, CommandType commandType, params MySqlParameter[] parameters);
        public MySqlDataReader ExecuteReader(string connectionString, string commandText, CommandType commandType, params MySqlParameter[] parameters);
        public Task<MySqlDataReader> ExecuteReaderAsync(string connectionString, string commandText, CommandType commandType, params MySqlParameter[] parameters);
    }
}
