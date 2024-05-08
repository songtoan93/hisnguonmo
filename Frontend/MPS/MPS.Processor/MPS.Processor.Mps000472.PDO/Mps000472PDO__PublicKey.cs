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
using MOS.EFMODEL.DataModels;
using MPS.ProcessorBase;
using MPS.ProcessorBase.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.Processor.Mps000472.PDO
{
    public partial class Mps000472PDO : RDOBase
    {
        public V_HIS_TREATMENT Treatment { get; set; }
        public List<HIS_MR_CHECK_SUMMARY> ListMRCheckSummary { get; set; }
        public List<HIS_MR_CHECKLIST> ListMRChecklist { get; set; }
        public List<HIS_MR_CHECK_ITEM> ListMRCheckItem { get; set; }
        public List<HIS_MR_CHECK_ITEM_TYPE> ListMRCheckItemType { get; set; }
    }

    public class MRCheckSummaryADO : HIS_MR_CHECK_SUMMARY
    {
        public string PhanLoaiBenhAn { get; set; }
        public long Stt { get; set; }
    }
    
}