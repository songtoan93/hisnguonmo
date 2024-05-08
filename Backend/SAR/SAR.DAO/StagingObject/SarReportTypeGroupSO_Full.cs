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
using SAR.DAO.Base;
using SAR.EFMODEL.DataModels;
using System;
using System.Collections.Generic;

namespace SAR.DAO.StagingObject
{
    public class SarReportTypeGroupSO : StagingObjectBase
    {
        public SarReportTypeGroupSO()
        {
            
        }

        public List<System.Linq.Expressions.Expression<Func<SAR_REPORT_TYPE_GROUP, bool>>> listSarReportTypeGroupExpression = new List<System.Linq.Expressions.Expression<Func<SAR_REPORT_TYPE_GROUP, bool>>>();
        public List<System.Linq.Expressions.Expression<Func<V_SAR_REPORT_TYPE_GROUP, bool>>> listVSarReportTypeGroupExpression = new List<System.Linq.Expressions.Expression<Func<V_SAR_REPORT_TYPE_GROUP, bool>>>();
    }
}