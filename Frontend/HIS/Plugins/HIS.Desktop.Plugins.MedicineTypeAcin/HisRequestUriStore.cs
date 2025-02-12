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

namespace HIS.Desktop.Plugins.MedicineTypeAcin
{
    class HisRequestUriStore
    {
        internal const string HIS_MEDICINE_TYPE_GET = "api/HisMedicineType/Get";
        internal const string HIS_MEDICINE_TYPE_GETVIEW = "api/HisMedicineType/GetView";
        internal const string HIS_MEDICINE_TYPE_ACIN_GET = "api/HisMedicineTypeAcin/Get";
        internal const string HIS_IMP_MEST_TYPE_GET = "api/HisImpMestType/Get";
        internal const string HIS_ACTIVE_GREDIENT_GET = "api/HisActiveIngredient/Get";
        internal const string HIS_MEDICINE_TYPE_ACIN_DELETE_LIST = "api/HisMedicineTypeAcin/DeleteList";
        internal const string HIS_MEDICINE_TYPE_ACIN_CREATE_LIST = "api/HisMedicineTypeAcin/CreateList";
        internal const string HIS_MEDICINE_TYPE_ACIN_GETVIEW = "api/HisMedicineTypeAcin/GetView";
    }
}
