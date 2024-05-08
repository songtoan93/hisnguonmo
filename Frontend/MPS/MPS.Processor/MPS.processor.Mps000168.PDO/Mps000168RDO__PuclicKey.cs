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

namespace MPS.Processor.Mps000168.PDO
{
    public partial class Mps000168PDO : RDOBase
    {
        public V_HIS_EXP_MEST_1 _expMest = null;
        public List<V_HIS_EXP_MEST_MEDICINE> _Medicines = null;
        public List<V_HIS_EXP_MEST_MATERIAL> _Materials = null;
        public List<V_HIS_EXP_MEST_USER> _ExpMestUserPrint = null;
        public List<RoleADO> roleAdo = new List<RoleADO>();

        public long expMesttSttId__Draft = 1;// trạng thái nháp
        public long expMesttSttId__Request = 2;// trạng thái yêu cầu
        public long expMesttSttId__Reject = 3;// không duyệt
        public long expMesttSttId__Approval = 4; // duyệt
        public long expMesttSttId__Export = 5;// đã xuất

        public List<Mps000168ADO> listAdo = new List<Mps000168ADO>();

    }

    public class RoleADO
    {
        public string Role1 { get; set; }
        public string Role2 { get; set; }
        public string Role3 { get; set; }
        public string Role4 { get; set; }
        public string Role5 { get; set; }
        public string Role6 { get; set; }
        public string Role7 { get; set; }
        public string Role8 { get; set; }
        public string Role9 { get; set; }
        public string Role10 { get; set; }
        public string User1 { get; set; }
        public string User2 { get; set; }
        public string User3 { get; set; }
        public string User4 { get; set; }
        public string User5 { get; set; }
        public string User6 { get; set; }
        public string User7 { get; set; }
        public string User8 { get; set; }
        public string User9 { get; set; }
        public string User10 { get; set; }
    }

    public class Mps000168ADO
    {
        public long TYPE_ID { get; set; }
        public long MEDI_MATE_TYPE_ID { get; set; }

        public string MEDI_MATE_TYPE_CODE { get; set; }
        public string MEDI_MATE_TYPE_NAME { get; set; }
        public string SERVICE_UNIT_CODE { get; set; }
        public string SERVICE_UNIT_NAME { get; set; }
        public string PACKAGE_NUMBER { get; set; }
        public string BID_NUMBER { get; set; }
        public string BID_NAME { get; set; }
        public string EXPIRED_DATE_STR { get; set; }
        public string REGISTER_NUMBER { get; set; }
        public string SUPPLIER_CODE { get; set; }
        public string SUPPLIER_NAME { get; set; }
        public decimal AMOUNT { get; set; }
        public string NATIONAL_NAME { get; set; }
        public string MANUFACTURER_NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public decimal? DISCOUNT { get; set; }
        public string EXP_MEST_CODE { get; set; }
        public string EXP_TIME_STR { get; set; }
        public string IMP_TIME_STR { get; set; }
        public decimal IMP_PRICE { get; set; }
        public decimal IMP_VAT_RATIO { get; set; }
        public decimal? PRICE { get; set; }
        public decimal? VAT_RATIO { get; set; }

        public long? NUM_ORDER { get; set; }

        public Mps000168ADO()
        {
        }

