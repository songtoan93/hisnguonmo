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
using Inventec.Common.Logging;
using Inventec.Core;
using SDA.EFMODEL.DataModels;
using SDA.MANAGER.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SDA.MANAGER.SdaCustomizeButton
{
    partial class SdaCustomizeButtonUpdate : BusinessBase
    {
		private List<SDA_CUSTOMIZE_BUTTON> beforeUpdateSdaCustomizeButtons = new List<SDA_CUSTOMIZE_BUTTON>();
		
        internal SdaCustomizeButtonUpdate()
            : base()
        {

        }

        internal SdaCustomizeButtonUpdate(CommonParam paramUpdate)
            : base(paramUpdate)
        {

        }

        internal bool Update(SDA_CUSTOMIZE_BUTTON data)
        {
            bool result = false;
            try
            {
                bool valid = true;
                SdaCustomizeButtonCheck checker = new SdaCustomizeButtonCheck(param);
                valid = valid && checker.VerifyRequireField(data);
                SDA_CUSTOMIZE_BUTTON raw = null;
                valid = valid && checker.VerifyId(data.ID, ref raw);
                valid = valid && checker.IsUnLock(raw);
                if (valid)
                {                    
					if (!DAOWorker.SdaCustomizeButtonDAO.Update(data))
                    {
                        SDA.MANAGER.Base.BugUtil.SetBugCode(param, SDA.LibraryBug.Bug.Enum.SdaCustomizeButton_CapNhatThatBai);
                        throw new Exception("Cap nhat thong tin SdaCustomizeButton that bai." + LogUtil.TraceData("data", data));
                    }
					this.beforeUpdateSdaCustomizeButtons.Add(raw);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = false;
            }
            return result;
        }

        internal bool UpdateList(List<SDA_CUSTOMIZE_BUTTON> listData)
        {
            bool result = false;
            try
            {
                bool valid = true;
                valid = IsNotNullOrEmpty(listData);
                SdaCustomizeButtonCheck checker = new SdaCustomizeButtonCheck(param);
                List<SDA_CUSTOMIZE_BUTTON> listRaw = new List<SDA_CUSTOMIZE_BUTTON>();
                List<long> listId = listData.Select(o => o.ID).ToList();
                valid = valid && checker.VerifyIds(listId, listRaw);
                valid = valid && checker.IsUnLock(listRaw);
                foreach (var data in listData)
                {
                    valid = valid && checker.VerifyRequireField(data);
                }
                if (valid)
                {
					if (!DAOWorker.SdaCustomizeButtonDAO.UpdateList(listData))
                    {
                        SDA.MANAGER.Base.BugUtil.SetBugCode(param, SDA.LibraryBug.Bug.Enum.SdaCustomizeButton_CapNhatThatBai);
                        throw new Exception("Cap nhat thong tin SdaCustomizeButton that bai." + LogUtil.TraceData("listData", listData));
                    }
					
					this.beforeUpdateSdaCustomizeButtons.AddRange(listRaw);
                    result = true;
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                param.HasException = true;
                result = false;
            }
            return result;
        }
		
		internal void RollbackData()
        {
            if (IsNotNullOrEmpty(this.beforeUpdateSdaCustomizeButtons))
            {
                if (!DAOWorker.SdaCustomizeButtonDAO.UpdateList(this.beforeUpdateSdaCustomizeButtons))
                {
                    LogSystem.Warn("Rollback du lieu SdaCustomizeButton that bai, can kiem tra lai." + LogUtil.TraceData("SdaCustomizeButtons", this.beforeUpdateSdaCustomizeButtons));
                }
				this.beforeUpdateSdaCustomizeButtons = null;
            }
        }
    }
}
