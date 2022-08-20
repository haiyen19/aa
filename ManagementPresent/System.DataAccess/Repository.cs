using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections;

namespace System.DataAccess
{
    public class Repository
    {
        private readonly string _connectionString;
        private readonly SqlConnection _connection;

        public Repository()
        {
            _connectionString = DbConnection.Get();
            _connection = new SqlConnection(_connectionString);
        }


        //store with not parameter
        public async Task<int> ExecuteNonQueryAsync(CommandType commandType, string commandText)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = sqlConnection;
                command.CommandType = commandType;
                command.CommandText = commandText;
                var result =  await command.ExecuteNonQueryAsync();
                sqlConnection.Close();
                return result;
            }
        }

        public async Task<int> ExecuteNonQueryAsync(string spName, params object[] parameterValues)
        {
            //if we receive parameter values, we need to figure out where they go
            if (parameterValues != null)
            {
                try
                {
                    //call the overload that takes an array of SqlParameters
                    using (var sqlConnection = new SqlConnection(_connectionString))
                    {
                        sqlConnection.Open();
                        SqlCommand command = new SqlCommand();
                        command.Connection = sqlConnection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = spName;

                        foreach (var paramData in parameterValues)
                        {
                            foreach (PropertyInfo prop in paramData.GetType().GetProperties())
                            {
                                var NameParams = prop.Name;
                                var type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                                var item = prop.GetValue(paramData, null);
                                await Task.Run(() => GetParameter(ref command, NameParams, item, type));
                            }
                        }

                        var result = await command.ExecuteNonQueryAsync();
                        sqlConnection.Close();
                        return result;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return await ExecuteNonQueryAsync(CommandType.StoredProcedure, spName);
        }



        public async Task<object> ExecuteScalarAsync(CommandType commandType, string commandText)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = sqlConnection;
                command.CommandType = commandType;
                command.CommandText = commandText;
                var result =  await command.ExecuteScalarAsync();
                sqlConnection.Close();
                return result;
            }
        }

        public async Task<object> ExecuteScalarAsync(string spName, params object[] parameterValues)
        {
            //if we receive parameter values, we need to figure out where they go
            if (parameterValues != null)
            {
                try
                {
                    //call the overload that takes an array of SqlParameters
                    using (var sqlConnection = new SqlConnection(_connectionString))
                    {
                        sqlConnection.Open();
                        SqlCommand command = new SqlCommand();
                        command.Connection = sqlConnection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = spName;

                        object[] paramsdata = parameterValues as object[];

                        foreach (var paramData in parameterValues)
                        {
                            foreach (PropertyInfo prop in paramData.GetType().GetProperties())
                            {
                                var NameParams = prop.Name;
                                var type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                                var item = prop.GetValue(paramData, null);
                                await Task.Run(() => GetParameter(ref command, NameParams, item, type));
                            }
                        }

                        var result = await command.ExecuteScalarAsync();
                        sqlConnection.Close();
                        return result;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return await ExecuteScalarAsync(CommandType.StoredProcedure, spName);
        }

        private void GetParameter(ref SqlCommand command,string nameParam, object value,Type type)
        {
            if (value == null)
            {
                if(type.Name == "Byte[]")
                {
                    command.Parameters.Add(new SqlParameter("@" + nameParam, DBNull.Value)).SqlDbType = SqlDbType.Image;
                }
                else
                {
                    command.Parameters.Add(new SqlParameter("@" + nameParam, DBNull.Value));
                }
            }
            else
            {
                command.Parameters.Add(new SqlParameter("@" + nameParam, value));
            }
        }


        public async Task<List<T>> ExecuteReaderAsync<T>(string spName, params object[] parameterValues)
        {
            //if we receive parameter values, we need to ExecuteReaderAsync out where they go
            if (parameterValues != null)
            {
                try
                {
                    var Table = new DataTable();
                    using (var sqlConnection = new SqlConnection(_connectionString))
                    {
                        sqlConnection.Open();
                        SqlCommand command = new SqlCommand();
                        command.Connection = sqlConnection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = spName;

                        //T data;
                        foreach (var paramData in parameterValues)
                        {
                            foreach (PropertyInfo prop in paramData.GetType().GetProperties())
                            {
                                var NameParams = prop.Name;
                                var type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                                var item = prop.GetValue(paramData, null);
                                await Task.Run(() => GetParameter(ref command, NameParams, item, type));
                            }
                        }

                        SqlDataReader dr = await command.ExecuteReaderAsync(CommandBehavior.CloseConnection);
                        Table.Load(dr);
                        sqlConnection.Close();
                        return ConvertDataTable<T>(Table);
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            return await ExecuteReaderAsync<T>(CommandType.StoredProcedure, spName);
        }

        public async Task<List<T>> ExecuteReaderAsync<T>(CommandType commandType, string commandText)
        {
            var Table = new DataTable();
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = sqlConnection;
                command.CommandType = commandType;
                command.CommandText = commandText;
                SqlDataReader dr = await command.ExecuteReaderAsync(CommandBehavior.CloseConnection);
                Table.Load(dr);
                sqlConnection.Close();
                return ConvertDataTable<T>(Table);
            }
        }


        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                    {
                        var value = dr[column.ColumnName];
                        if (value == DBNull.Value)
                            value = null;
                        pro.SetValue(obj, value, null);
                    }
                    else
                        continue;
                }
            }
            return obj;
        }

    }
}
