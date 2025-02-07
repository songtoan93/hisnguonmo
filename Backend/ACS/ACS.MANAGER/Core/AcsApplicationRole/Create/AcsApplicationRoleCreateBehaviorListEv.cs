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
using ACS.LibraryEventLog;
using ACS.MANAGER.Base;
using ACS.MANAGER.Core.AcsApplication;
using ACS.MANAGER.Core.AcsRole;
using ACS.MANAGER.Core.AcsRole.Get;
using ACS.MANAGER.Core.Check;
using ACS.MANAGER.EventLogUtil;
using Inventec.Core;
using SDA.SDO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACS.MANAGER.Core.AcsApplicationRole.Create
{
    class AcsApplicationRoleCreateBehaviorListEv : BeanObjectBase, IAcsApplicationRoleCreate
    {
        List<ACS_APPLICATION_ROLE> entities;
        List<string> roleNames;
        string applicationCode;
        string applicationName;
        internal AcsApplicationRoleCreateBehaviorListEv(CommonParam param, List<ACS_APPLICATION_ROLE> datas)
            : base(param)
        {
            entities = datas;
        }

        bool IAcsApplicationRoleCreate.Run()
        {
            bool result = false;
            try
            {
                result = Check() && DAOWorker.AcsApplicationRoleDAO.CreateList(entities);
                if (result)
                {
                    CreateEventLog();
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

        bool Check()
        {
            bool result = true;
            try
            {
                result = result && AcsApplicationRoleCheckVerifyValidData.Verify(param, entities);
                var app = (new AcsApplicationBO().Get<ACS_APPLICATION>(entities.First().APPLICATION_ID) ?? new ACS_APPLICATION());
                applicationName = app.APPLICATION_NAME;
                applicationCode = app.APPLICATION_CODE;
                roleNames = (new AcsRoleBO().Get<List<ACS_ROLE>>(new AcsRoleFilterQuery() { IDs = entities.Select(o => o.ROLE_ID).ToList() }) ?? new List<ACS_ROLE>()).Select(o => o.ROLE_NAME).ToList();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = false;
            }
            return result;
        }

        void CreateEventLog()
        {
            try
            {
                ApplicationRoleData applicationRoleData = new ApplicationRoleData();
                applicationRoleData.ApplicationCode = applicationCode;
                applicationRoleData.RoleNames = roleNames;

                new EventLogGenerator(EventLog.Enum.AcsApplicationRole_ThemQuyenTruyCap)
                          .ApplicationRoleData(applicationRoleData).Run();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }
    }
}
