/* IVT
 * @Project : hisnguonmo
 * Copyright (C) 2017 INVENTEC
 *  
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *  
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
 * GNU General Public License for more details.
 *  
 * You should have received a copy of the GNU General Public License
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
 */
using Inventec.Common.Repository;
using Inventec.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAR.DAO.Sql
{
    public partial class SqlDAO : EntityBase
    {
        private SqlExecute SqlWorker
        {
            get
            {
                return (SqlExecute)Worker.Get<SqlExecute>();
            }
        }

        private SqlExecuteUnmanaged SqlUnmanagedWorker
        {
            get
            {
                return (SqlExecuteUnmanaged)Worker.Get<SqlExecuteUnmanaged>();
            }
        }

        public bool ExecuteStored(ParamHandler paramHandler, ref object resultHolder, string sql, params Oracle.ManagedDataAccess.Client.OracleParameter[] parameters)
        {
            bool result = false;
            try
            {
                result = SqlWorker.ExecuteStored(paramHandler, ref resultHolder, sql, parameters);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        public bool ExecuteStoredUnmanaged(ResultHandler resultHandler, ref object resultHolder, string sql, params Oracle.DataAccess.Client.OracleParameter[] parameters)
        {
            bool result = false;
            try
            {
                result = SqlUnmanagedWorker.ExecuteStored(resultHandler, ref resultHolder, sql, parameters);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        public bool Execute(string sql, params object[] parameters)
        {
            bool result = false;
            try
            {
                result = SqlWorker.Execute(sql, parameters);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        public bool Execute(List<string> sqls)
        {
            bool result = false;
            try
            {
                result = SqlWorker.Execute(sqls);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        public bool Insert<T>(List<T> input)
        {
            bool result = false;
            try
            {
                result = SqlWorker.Insert(input);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        public List<RAW> GetSql<RAW>(string sql, params object[] parameters)
        {
            List<RAW> result = new List<RAW>();

            try
            {
                result = SqlWorker.GetSql<RAW>(sql, parameters);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result.Clear();
            }

            return result;
        }

        public RAW GetSqlSingle<RAW>(string sql, params object[] parameters)
        {
            RAW result = default(RAW);

            try
            {
                result = SqlWorker.GetSqlSingle<RAW>(sql, parameters);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = default(RAW);
            }

            return result;
        }

        /// <summary>
        /// Tra ve chuoi string co dang: IN (id1, id2, ...) or IN (id1001, id1002, ...)
        /// Luu y: trong menh de IN ko qua 1000 phan tu
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public string AddInClause(List<long> elements, string query, string property)
        {
            return SqlWorker.AddInClause(elements, query, property);
        }

        /**
         * Bo sung menh de NOT IN trong cau truy van
         */
        public string AddNotInClause(List<long> elements, string query, string property)
        {
            return SqlWorker.AddNotInClause(elements, query, property);
        }
    }
}
