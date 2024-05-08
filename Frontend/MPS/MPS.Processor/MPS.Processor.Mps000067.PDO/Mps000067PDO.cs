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
using MPS.ProcessorBase.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.Processor.Mps000067.PDO
{
	public partial class Mps000067PDO : RDOBase
	{
		public Mps000067PDO(
            PatientADO patient,
            MOS.EFMODEL.DataModels.V_HIS_EXP_MEST_MEDICINE expMestMedicine,
            HisPrescriptionSDO HisPrescriptionSDO
            )
        {
            try
            {
                this.Patient = patient;
                this.expMestMedicine = expMestMedicine;
                this.HisPrescriptionSDO = HisPrescriptionSDO;
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }
	}
}
