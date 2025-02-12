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
using SAR.MANAGER.Core.SarUserReportType.Get.Ev;
using SAR.MANAGER.Core.SarUserReportType.Get.ListEv;
using Inventec.Core;
using System;
using System.Collections.Generic;
using SAR.MANAGER.Core.SarUserReportType.Get.ListV;
using SAR.MANAGER.Core.SarUserReportType.Get.V;

namespace SAR.MANAGER.Core.SarUserReportType
{
    partial class SarUserReportTypeGet : BeanObjectBase, IDelegacyT
    {
        object entity;

        internal SarUserReportTypeGet(CommonParam param, object data)
            : base(param)
        {
            entity = data;
        }

        T IDelegacyT.Execute<T>()
        {
            T result = default(T);
            try
            {
                if (typeof(T) == typeof(List<SAR_USER_REPORT_TYPE>))
                {
                    ISarUserReportTypeGetListEv behavior = SarUserReportTypeGetListEvBehaviorFactory.MakeISarUserReportTypeGetListEv(param, entity);
                    result = behavior != null ? (T)System.Convert.ChangeType(behavior.Run(), typeof(T)) : default(T);
                }
                else if (typeof(T) == typeof(SAR_USER_REPORT_TYPE))
                {
                    ISarUserReportTypeGetEv behavior = SarUserReportTypeGetEvBehaviorFactory.MakeISarUserReportTypeGetEv(param, entity);
                    result = behavior != null ? (T)System.Convert.ChangeType(behavior.Run(), typeof(T)) : default(T);
                }
                if (typeof(T) == typeof(List<V_SAR_USER_REPORT_TYPE>))
                {
                    ISarUserReportTypeGetListV behavior = SarUserReportTypeGetListVBehaviorFactory.MakeISarUserReportTypeGetListV(param, entity);
                    result = behavior != null ? (T)System.Convert.ChangeType(behavior.Run(), typeof(T)) : default(T);
                }
                else if (typeof(T) == typeof(V_SAR_USER_REPORT_TYPE))
                {
                    ISarUserReportTypeGetV behavior = SarUserReportTypeGetVBehaviorFactory.MakeISarUserReportTypeGetV(param, entity);
                    result = behavior != null ? (T)System.Convert.ChangeType(behavior.Run(), typeof(T)) : default(T);
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = default(T);
            }
            return result;
        }
    }
}
