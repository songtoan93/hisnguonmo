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
using SAR.MANAGER.Core.SarPrintType.Get.Ev;
using SAR.MANAGER.Core.SarPrintType.Get.ListEv;
using SAR.MANAGER.Core.SarPrintType.Get.ListV;
using SAR.MANAGER.Core.SarPrintType.Get.V;
using Inventec.Core;
using System;
using System.Collections.Generic;

namespace SAR.MANAGER.Core.SarPrintType
{
    partial class SarPrintTypeGet : BeanObjectBase, IDelegacyT
    {
        object entity;

        internal SarPrintTypeGet(CommonParam param, object data)
            : base(param)
        {
            entity = data;
        }

        T IDelegacyT.Execute<T>()
        {
            T result = default(T);
            try
            {
                if (typeof(T) == typeof(List<SAR_PRINT_TYPE>))
                {
                    ISarPrintTypeGetListEv behavior = SarPrintTypeGetListEvBehaviorFactory.MakeISarPrintTypeGetListEv(param, entity);
                    result = behavior != null ? (T)System.Convert.ChangeType(behavior.Run(), typeof(T)) : default(T);
                }
                else if (typeof(T) == typeof(SAR_PRINT_TYPE))
                {
                    ISarPrintTypeGetEv behavior = SarPrintTypeGetEvBehaviorFactory.MakeISarPrintTypeGetEv(param, entity);
                    result = behavior != null ? (T)System.Convert.ChangeType(behavior.Run(), typeof(T)) : default(T);
                }
                else if (typeof(T) == typeof(List<V_SAR_PRINT_TYPE>))
                {
                    ISarPrintTypeGetListV behavior = SarPrintTypeGetListVBehaviorFactory.MakeISarPrintTypeGetListV(param, entity);
                    result = behavior != null ? (T)System.Convert.ChangeType(behavior.Run(), typeof(T)) : default(T);
                }
                else if (typeof(T) == typeof(V_SAR_PRINT_TYPE))
                {
                    ISarPrintTypeGetV behavior = SarPrintTypeGetVBehaviorFactory.MakeISarPrintTypeGetV(param, entity);
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
