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

namespace SAR.Desktop.Plugins.SarPrintType
{
    class HisRequestUriStore
    {
        internal const string SARSAR_PRINT_TYPE_CREATE = "api/SarPrintType/Create";
        internal const string SARSAR_PRINT_TYPE_DELETE = "api/SarPrintType/Delete";
        internal const string SARSAR_PRINT_TYPE_UPDATE = "api/SarPrintType/Update";
        internal const string SARSAR_PRINT_TYPE_GET = "api/SarPrintType/Get";
        internal const string SARSAR_PRINT_TYPE_CHANGE_LOCK = "api/SarPrintType/ChangeLock";
    }
}
