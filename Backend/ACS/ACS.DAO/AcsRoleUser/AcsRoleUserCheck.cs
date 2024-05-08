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
using System;
using System.Linq;

namespace ACS.DAO.AcsRoleUser
{
    partial class AcsRoleUserCheck : EntityBase
    {
        public AcsRoleUserCheck()
            : base()
        {
            bridgeDAO = new BridgeDAO<ACS_ROLE_USER>();
        }

        private BridgeDAO<ACS_ROLE_USER> bridgeDAO;

        public bool IsUnLock(long id)
        {
            return bridgeDAO.IsUnLock(id);
        }
    }
}
