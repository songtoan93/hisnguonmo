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
using AutoMapper;
using DevExpress.XtraEditors;
using HIS.UC.ServiceRoomInfo.Delegate;
using HIS.UC.ServiceRoomInfo.Generate;
using Inventec.Core;
using MOS.EFMODEL.DataModels;
using MOS.SDO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HIS.UC.ServiceRoomInfo.SetValue
{
    class ServiceRoomInfoSetValueBehavior : IServiceRoomInfoSetValue
    {
        object uc;
        V_HIS_PATIENT exam;
        internal ServiceRoomInfoSetValueBehavior(CommonParam param, object uc, V_HIS_PATIENT exam)
        {
            try
            {
                this.exam = exam;
                this.uc = uc;
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        void IServiceRoomInfoSetValue.Run()
        {
            try
            {
                if (uc is HIS.UC.ServiceRoomInfo.Run.UCServiceRoomInfo)
                {
                    ((HIS.UC.ServiceRoomInfo.Run.UCServiceRoomInfo)uc).SetValue(this.exam);
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }
    }
}
