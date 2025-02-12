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
using SDA.DAO.Base;
using SDA.EFMODEL.DataModels;
using System;
using System.Collections.Generic;

namespace SDA.DAO.StagingObject
{
    public class SdaCustomizaButtonSO : StagingObjectBase
    {
        public SdaCustomizaButtonSO()
        {
        }

        public List<System.Linq.Expressions.Expression<Func<SDA_CUSTOMIZA_BUTTON, bool>>> listSdaCustomizaButtonExpression = new List<System.Linq.Expressions.Expression<Func<SDA_CUSTOMIZA_BUTTON, bool>>>();
        public List<System.Linq.Expressions.Expression<Func<V_SDA_CUSTOMIZA_BUTTON, bool>>> listVSdaCustomizaButtonExpression = new List<System.Linq.Expressions.Expression<Func<V_SDA_CUSTOMIZA_BUTTON, bool>>>();
    }
}
