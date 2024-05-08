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
using MPS.ProcessorBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.Processor.Mps000212
{
    class Mps000212ExtendSingleKey : CommonKey
    {
        internal static string DOCUMENT_DATE_STR = "DOCUMENT_DATE_STR";
        internal static string TOTAL_PRICE_TEXT = "TOTAL_PRICE_TEXT";
        internal static string TOTAL_PRICE_AFTER_DISCOUNT = "TOTAL_PRICE_AFTER_DISCOUNT";
        internal static string TOTAL_PRICE_AFTER_DISCOUNT_TEXT = "TOTAL_PRICE_AFTER_DISCOUNT_TEXT";
        internal static string TITLE_BY_IMP_MEST_TYPE = "TITLE_BY_IMP_MEST_TYPE";
    }
}