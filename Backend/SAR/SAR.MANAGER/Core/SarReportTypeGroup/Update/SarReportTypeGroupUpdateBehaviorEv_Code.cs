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
using SAR.MANAGER.Base;
using SAR.MANAGER.Core.Check;
using Inventec.Core;
using System;

namespace SAR.MANAGER.Core.SarReportTypeGroup.Update
{
    class SarReportTypeGroupUpdateBehaviorEv : BeanObjectBase, ISarReportTypeGroupUpdate
    {
        SAR_REPORT_TYPE_GROUP current;
        SAR_REPORT_TYPE_GROUP entity;

        internal SarReportTypeGroupUpdateBehaviorEv(CommonParam param, SAR_REPORT_TYPE_GROUP data)
            : base(param)
        {
            entity = data;
        }

        bool ISarReportTypeGroupUpdate.Run()
        {
            bool result = false;
            try
            {
                result = Check() && DAOWorker.SarReportTypeGroupDAO.Update(entity);
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
                result = result && SarReportTypeGroupCheckVerifyValidData.Verify(param, entity);
                result = result && SarReportTypeGroupCheckVerifyIsUnlock.Verify(param, entity.ID, ref current);
                result = result && SarReportTypeGroupCheckVerifyExistsCode.Verify(param, entity.REPORT_TYPE_GROUP_CODE, entity.ID);
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
