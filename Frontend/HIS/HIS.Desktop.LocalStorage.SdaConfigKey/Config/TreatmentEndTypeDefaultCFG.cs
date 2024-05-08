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
using Inventec.Common.LocalStorage.SdaConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.Desktop.LocalStorage.SdaConfigKey.Config
{
    public class TreatmentEndTypeDefaultCFG
    {
        private const string TreatmentEndTypeDefault = "HIS.Desktop.Plugins.TreatmentFinish.TreatmentEndTypeDefault";

        private static long treatmentEndTypeDefault;
        public static long TreatmentEndTypeDefaultID
        {
            get
            {
                if (treatmentEndTypeDefault <= 0)
                {
                    treatmentEndTypeDefault = GetID(TreatmentEndTypeDefault);
                }
                return treatmentEndTypeDefault;
            }
            set
            {
                treatmentEndTypeDefault = value;
            }
        }

        private static long GetID(string code)
        {
            long result = 0;
            try
            {
                result = Inventec.Common.TypeConvert.Parse.ToInt64(SdaConfigs.Get<String>(code));
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = 0;
            }
            return result;
        }
    }
}