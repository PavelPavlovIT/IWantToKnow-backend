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
    public class DataService: IDataService
    {

        // Set the connection, command, and then execute the command with non query.
        public int ExecuteNonQuery(string connectionString, string commandText, CommandType commandType, params MySqlParameter[] parameters)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(commandText, conn))
                {
                    // There're three command types: StoredProcedure, Text, TableDirect. The TableDirect
                    // type is only for OLE DB.
                    cmd.CommandType = commandType;
                    cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public async Task<int> ExecuteNonQueryAsync(string connectionString, string commandText, CommandType commandType, params MySqlParameter[] parameters)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(commandText, conn))
                {
                    // There're three command types: StoredProcedure, Text, TableDirect. The TableDirect
                    // type is only for OLE DB.
                    cmd.CommandType = commandType;
                    cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    var result = await cmd.ExecuteNonQueryAsync();
                    return result;
                }
            }
        }

        public object ExecuteScalar(string connectionString, string commandText, CommandType commandType, params MySqlParameter[] parameters)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(commandText, conn))
                {
                    cmd.CommandType = commandType;
                    cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        public async Task<object> ExecuteScalarAsync(string connectionString, string commandText, CommandType commandType, params MySqlParameter[] parameters)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (var command = new MySqlCommand(commandText, conn))
                {
                    command.CommandType = commandType;
                    command.Parameters.AddRange(parameters);

                    conn.Open();
                    var result = await command.ExecuteScalarAsync();
                    return result;
                }
            }
        }

        // Set the connection, command, and then execute the command with query and return the reader.
        public MySqlDataReader ExecuteReader(string connectionString, string commandText, CommandType commandType, params MySqlParameter[] parameters)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(commandText, conn))
                {
                    cmd.CommandType = commandType;
                    cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    // When using CommandBehavior.CloseConnection, the connection will be closed when the
                    // IDataReader is closed.
                    MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    return reader;
                }
            }
        }

        public async Task<MySqlDataReader> ExecuteReaderAsync(string connectionString, string commandText, CommandType commandType, params MySqlParameter[] parameters)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(commandText, conn))
                {
                    cmd.CommandType = commandType;
                    cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    // When using CommandBehavior.CloseConnection, the connection will be closed when the
                    // IDataReader is closed.
                    MySqlDataReader reader = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection);

                    return reader;
                }
            }
        }
    }
}
