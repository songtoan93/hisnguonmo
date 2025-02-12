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
using SDA.MANAGER.Base;
using SDA.MANAGER.Core.Check;
using Inventec.Core;
using System;
using System.Collections.Generic;

namespace SDA.MANAGER.Core.SdaEventLog.Create
{
    class SdaEventLogCreateListBehaviorSDO : BeanObjectBase, ISdaEventLogCreate
    {
        List<SDA.SDO.SdaEventLogSDO> entitys;
        internal SdaEventLogCreateListBehaviorSDO(CommonParam param, List<SDA.SDO.SdaEventLogSDO> datas)
            : base(param)
        {
            entitys = datas;
        }

        bool ISdaEventLogCreate.Run()
        {
            bool result = false;
            try
            {
                if (entitys == null || entitys.Count == 0)
                    throw new ArgumentNullException("List SdaEventLogSDO is null");
                //Inventec.Common.Logging.LogSystem.Info("List SdaEventLogSDO Count:" + entitys.Count);
                foreach (var item in entitys)
                {
                    SDA_EVENT_LOG raw = new SDA_EVENT_LOG();
                    if (Inventec.Common.String.CountVi.Count(item.Description) > 4000)
                    {
                        raw.DESCRIPTION = Inventec.Common.String.CountVi.SubStringVi(item.Description, 4000 - 4) + "...";
                    }
                    else
                    {
                        raw.DESCRIPTION = item.Description;
                    }
                    if (String.IsNullOrEmpty(item.LogginName))
                    {
                        raw.LOGIN_NAME = Inventec.Token.ResourceSystem.ResourceTokenManager.GetLoginName();
                        raw.CREATOR = Inventec.Token.ResourceSystem.ResourceTokenManager.GetLoginName();
                    }
                    else
                    {
                        raw.CREATOR = item.LogginName;
                        raw.LOGIN_NAME = item.LogginName;
                    }
                    raw.APP_CODE = item.AppCode;
                    raw.EVENT_TIME = item.EventTime;
                    raw.MODIFIER = raw.CREATOR;
                    raw.IP = item.Ip;

                    if (Check(raw))
                    {
                        bool success = DAOWorker.SdaEventLogDAO.Create(raw);
                        if (!success)
                        {
                            Inventec.Common.Logging.LogSystem.Error("Tao eventlog that bai. " + Inventec.Common.Logging.LogUtil.TraceData(Inventec.Common.Logging.LogUtil.GetMemberName(() => raw), raw));
                        }
                    }
                }

                result = true;
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
                result = false;
            }
            return result;
        }

        bool Check(SDA_EVENT_LOG raw)
        {
            bool result = true;
            try
            {
                result = result && SdaEventLogCheckVerifyValidData.Verify(param, raw);
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
