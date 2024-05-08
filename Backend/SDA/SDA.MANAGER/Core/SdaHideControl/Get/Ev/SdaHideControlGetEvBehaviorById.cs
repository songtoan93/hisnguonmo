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
using Inventec.Core;
using System;

namespace SDA.MANAGER.Core.SdaHideControl.Get.Ev
{
    class SdaHideControlGetEvBehaviorById : BeanObjectBase, ISdaHideControlGetEv
    {
        long id;

        internal SdaHideControlGetEvBehaviorById(CommonParam param, long filter)
            : base(param)
        {
            id = filter;
        }

        SDA_HIDE_CONTROL ISdaHideControlGetEv.Run()
        {
            try
            {
                return DAOWorker.SdaHideControlDAO.GetById(id, new SdaHideControlFilterQuery().Query());
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                param.HasException = true;
                return null;
            }
        }
    }
}