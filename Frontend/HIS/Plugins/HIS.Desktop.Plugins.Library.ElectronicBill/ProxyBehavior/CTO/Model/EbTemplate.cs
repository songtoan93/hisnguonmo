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

namespace HIS.Desktop.Plugins.Library.ElectronicBill.ProxyBehavior.CTO.Model
{
    class EbTemplate
    {
        /// <summary>
        /// Mã loại hóa đơn. ví dụ: 02GTTT0
        /// 02GTTT
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// Là ký hiệu hóa đơn + số hóa đơn vd: AA/16E0000001, tuân theo chuẩn của cục thuế
        /// AB/20E
        /// </summary>
        public string symbol { get; set; }

        /// <summary>
        /// Mã mẫu hóa đơn
        /// 02GTTT0/001
        /// </summary>
        public string id { get; set; }
    }
}
