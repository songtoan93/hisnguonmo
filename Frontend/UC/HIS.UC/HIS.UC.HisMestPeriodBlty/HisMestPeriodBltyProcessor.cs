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
using HIS.UC.HisMestPeriodBlty.GetListCheck;
using HIS.UC.HisMestPeriodBlty.Reload;
using HIS.UC.HisMestPeriodBlty.Run;
using HIS.UC.HisMestPeriodBlty.Search;
using HIS.UC.HisMestPeriodBlty.ADO;
using Inventec.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HIS.UC.HisMestPeriodBlty
{
    public class HisMestPeriodBltyProcessor : BussinessBase
    {
        object uc;
        public HisMestPeriodBltyProcessor()
            : base()
        {
        }

        public HisMestPeriodBltyProcessor(CommonParam paramBusiness)
            : base(paramBusiness)
        {
        }

        public object Run(HisMestPeriodBltyInitADO arg)
        {
            uc = null;
            try
            {
                IRun behavior = RunFactory.MakeIHisMestPeriodBlty(param, arg);
                uc = behavior != null ? (behavior.Run()) : null;
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                uc = null;
            }
            return uc;
        }

        public void Search(UserControl control)
        {
            try
            {
                ISearch behavior = SearchFactory.MakeISearch(param, (control == null ? (UserControl)uc : control));
                if (behavior != null) behavior.Run();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        public void Reload(UserControl control, List<MOS.EFMODEL.DataModels.V_HIS_MEST_PERIOD_BLTY> HisMestPeriodBltys)
        {
            try
            {
                IReload behavior = ReloadFactory.MakeIReload(param, (control == null ? (UserControl)uc : control), HisMestPeriodBltys);
                if (behavior != null) behavior.Run();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        public List<HisMestPeriodBltyADO> GetListCheck(UserControl control)
        {
            List<HisMestPeriodBltyADO> result = null;
            try
            {
                IGetListCheck behavior = GetListCheckFactory.MakeIGetListCheck(control);
                result = (behavior != null) ? behavior.Run() : null;
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = null;
            }
            return result;
        }
    }
}
