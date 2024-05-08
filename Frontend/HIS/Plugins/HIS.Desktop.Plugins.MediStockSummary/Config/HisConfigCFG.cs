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
using HIS.Desktop.LocalStorage.HisConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.Desktop.Plugins.MediStockSummary.Config
{
    class HisConfigCFG
    {
        private const string CONFIG_KEY__IS_USE_BASE_AMOUNT_CABINET = "MOS.HIS_MEDI_STOCK.CABINET.IS_USE_BASE_AMOUNT";

        internal static string IS_USE_BASE_AMOUNT;

        internal static void LoadConfig()
        {
            try
            {
                IS_USE_BASE_AMOUNT = HisConfigs.Get<string>(CONFIG_KEY__IS_USE_BASE_AMOUNT_CABINET);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }
    }
}
