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
using Inventec.Desktop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventec.Desktop.Common.Core;

namespace ACS.Desktop.Plugins.AcsRole
{
    class AcsRoleBehavior : BusinessBase, IAcsRole
    {
        object[] entity;
        internal AcsRoleBehavior(CommonParam param, object[] filter)
            : base()
        {
            this.entity = filter;
        }

        object IAcsRole.Run()
        {
            object result = null;
            try
            {
                Inventec.Desktop.Common.Modules.Module moduleData = null;

                List<Inventec.Common.WebApiClient.ApiConsumer> listApiConsumer = null;
                List<long> listLong = null;
                List<string> listString = null;
                List<Action> listAction = null;
                List<Action<Type>> listActionType = null;
                List<object> listObj = null;
                List<Action<List<object>, Inventec.Desktop.Common.Modules.Module, Inventec.Desktop.Common.Modules.Module>> listActionCallModule = null;

                if (entity != null && entity.Count() > 0)
                {
                    for (int i = 0; i < entity.Count(); i++)
                    {
                        if (entity[i] is Inventec.Desktop.Common.Modules.Module)
                        {
                            moduleData = (Inventec.Desktop.Common.Modules.Module)entity[i];
                        }
                        if (entity[i] is List<Inventec.Common.WebApiClient.ApiConsumer>)
                        {
                            listApiConsumer = (List<Inventec.Common.WebApiClient.ApiConsumer>)entity[i];
                        }
                        if (entity[i] is List<long>)
                        {
                            listLong = (List<long>)entity[i];
                        }
                        if (entity[i] is List<Action>)
                        {
                            listAction = (List<Action>)entity[i];
                        }
                        if (entity[i] is List<string>)
                        {
                            listString = (List<string>)entity[i];
                        }
                        if (entity[i] is List<object>)
                        {
                            listObj = (List<object>)entity[i];
                        }
                        if (entity[i] is List<Action<Type>>)
                        {
                            listActionType = (List<Action<Type>>)entity[i];
                        }
                        if (entity[i] is List<Action<List<object>, Inventec.Desktop.Common.Modules.Module, Inventec.Desktop.Common.Modules.Module>>)
                        {
                            listActionCallModule = (List<Action<List<object>, Inventec.Desktop.Common.Modules.Module, Inventec.Desktop.Common.Modules.Module>>)entity[i];
                        }
                    }
                }
                result = new frmAcsRole(moduleData, listApiConsumer[0], listApiConsumer[1], listActionType[0], listLong[0], listString[0], listString[1], (List<Inventec.Desktop.Common.Modules.Module>)listObj[0], listActionCallModule[0]);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
                return null;
            }
            return result;
        }
    }
}
