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
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace HIS.Desktop.Plugins.TreatmentFundList.Base
{
    class ResourceLangManager
    {
        internal static ResourceManager LanguageFrmTreatmentList { get; set; }
        internal static ResourceManager LanguageFrmCancelTreatment { get; set; }

        internal static void InitResourceLanguageManager()
        {
            try
            {
                LanguageFrmTreatmentList = new ResourceManager("HIS.Desktop.Plugins.TreatmentFundList.Resources.Lang", typeof(HIS.Desktop.Plugins.TreatmentFundList.frmTreatmentList).Assembly);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
            try
            {
                //LanguageFrmCancelTreatment = new ResourceManager("HIS.Desktop.Plugins.TreatmentFundList.Resources.Lang", typeof(HIS.Desktop.Plugins.TreatmentFundList.frmCancelTreatment).Assembly);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }
    }
}
