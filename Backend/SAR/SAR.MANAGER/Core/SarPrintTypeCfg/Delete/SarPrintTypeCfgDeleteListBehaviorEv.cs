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
using Inventec.Core;
using SAR.EFMODEL.DataModels;
using SAR.MANAGER.Base;
using SAR.MANAGER.Core.Check;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAR.MANAGER.Core.SarPrintTypeCfg.Delete
{
    class SarPrintTypeCfgDeleteListBehaviorEv : BeanObjectBase, ISarPrintTypeCfgDelete
    {
        List<SAR_PRINT_TYPE_CFG> entity;

        internal SarPrintTypeCfgDeleteListBehaviorEv(CommonParam param, List<SAR_PRINT_TYPE_CFG> data)
            : base(param)
        {
            entity = data;
        }

        bool ISarPrintTypeCfgDelete.Run()
        {
            bool result = false;
            try
            {
                result = Check() && DAOWorker.SarPrintTypeCfgDAO.TruncateList(entity);
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
                foreach (var item in entity)
                {
                    result = result && SarPrintTypeCfgCheckVerifyIsUnlock.Verify(param, item.ID);
                }
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