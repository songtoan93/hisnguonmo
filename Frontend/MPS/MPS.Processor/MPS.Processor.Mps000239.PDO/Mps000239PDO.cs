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

namespace MPS.Processor.Mps000239.PDO
{
    public partial class Mps000239PDO : RDOBase
    {
        public List<Mps000239ADO> listAdo = new List<Mps000239ADO>();
        public List<V_HIS_MEDICINE_TYPE> _MedicineTypes { get; set; }
        public List<V_HIS_EXP_MEST_MEDICINE> _ExpMestMedicines { get; set; }
        public List<HIS_EXP_MEST> _ExpMests_Print { get; set; }
        public Mps000239Config ConfigMps239 { get; set; }

        public Mps000239PDO() { }

        public Mps000239PDO(
            List<V_HIS_EXP_MEST_MEDICINE> _expMestMedicines,
            V_HIS_EXP_MEST aggrExpMest,
            List<HIS_EXP_MEST> _expMests_Print,
            HIS_DEPARTMENT department,
            List<long> serviceUnitIds,
            List<long> useFormIds,
            List<long> roomIds,
            List<V_HIS_MEDICINE_TYPE> vHisMedicineTypes,
            Mps000239Config _configMps239
            )
        {
            try
            {
                this._ExpMestMedicines = _expMestMedicines;
                this.AggrExpMest = aggrExpMest;
                this._ExpMests_Print = _expMests_Print;
                this.Department = department;
                this.ServiceUnitIds = serviceUnitIds;
                this.UseFormIds = useFormIds;
                this.RoomIds = roomIds;
                this._MedicineTypes = vHisMedicineTypes;
                this.ConfigMps239 = _configMps239;
                if (ConfigMps239 == null) ConfigMps239 = new Mps000239Config();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }
    }
}