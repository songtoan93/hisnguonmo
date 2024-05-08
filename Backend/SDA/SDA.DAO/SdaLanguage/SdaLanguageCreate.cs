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
using Inventec.Core;
using System.Collections.Generic;

namespace SDA.DAO.SdaLanguage
{
    partial class SdaLanguageCreate : EntityBase
    {
        public SdaLanguageCreate()
            : base()
        {
            bridgeDAO = new BridgeDAO<SDA_LANGUAGE>();
        }

        private BridgeDAO<SDA_LANGUAGE> bridgeDAO;

        public bool Create(SDA_LANGUAGE data)
        {
            return IsNotNull(data) && bridgeDAO.Create(data);
        }

        public bool CreateList(List<SDA_LANGUAGE> listData)
        {
            return IsNotNull(listData) && bridgeDAO.CreateList(listData);
        }
    }
}