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
using Inventec.Common.Logging;
using Inventec.Core;
using SAR.DAO.Base;
using SAR.EFMODEL.DataModels;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SAR.DAO.Sql
{
    public delegate void ResultHandler(ref object resultHolder, OracleDataReader dataReader, params OracleParameter[] pars);

    public partial class SqlExecuteUnmanaged : EntityBase
    {
        public bool ExecuteStored(ResultHandler resultHandler, ref object resultHolder, string storedProcedureSql, params OracleParameter[] parameters)
        {
            bool result = false;
            try
            {
                if (!String.IsNullOrEmpty(storedProcedureSql))
                {
                    using (var ctx = new UnmanagedAppContext())
                    {
                        OracleCommand cmd = (OracleCommand) ctx.Database.Connection.CreateCommand();
                        cmd.CommandText = storedProcedureSql;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddRange(parameters);

                        ctx.Database.Connection.Open();
                        //cmd.ExecuteNonQuery();
                        OracleDataReader dataReader = cmd.ExecuteReader();

                        resultHandler(ref resultHolder, dataReader, parameters);

                        cmd.Dispose();
                        ctx.Database.Connection.Close();
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                LogSystem.Error("storedProcedureSql: " + storedProcedureSql + LogUtil.TraceData("parameters:", parameters));
                result = false;
            }
            return result;
        }

        public static OracleParameter CreateCursorParameter(string name)
        {
            OracleParameter prm = new OracleParameter(name, OracleDbType.RefCursor);
            prm.Direction = ParameterDirection.Output;
            return prm;
        }

        public static OracleParameter CreateCustomTypeArrayInputParameter<T>(string name, string oracleUDTName, T value, ParameterDirection direction) where T : IOracleCustomType, INullable
        {
            OracleParameter parameter = new OracleParameter();
            parameter.ParameterName = name;
            parameter.OracleDbType = OracleDbType.Array;
            parameter.Direction = direction;
            parameter.UdtTypeName = oracleUDTName;
            parameter.Value = value;
            return parameter;
        }
    }
}
