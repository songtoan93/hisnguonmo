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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.Desktop.Plugins.HisEmrCoverConfig
{
    class HisRequestUriStore
    {
        internal const string HIS_EMR_COVER_CONFIG_UPDATE = "/api/HisEmrCoverConfig/Update";
        internal const string HIS_EMR_COVER_CONFIG_GET = "/api/HisEmrCoverConfig/Get";
        internal const string HIS_EMR_COVER_CONFIG_GETVIEW = "/api/HisEmrCoverConfig/GetView";
        internal const string HIS_EMR_COVER_CONFIG_CREATE = "api/HisEmrCoverConfig/Create";
        internal const string HIS_EMR_COVER_CONFIG_DELETE = "api/HisEmrCoverConfig/Delete";
        internal const string HIS_EMR_COVER_CONFIG_CHANGELOCK = "api/HisEmrCoverConfig/ChangeLock";
    }
}
