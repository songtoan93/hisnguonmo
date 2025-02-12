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
using SAR.DAO.Base;
using SAR.EFMODEL.DataModels;
using Inventec.Core;
using System.Collections.Generic;

namespace SAR.DAO.SarPrintLog
{
    partial class SarPrintLogCreate : EntityBase
    {
        public SarPrintLogCreate()
            : base()
        {
            bridgeDAO = new BridgeDAO<SAR_PRINT_LOG>();
        }

        private BridgeDAO<SAR_PRINT_LOG> bridgeDAO;

        public bool Create(SAR_PRINT_LOG data)
        {
            return IsNotNull(data) && bridgeDAO.Create(data);
        }

        public bool CreateList(List<SAR_PRINT_LOG> listData)
        {
            return IsNotNull(listData) && bridgeDAO.CreateList(listData);
        }
    }
}
