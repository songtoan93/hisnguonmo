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
using ACS.MANAGER.Base;
using ACS.MANAGER.Core.Check;
using ACS.MANAGER.Core.AcsModuleGroup.EventLog;
using Inventec.Core;
using System;

namespace ACS.MANAGER.Core.AcsModuleGroup.Update
{
    class AcsModuleGroupUpdateBehaviorEv : BeanObjectBase, IAcsModuleGroupUpdate
    {
        ACS_MODULE_GROUP current;
        ACS_MODULE_GROUP entity;

        internal AcsModuleGroupUpdateBehaviorEv(CommonParam param, ACS_MODULE_GROUP data)
            : base(param)
        {
            entity = data;
        }

        bool IAcsModuleGroupUpdate.Run()
        {
            bool result = false;
            try
            {
                result = Check() && DAOWorker.AcsModuleGroupDAO.Update(entity);
                if (result) { AcsModuleGroupEventLogUpdate.Log(current, entity); }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
                result = false;
            }
            return result;
        }

        bool Check()
        {
            bool result = true;
            try
            {
                result = result && AcsModuleGroupCheckVerifyValidData.Verify(param, entity);
                result = result && AcsModuleGroupCheckVerifyIsUnlock.Verify(param, entity.ID, ref current);
                result = result && AcsModuleGroupCheckVerifyExistsCode.Verify(param, entity.MODULE_GROUP_CODE, entity.ID);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
                result = false;
            }
            return result;
        }
    }
}
