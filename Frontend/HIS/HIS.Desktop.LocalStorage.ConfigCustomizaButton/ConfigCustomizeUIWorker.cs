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
using HIS.Desktop.ApiConsumer;
using Inventec.Common.Adapter;
using Inventec.Common.Logging;
using Inventec.Common.XmlConfig;
using Inventec.Core;
using Inventec.Desktop.Common.LanguageManager;
using SDA.Filter;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.Desktop.LocalStorage.ConfigCustomizaButton
{
    public class ConfigCustomizeUIWorker
    {
        static readonly string APPLICATION_CODE = ConfigurationManager.AppSettings["Inventec.Desktop.ApplicationCode"];//Ma ung dung khai bao tren ACS
        static List<SDA.EFMODEL.DataModels.SDA_CUSTOMIZE_UI> ConfigCustomizeUIs;
        static Object thisLock = new Object();

        public static void Init()
        {
            try
            {
                CommonParam param = new CommonParam();
                ConfigCustomizeUIs = SdaCustomizeUIGet.Get();
                if (ConfigCustomizeUIs == null || ConfigCustomizeUIs.Count == 0) throw new ArgumentNullException("ConfigCustomizeUIs");

                ConfigCustomizeUIs = ConfigCustomizeUIs.Where(o => o.APP_CODE == HIS.Desktop.LocalStorage.LocalData.GlobalVariables.APPLICATION_CODE || String.IsNullOrEmpty(o.APP_CODE)).ToList();

                Inventec.Common.Logging.LogSystem.Debug("CustomizeUIWorker.Init. ConfigCustomizeUIs.count =" + (ConfigCustomizeUIs != null && ConfigCustomizeUIs.Count > 0 ? ConfigCustomizeUIs.Count : 0));
            }
            catch (ArgumentNullException ex)
            {
                ConfigCustomizeUIs = null;
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        public static List<SDA.EFMODEL.DataModels.SDA_CUSTOMIZE_UI> GetByModule(string moduleLink)
        {
            List<SDA.EFMODEL.DataModels.SDA_CUSTOMIZE_UI> data = default(List<SDA.EFMODEL.DataModels.SDA_CUSTOMIZE_UI>);
            try
            {
                if (ConfigCustomizeUIs != null && ConfigCustomizeUIs.Count > 0)
                {
                    var cfgButton = ConfigCustomizeUIs.AsQueryable();
                    cfgButton = cfgButton.Where(o => o.MODULE_LINK == moduleLink);
                    return data = cfgButton.ToList();
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }

            return default(List<SDA.EFMODEL.DataModels.SDA_CUSTOMIZE_UI>);
        }

        public static bool ReloadAll()
        {
            bool result = false;
            try
            {
                ConfigCustomizeUIs.Clear();
                Init();
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                Inventec.Common.Logging.LogSystem.Error(ex);
            }

            return result;
        }
    }
}