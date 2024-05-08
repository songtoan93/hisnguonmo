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

namespace ACS.MANAGER.Core.AcsAppOtpType.Create
{
    class AcsAppOtpTypeCreateBehaviorEv : BeanObjectBase, IAcsAppOtpTypeCreate
    {
        ACS_APP_OTP_TYPE entity;

        internal AcsAppOtpTypeCreateBehaviorEv(CommonParam param, ACS_APP_OTP_TYPE data)
            : base(param)
        {
            entity = data;
        }

        bool IAcsAppOtpTypeCreate.Run()
        {
            bool result = false;
            try
            {
                result = Check() && DAOWorker.AcsAppOtpTypeDAO.Create(entity);
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
                result = result && AcsAppOtpTypeCheckVerifyValidData.Verify(param, entity);
                //result = result && AcsAppOtpTypeCheckVerifyExistsCode.Verify(param, entity.ACTIVITY_TYPE_CODE, null);
            }
            catch (Exception ex)
            {
                param.HasException = true;
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
            }
            return result;
        }
    }
}
