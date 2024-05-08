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
using ACS.EFMODEL.DataModels;
using ACS.SDO;
using Inventec.Core;
using System;
using System.Collections.Generic;

namespace ACS.MANAGER.Core.AcsApplication.Create
{
    class AcsApplicationCreateBehaviorFactory
    {
        internal static IAcsApplicationCreate MakeIAcsApplicationCreate(CommonParam param, object data)
        {
            IAcsApplicationCreate result = null;
            try
            {
                if (data.GetType() == typeof(AcsApplicationWithDataSDO))
                {
                    result = new AcsApplicationCreateSdoBehavior(param, (AcsApplicationWithDataSDO)data);
                }
                else if (data.GetType() == typeof(ACS_APPLICATION))
                {
                    result = new AcsApplicationCreateBehaviorEv(param, (ACS_APPLICATION)data);
                }
                else if (data.GetType() == typeof(List<ACS_APPLICATION>))
                {
                    result = new AcsApplicationCreateBehaviorListEv(param, (List<ACS_APPLICATION>)data);
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