        public Mps000168ADO(List<V_HIS_EXP_MEST_MEDICINE> listMedicine)
        {
            try
            {
                if (listMedicine != null && listMedicine.Count > 0)
                {
                    this.TYPE_ID = 1;
                    this.MEDI_MATE_TYPE_CODE = listMedicine.First().MEDICINE_TYPE_CODE;
                    this.MEDI_MATE_TYPE_ID = listMedicine.First().MEDICINE_TYPE_ID;
                    this.MEDI_MATE_TYPE_NAME = listMedicine.First().MEDICINE_TYPE_NAME;
                    this.PACKAGE_NUMBER = listMedicine.First().PACKAGE_NUMBER;
                    this.REGISTER_NUMBER = listMedicine.First().REGISTER_NUMBER;
                    this.SERVICE_UNIT_CODE = listMedicine.First().SERVICE_UNIT_CODE;
                    this.SERVICE_UNIT_NAME = listMedicine.First().SERVICE_UNIT_NAME;
                    this.SUPPLIER_CODE = listMedicine.First().SUPPLIER_CODE;
                    this.SUPPLIER_NAME = listMedicine.First().SUPPLIER_NAME;
                    this.BID_NAME = listMedicine.First().BID_NAME;
                    this.MANUFACTURER_NAME = listMedicine.First().MANUFACTURER_NAME;
                    this.BID_NUMBER = listMedicine.First().BID_NUMBER;
                    this.NATIONAL_NAME = listMedicine.First().NATIONAL_NAME;
                    this.EXPIRED_DATE_STR = Inventec.Common.DateTime.Convert.TimeNumberToDateString(listMedicine.First().EXPIRED_DATE ?? 0);
                    this.EXP_TIME_STR = Inventec.Common.DateTime.Convert.TimeNumberToDateString(listMedicine.First().EXP_TIME ?? 0);
                    this.IMP_TIME_STR = Inventec.Common.DateTime.Convert.TimeNumberToDateString(listMedicine.First().IMP_TIME ?? 0);
                    this.AMOUNT = listMedicine.Sum(s => s.AMOUNT);
                    this.NUM_ORDER = listMedicine.First().NUM_ORDER;
                    this.DESCRIPTION = listMedicine.First().DESCRIPTION;
                    this.DISCOUNT = listMedicine.First().DISCOUNT;
                    this.EXP_MEST_CODE = listMedicine.First().EXP_MEST_CODE;
                    this.IMP_PRICE = listMedicine.First().IMP_PRICE;
                    this.IMP_VAT_RATIO = listMedicine.First().IMP_VAT_RATIO;
                    this.PRICE = listMedicine.First().PRICE;
                    this.VAT_RATIO = listMedicine.First().VAT_RATIO;
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        public Mps000168ADO(List<V_HIS_EXP_MEST_MATERIAL> listMaterial)
        {
            try
            {
                if (listMaterial != null && listMaterial.Count > 0)
                {
                    this.TYPE_ID = 2;
                    this.MEDI_MATE_TYPE_CODE = listMaterial.First().MATERIAL_TYPE_CODE;
                    this.MEDI_MATE_TYPE_ID = listMaterial.First().MATERIAL_TYPE_ID;
                    this.MEDI_MATE_TYPE_NAME = listMaterial.First().MATERIAL_TYPE_NAME;
                    this.PACKAGE_NUMBER = listMaterial.First().PACKAGE_NUMBER;
                    this.SERVICE_UNIT_CODE = listMaterial.First().SERVICE_UNIT_CODE;
                    this.SERVICE_UNIT_NAME = listMaterial.First().SERVICE_UNIT_NAME;
                    this.SUPPLIER_CODE = listMaterial.First().SUPPLIER_CODE;
                    this.SUPPLIER_NAME = listMaterial.First().SUPPLIER_NAME;
                    this.MANUFACTURER_NAME = listMaterial.First().MANUFACTURER_NAME;
                    this.BID_NAME = listMaterial.First().BID_NAME;
                    this.BID_NUMBER = listMaterial.First().BID_NUMBER;
                    this.NATIONAL_NAME = listMaterial.First().NATIONAL_NAME;
                    this.EXPIRED_DATE_STR = Inventec.Common.DateTime.Convert.TimeNumberToDateString(listMaterial.First().EXPIRED_DATE ?? 0);
                    this.EXP_TIME_STR = Inventec.Common.DateTime.Convert.TimeNumberToDateString(listMaterial.First().EXP_TIME ?? 0);
                    this.AMOUNT = listMaterial.Sum(s => s.AMOUNT);
                    this.NUM_ORDER = listMaterial.First().NUM_ORDER;
                    this.DESCRIPTION = listMaterial.First().DESCRIPTION;
                    this.DISCOUNT = listMaterial.First().DISCOUNT;
                    this.EXP_MEST_CODE = listMaterial.First().EXP_MEST_CODE;
                    this.IMP_PRICE = listMaterial.First().IMP_PRICE;
                    this.IMP_VAT_RATIO = listMaterial.First().IMP_VAT_RATIO;
                    this.PRICE = listMaterial.First().PRICE;
                    this.VAT_RATIO = listMaterial.First().VAT_RATIO;
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }
    }
}
