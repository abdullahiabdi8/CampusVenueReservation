using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace CampusVenueReservation.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly string _tableName;
        private readonly string _MethodName;


        public T SPWithParameterSingleReturn(object param)
        {
            T result = null;
            using (var connection = CreateConnection())
            {
                try
                {
                    result = connection.Query<T>($"{_tableName}", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    connection.Dispose();
                }
                catch (Exception ex)
                {
                    connection.Dispose();
                    ErrorLog.LogTxt(" SPWithParameterSingleReturn : ", _MethodName, ex.ToString());
                    ErrorLog.APIError(ex.Message, ex.StackTrace, ex.InnerException == null ? "" : ex.InnerException.ToString(), _MethodName);
                }
            }
            return result;
        }

        public GenericRepository(string tableName,string CallingMethodName)
        {
            _tableName = tableName;
            _MethodName = CallingMethodName;

        }

        private SqlConnection SqlConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["stringConnections"].ToString());
        }

        private IDbConnection CreateConnection()
        {
            var conn = SqlConnection();
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                ErrorLog.LogTxt("CreateConnection", _MethodName, ex.ToString());
                ErrorLog.APIError(ex.Message, ex.StackTrace, ex.InnerException == null ? "" : ex.InnerException.ToString(), _MethodName);
            }
            return conn;
        }

        private IEnumerable<PropertyInfo> GetProperties => typeof(T).GetProperties();

        //public T SPWithParameterSingleReturn(object param)
        //{
        //    T result = null;
        //    using (var connection = CreateConnection())
        //    {
        //        try
        //        {
        //            result = connection.Query<T>($"{_tableName}", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
        //            connection.Dispose();
        //        }
        //        catch (Exception ex)
        //        {
        //            connection.Dispose();
        //            ErrorLog.LogTxt(" SPWithParameterSingleReturn : ", _MethodName, ex.ToString());
        //        }
        //    }
        //    return result;
        //}

        public IEnumerable<T> GetAllRecord()
        {
            IEnumerable<T> Result = null;
            try
            {
                using (var connection = CreateConnection())
                {
                    Result = connection.Query<T>($"SELECT * FROM {_tableName}");
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogTxt("GetAll", _MethodName, ex.ToString());
                ErrorLog.APIError(ex.Message, ex.StackTrace, ex.InnerException == null ? "" : ex.InnerException.ToString(), _MethodName);
            }
            return Result;
        }

        public int Insert(T t)
        {
            int ID = 0;
            try
            {
                var insertQuery = GenerateInsertQuery();
                using (var connection = CreateConnection())
                {
                    ID = connection.ExecuteScalar<int>(insertQuery, t);
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogTxt("Insert", _MethodName, ex.ToString());
                ErrorLog.APIError(ex.Message, ex.StackTrace, ex.InnerException == null ? "" : ex.InnerException.ToString(), _MethodName);
            }
            return ID;
        }

        public int DeleteRow(int id)
        {
            int ID = 0;
            try
            {
                using (var connection = CreateConnection())
                {
                    ID = connection.Execute($"DELETE FROM {_tableName} WHERE Id=@Id", new { Id = id });
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogTxt("DeleteRow" , _MethodName, ex.ToString());
                ErrorLog.APIError(ex.Message, ex.StackTrace, ex.InnerException == null ? "" : ex.InnerException.ToString(), _MethodName);
            }
            return ID;
        }
        
        public int DeleteRowByRegion(int RegionID)
        {
            int ID = 0;
            try
            {
                using (var connection = CreateConnection())
                {
                    ID = connection.Execute($"DELETE FROM {_tableName} WHERE RegionID=@RegionID", new { RegionID = RegionID });
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogTxt("DeleteRow" , _MethodName, ex.ToString());
                ErrorLog.APIError(ex.Message, ex.StackTrace, ex.InnerException == null ? "" : ex.InnerException.ToString(), _MethodName);
            }
            return ID;
        }

        public int UpdateAsync(T t)
        {
            int ID = 0;  
            try
            {
                var updateQuery = GenerateUpdateQuery();

                using (var connection = CreateConnection())
                {
                    ID = connection.ExecuteScalar<int>(updateQuery, t);
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogTxt("UpdateAsync", _MethodName, ex.ToString());
                ErrorLog.APIError(ex.Message, ex.StackTrace, ex.InnerException == null ? "" : ex.InnerException.ToString(), _MethodName);
                ID = -1;
            }
            return ID;
        }

        public int UpdateAsyncWithID(T t)
        {
            int ID = 0;
            try
            {
                var updateQuery = GenerateUpdateQueryWithID();

                using (var connection = CreateConnection())
                {
                    ID = connection.ExecuteScalar<int>(updateQuery, t);
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogTxt("UpdateAsync", _MethodName, ex.ToString());
                ErrorLog.APIError(ex.Message, ex.StackTrace, ex.InnerException == null ? "" : ex.InnerException.ToString(), _MethodName);
                ID = -1;
            }
            return ID;
        }
        
        public int UpdateAsyncWithAgentID(T t)
        {
            int ID = 0;
            try
            {
                var updateQuery = GenerateUpdateQueryWithAgentID();

                using (var connection = CreateConnection())
                {
                    ID = connection.ExecuteScalar<int>(updateQuery, t);
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogTxt("UpdateAsync", _MethodName, ex.ToString());
                ErrorLog.APIError(ex.Message, ex.StackTrace, ex.InnerException == null ? "" : ex.InnerException.ToString(), _MethodName);
                ID = -1;
            }
            return ID;
        }


        public T GetSingleRecord(int id)
        {
            T result = null;
            try
            {
                using (var connection = CreateConnection())
                {
                    result = connection.QuerySingleOrDefault<T>($"SELECT * FROM {_tableName} WHERE Id=@Id", new { Id = id });
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogTxt("SPWithOutParameter", _MethodName, ex.ToString());
                ErrorLog.APIError(ex.Message, ex.StackTrace, ex.InnerException == null ? "" : ex.InnerException.ToString(), _MethodName);
            }
            return result;
        }


        //Stored Procedure Calling ************************************
        //Call StoredProcedure Without Any Arguments
        public IEnumerable<T> SPWithOutParameter()
        {
            IEnumerable<T> result = null;
            try
            {
                using (var connection = CreateConnection())
                {
                    result = connection.Query<T>($"{_tableName}", commandType: CommandType.StoredProcedure);
                    connection.Dispose();
                }
            }
            catch (Exception ex) {
                ErrorLog.LogTxt("SPWithOutParameter", _MethodName, ex.ToString());
                ErrorLog.APIError(ex.Message, ex.StackTrace, ex.InnerException == null ? "" : ex.InnerException.ToString(), _MethodName);
            }
            return result;
        }
        //Call StoredProcedure Wit Paramert
        public  IEnumerable<T> SPWithParameter(object param)
        {
            IEnumerable<T> result = null;
            try {
                using (var connection = CreateConnection())
                {
                    result = connection.Query<T>($"{_tableName}", param, commandType: CommandType.StoredProcedure);
                    connection.Dispose();
                }
            } catch (Exception ex) {
                ErrorLog.LogTxt(" SPWithParameter : ", _MethodName, ex.ToString());
                ErrorLog.APIError(ex.Message, ex.StackTrace, ex.InnerException == null ? "" : ex.InnerException.ToString(), _MethodName);
            }
            return result;
        }
        public IEnumerable<T> GetWhereRecord(object t)
        {
            IEnumerable<T> data = null;
            try
            {
                using (var connection = CreateConnection())
                {
                    string Query = GenerateWhereQuery(t);
                    data = connection.Query<T>(Query, t);
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogTxt("GetWhereSingleRecord",_MethodName, ex.ToString());
                ErrorLog.APIError(ex.Message, ex.StackTrace, ex.InnerException == null ? "" : ex.InnerException.ToString(), _MethodName);
            }
            return data;
        }
        //Stored Procedure Calling ************************************

        //Generate Inserted Query
        private string GenerateInsertQuery()
        {
            var insertQuery = new StringBuilder($"INSERT INTO {_tableName}");

            insertQuery.Append("(");

            var properties = GenerateListOfPropertiesForInsert(GetProperties);
            properties.ForEach(prop => { insertQuery.Append($"[{prop}],"); });

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(") VALUES (");

            properties.ForEach(prop => { insertQuery.Append($"@{prop},"); });

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(")");

            return insertQuery.ToString()+" select scope_identity()"; ;
        }
        //Generate Update Query
        private string GenerateUpdateQuery()
        {
            var updateQuery = new StringBuilder($"UPDATE {_tableName} SET ");
            var properties = GenerateListOfProperties(GetProperties);

            properties.ForEach(property =>
            {
                if (!property.Equals("Id"))
                {
                    updateQuery.Append($"{property}=@{property},");
                }
            });

            updateQuery.Remove(updateQuery.Length - 1, 1); //remove last comma
            updateQuery.Append(" WHERE Id=@Id");

            return updateQuery.ToString();
        }

        private string GenerateUpdateQueryWithID()
        {
            var updateQuery = new StringBuilder($"UPDATE {_tableName} SET ");
            var properties = GenerateListOfProperties(GetProperties);

            properties.ForEach(property =>
            {
                if (!property.Equals("ID"))
                {
                    updateQuery.Append($"{property}=@{property},");
                }
            });

            updateQuery.Remove(updateQuery.Length - 1, 1); //remove last comma
            updateQuery.Append(" WHERE ID=@ID");

            return updateQuery.ToString();
        }
        
        private string GenerateUpdateQueryWithAgentID()
        {
            var updateQuery = new StringBuilder($"UPDATE {_tableName} SET ");
            var properties = GenerateListOfProperties(GetProperties);

            properties.ForEach(property =>
            {
                if (!property.Equals("AgentID"))
                {
                    updateQuery.Append($"{property}=@{property},");
                }
            });

            updateQuery.Remove(updateQuery.Length - 1, 1); //remove last comma
            updateQuery.Append(" WHERE AgentID=@AgentID");

            return updateQuery.ToString();
        }


        private static List<string> GenerateListOfProperties(IEnumerable<PropertyInfo> listOfProperties)
        {
            return (from prop in listOfProperties
                    let attributes = prop.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    where attributes.Length <= 0 || (attributes[0] as DescriptionAttribute)?.Description != "Id"
                    select prop.Name).ToList();
        }

        private string GenerateWhereQuery(object t) {

            string query = $"Select * from {_tableName} where ";
            foreach (PropertyInfo data in t.GetType().GetProperties())
            {

                query += $"{data.Name}=@{data.Name} and ";
            }

            query=query.Remove(query.Length - 4, 4); //removing last and
            return query.ToString();
        }

        private static List<string> GenerateListOfPropertiesForInsert(IEnumerable<PropertyInfo> listOfProperties)
        {
            listOfProperties = listOfProperties.Where(x => x.Name != "ID").ToList();
            return (from prop in listOfProperties
                    let attributes = prop.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    where attributes.Length <= 0 || (attributes[0] as DescriptionAttribute)?.Description != "ID"
                    select prop.Name).ToList();
        }

        private static List<string> GenerateListOfPropertiesForWhere(IEnumerable<PropertyInfo> listOfProperties)
        {
            return (from prop in listOfProperties
                    let attributes = prop.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    where attributes.Length <= 0 || (attributes[0] as DescriptionAttribute)?.Description != "ignore"
                    select prop.Name).ToList();
        }
     
    }
    public class GenericRepository<T1, T2> where T1 : class where T2 : class
    {
        private readonly string _tableName;
        private readonly string _MethodName;
        public GenericRepository(string tableName, string CallingMethodName)
        {
            _tableName = tableName;
            _MethodName = CallingMethodName;

        }

        public (List<T1>, List<T2>) ExecuteStoreProcedure(object param)
        {
            List<T1> result1 = null;
            List<T2> result2 = null;
            try
            {
                using (var connection = DBConnections.GetConnection())
                {
                    var results = connection.QueryMultiple($"{_tableName}", param, commandType: CommandType.StoredProcedure);
                    result1 = results.Read<T1>().ToList();
                    result2 = results.Read<T2>().ToList();
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogTxt("ExecuteStoreProcedure(parameter)" + _tableName, _MethodName, ex.ToString());
            }
            return (result1, result2);
        }
        public (List<T1>, List<T2>) ExecuteStoreProcedure()
        {
            List<T1> result1 = null;
            List<T2> result2 = null;
            try
            {
                using (var connection = DBConnections.GetConnection())
                {
                    var results = connection.QueryMultiple($"{_tableName}", null, commandType: CommandType.StoredProcedure);
                    result1 = results.Read<T1>().ToList();
                    result2 = results.Read<T2>().ToList();
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.LogTxt("ExecuteStoreProcedure(parameter)" + _tableName, _MethodName, ex.ToString());
            }
            return (result1, result2);
        }

    }
}