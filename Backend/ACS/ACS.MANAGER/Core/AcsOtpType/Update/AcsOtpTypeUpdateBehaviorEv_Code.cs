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
using Inventec.Core;
using System;

namespace ACS.MANAGER.Core.AcsOtpType.Update
{
    class AcsOtpTypeUpdateBehaviorEv : BeanObjectBase, IAcsOtpTypeUpdate
    {
        ACS_OTP_TYPE current;
        ACS_OTP_TYPE entity;

        internal AcsOtpTypeUpdateBehaviorEv(CommonParam param, ACS_OTP_TYPE data)
            : base(param)
        {
            entity = data;
        }

        bool IAcsOtpTypeUpdate.Run()
        {
            bool result = false;
            try
            {
                result = Check() && DAOWorker.AcsOtpTypeDAO.Update(entity);
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
                result = result && AcsOtpTypeCheckVerifyValidData.Verify(param, entity);
                result = result && AcsOtpTypeCheckVerifyIsUnlock.Verify(param, entity.ID, ref current);
                result = result && AcsOtpTypeCheckVerifyExistsCode.Verify(param, entity.OPT_TYPE_CODE, entity.ID);
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
