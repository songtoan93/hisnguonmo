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
using System.Collections.Generic;

namespace SDA.Filter
{
    public class SarReportViewFilter : FilterBase
    {
        public enum ReadModeEnum
        {
            CREATE,
            RECEIVE,
            PUBLIC,
            ALL,
        }
        /// <summary>
        /// Che do doc (vi sao duoc xem)
        /// CREATE - Do minh tao ra
        /// RECEIVE - Do minh nhan duoc
        /// PUBLIC - Do duoc cong cong (khong bao gom 2 loai tren)
        /// NULL - Tong hop cua 3 dieu kien tren
        /// </summary>
        public ReadModeEnum READ_MODE { get; set; }
        public List<long> REPORT_STT_IDs { get; set; }

        public SarReportViewFilter()
            : base()
        {
        }
    }
}
