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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventec.Desktop.Core;
using HIS.Desktop.Common;
using Inventec.Core;
using Inventec.Desktop.Common.Modules;

namespace EMR.Desktop.Plugins.EmrConfig.EmrConfig
{
    class EmrConfigBehavior : BusinessBase, IEmrConfig
    {
        object[] Entity;
        internal EmrConfigBehavior(CommonParam param, object[] filter)
            : base()
        {
            this.Entity = filter;
        }
        object IEmrConfig.Run()
        {
            try
            {
                Inventec.Desktop.Common.Modules.Module module = null;
                string WorkingModuleLink = "";
                if (this.Entity.GetType() == typeof(object[]))
                {
                    foreach (var item in this.Entity)
                    {
                        if (item is Module)
                        {
                            module = (Module)item;
                        }
                        else if (item is string)
                        {
                            WorkingModuleLink = (string)item;
                        }
                    }
                }

                if (module != null && !string.IsNullOrEmpty(WorkingModuleLink))
                {
                    return new EMR.Desktop.Plugins.EmrConfig.EmrConfig.frmEmrConfig(module, WorkingModuleLink);
                }
                else
                    return new EMR.Desktop.Plugins.EmrConfig.EmrConfig.frmEmrConfig(module);
            }
            catch (Exception ex)
            {

                Inventec.Common.Logging.LogSystem.Warn(ex);
                param.HasException = true;
                return null;
            }
        }
    }
}