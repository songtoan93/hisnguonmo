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
using ACS.MANAGER.Core.AcsRole.Get.Ev;
using ACS.MANAGER.Core.AcsRole.Get.ListEv;
using ACS.MANAGER.Core.AcsRole.Get.ListV;
using ACS.MANAGER.Core.AcsRole.Get.V;
using Inventec.Core;
using System;
using System.Collections.Generic;

namespace ACS.MANAGER.Core.AcsRole
{
    partial class AcsRoleGet : BeanObjectBase, IDelegacyT
    {
        object entity;

        internal AcsRoleGet(CommonParam param, object data)
            : base(param)
        {
            entity = data;
        }

        T IDelegacyT.Execute<T>()
        {
            T result = default(T);
            try
            {
                if (typeof(T) == typeof(List<ACS_ROLE>))
                {
                    IAcsRoleGetListEv behavior = AcsRoleGetListEvBehaviorFactory.MakeIAcsRoleGetListEv(param, entity);
                    result = behavior != null ? (T)System.Convert.ChangeType(behavior.Run(), typeof(T)) : default(T);
                }
                else if (typeof(T) == typeof(ACS_ROLE))
                {
                    IAcsRoleGetEv behavior = AcsRoleGetEvBehaviorFactory.MakeIAcsRoleGetEv(param, entity);
                    result = behavior != null ? (T)System.Convert.ChangeType(behavior.Run(), typeof(T)) : default(T);
                }
                else if (typeof(T) == typeof(List<V_ACS_ROLE>))
                {
                    IAcsRoleGetListV behavior = AcsRoleGetListVBehaviorFactory.MakeIAcsRoleGetListV(param, entity);
                    result = behavior != null ? (T)System.Convert.ChangeType(behavior.Run(), typeof(T)) : default(T);
                }
                else if (typeof(T) == typeof(V_ACS_ROLE))
                {
                    IAcsRoleGetV behavior = AcsRoleGetVBehaviorFactory.MakeIAcsRoleGetV(param, entity);
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
