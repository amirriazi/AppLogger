using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AppLogger.Data
{
    public partial class SqlDatabase
    {
        public QueryResult reportLog(Guid apiKey, string level, string message, string processId, string property= null)
        {
            var sqlParameters = new List<SqlParameter>();
            var storedProcedureName = "ud_prc_reportLog";
            sqlParameters.Add(new SqlParameter { SqlDbType = SqlDbType.UniqueIdentifier, ParameterName = "@apiKey", Value = apiKey });
            sqlParameters.Add(new SqlParameter { SqlDbType = SqlDbType.NVarChar, ParameterName = "@level", Value = level});
            sqlParameters.Add(new SqlParameter { SqlDbType = SqlDbType.NVarChar, ParameterName = "@message", Value = message});
            sqlParameters.Add(new SqlParameter { SqlDbType = SqlDbType.NVarChar, ParameterName = "@processId", Value = processId});
            sqlParameters.Add(new SqlParameter { SqlDbType = SqlDbType.NVarChar, ParameterName = "@property", Value = property});

            return ExecuteStoredProcedure(storedProcedureName, sqlParameters);
        }
        
       
    }
}
