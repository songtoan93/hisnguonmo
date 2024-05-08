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
using ACS.DAO.Base;
using ACS.EFMODEL.DataModels;
using Inventec.Core;
using System.Collections.Generic;

namespace ACS.DAO.AcsUser
{
    partial class AcsUserCreate : EntityBase
    {
        public AcsUserCreate()
            : base()
        {
            bridgeDAO = new BridgeDAO<ACS_USER>();
        }

        private BridgeDAO<ACS_USER> bridgeDAO;

        public bool Create(ACS_USER data)
        {
            return IsNotNull(data) && bridgeDAO.Create(data);
        }

        public bool CreateList(List<ACS_USER> listData)
        {
            return IsNotNull(listData) && bridgeDAO.CreateList(listData);
        }
    }
}
