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
using SAR.EFMODEL.DataModels;
using Inventec.Core;
using System;
using System.Collections.Generic;

namespace SAR.MANAGER.Core.SarPrintLog.Create
{
    class SarPrintLogCreateBehaviorFactory
    {
        internal static ISarPrintLogCreate MakeISarPrintLogCreate(CommonParam param, object data)
        {
            ISarPrintLogCreate result = null;
            try
            {
                //if (data.GetType() == typeof(SAR_PRINT_LOG))
                //{
                //    result = new SarPrintLogCreateBehaviorEv(param, (SAR_PRINT_LOG)data);
                //}
                //else 
                if (data.GetType() == typeof(SDO.SarPrintLogSDO))
                {
                    result = new SarPrintLogCreateBehaviorSDO(param, (SDO.SarPrintLogSDO)data);
                }
                else if (data.GetType() == typeof(List<SDO.SarPrintLogSDO>))
                {
                    result = new SarPrintLogCreateListBehaviorSDO(param, (List<SDO.SarPrintLogSDO>)data);
                }
                if (result == null) throw new NullReferenceException();
            }
            catch (NullReferenceException ex)
            {
                MANAGER.Base.BugUtil.SetBugCode(param, LibraryBug.Bug.Enum.Common__FactoryKhoiTaoDoiTuongThatBai);
                Inventec.Common.Logging.LogSystem.Error("Factory khong khoi tao duoc doi tuong." + data.GetType().ToString() + Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => data), data), ex);
                result = null;
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = null;
            }
            return result;
        }
    }
}
