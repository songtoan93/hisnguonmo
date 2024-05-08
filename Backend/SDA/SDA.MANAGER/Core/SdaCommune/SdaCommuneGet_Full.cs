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
using SDA.EFMODEL.DataModels;
using SDA.MANAGER.Core.SdaCommune.Get.Ev;
using SDA.MANAGER.Core.SdaCommune.Get.ListEv;
using SDA.MANAGER.Core.SdaCommune.Get.ListV;
using SDA.MANAGER.Core.SdaCommune.Get.V;
using Inventec.Core;
using System;
using System.Collections.Generic;

namespace SDA.MANAGER.Core.SdaCommune
{
    partial class SdaCommuneGet : BeanObjectBase, IDelegacyT
    {
        object entity;

        internal SdaCommuneGet(CommonParam param, object data)
            : base(param)
        {
            entity = data;
        }

        T IDelegacyT.Execute<T>()
        {
            T result = default(T);
            try
            {
                if (typeof(T) == typeof(List<SDA_COMMUNE>))
                {
                    ISdaCommuneGetListEv behavior = SdaCommuneGetListEvBehaviorFactory.MakeISdaCommuneGetListEv(param, entity);
                    result = behavior != null ? (T)System.Convert.ChangeType(behavior.Run(), typeof(T)) : default(T);
                }
                else if (typeof(T) == typeof(SDA_COMMUNE))
                {
                    ISdaCommuneGetEv behavior = SdaCommuneGetEvBehaviorFactory.MakeISdaCommuneGetEv(param, entity);
                    result = behavior != null ? (T)System.Convert.ChangeType(behavior.Run(), typeof(T)) : default(T);
                }
                else if (typeof(T) == typeof(List<V_SDA_COMMUNE>))
                {
                    ISdaCommuneGetListV behavior = SdaCommuneGetListVBehaviorFactory.MakeISdaCommuneGetListV(param, entity);
                    result = behavior != null ? (T)System.Convert.ChangeType(behavior.Run(), typeof(T)) : default(T);
                }
                else if (typeof(T) == typeof(V_SDA_COMMUNE))
                {
                    ISdaCommuneGetV behavior = SdaCommuneGetVBehaviorFactory.MakeISdaCommuneGetV(param, entity);
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