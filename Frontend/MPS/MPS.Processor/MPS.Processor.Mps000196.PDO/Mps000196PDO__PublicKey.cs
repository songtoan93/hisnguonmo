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
using MPS.ProcessorBase.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.Processor.Mps000196.PDO
{
    public partial class Mps000196PDO : RDOBase
    {
        public V_HIS_PATIENT patient { get; set; }
        public List<V_HIS_DEPARTMENT_TRAN> departmentTrans { get; set; }
        public List<V_HIS_TREATMENT_FEE> treatmentFees { get; set; }
        public List<HIS_SERE_SERV> sereServs { get; set; }
        public V_HIS_TREATMENT treatment { get; set; }
        public PatientADO patientADO { get; set; }
        public List<SereServADO> sereServADOs { get; set; }
        public List<SereServADO> heinServiceTypes { get; set; }
        public PatientTypeCFG patientType { get; set; }
        public BordereauSingleValue bordereauSingleValue { get; set; }
        public List<V_HIS_EXP_MEST> expMests { get; set; }
        public List<HIS_HEIN_SERVICE_TYPE> HeinServiceTypes { get; set; }
        public List<V_HIS_ROOM> Rooms { get; set; }
        public List<V_HIS_SERVICE> Services { get; set; }
        public HeinServiceTypeCFG heinServiceTypeCfg { get; set; }
    }

    public class SereServADO : HIS_SERE_SERV
    {
        public decimal? PRICE_CO_PAYMENT { get; set; } //dong chi tra
        public string KTC_FEE_GROUP_NAME { get; set; }
        public string EXECUTE_GROUP_NAME { get; set; }
        public string EXECUTE_ROOM_NAME { get; set; }
        public string HEIN_SERVICE_TYPE_NAME { get; set; }
        public long? HEIN_SERVICE_TYPE_NUM_ORDER { get; set; }
        public long SERVICE_TYPE_ID { get; set; }
        public string SERVICE_TYPE_CODE { get; set; }
        public string SERVICE_TYPE_NAME { get; set; }
        public string SERVICE_CODE { get; set; }
        public string SERVICE_NAME { get; set; }
        public string SERVICE_UNIT_CODE { get; set; }
        public string SERVICE_UNIT_NAME { get; set; }
        public long? HEIN_SERVICE_TYPE_ID { get; set; }
        public string EXECUTE_ROOM_CODE { get; set; }
        public string HEIN_SERVICE_BHYT_CODE { get; set; }
        public string HEIN_SERVICE_BHYT_NAME { get; set; }
        public string ACTIVE_INGR_BHYT_CODE { get; set; }
        public string ACTIVE_INGR_BHYT_NAME { get; set; }
        public string CONCENTRA { get; set; }
        public long? NUMBER_OF_FILM { get; set; }


        public decimal? TOTAL_PRICE_HEIN_SERVICE_TYPE { get; set; }
        public decimal? TOTAL_HEIN_PRICE_HEIN_SERVICE_TYPE { get; set; }
        public decimal? TOTAL_PATIENT_PRICE_HEIN_SERVICE_TYPE { get; set; }
        public decimal? TOTAL_PRICE_BHYT_HEIN_SERVICE_TYPE { get; set; }
        public decimal? TOTAL_PATIENT_PRICE_BHYT_HEIN_SERVICE_TYPE { get; set; }
        public decimal? TOTAL_HEIN_PRICE_ONE_AMOUNT { get; set; }
        public decimal? PRICE_POLICY { get; set; }
        public decimal PRICE_BHYT { get; set; }
        public decimal TOTAL_PRICE_BHYT { get; set; }
        public decimal RADIO_SERIVCE { get; set; }
        public decimal? TOTAL_PRICE_KTC_FEE_GROUP { get; set; }
        public decimal? TOTAL_HEIN_PRICE_FEE_GROUP { get; set; }
        public decimal? TOTAL_PATIENT_PRICE_FEE_GROUP { get; set; }
        public decimal? TOTAL_PRICE_EXECUTE_GROUP { get; set; }
        public decimal? TOTAL_HEIN_PRICE_EXECUTE_GROUP { get; set; }
        public decimal? TOTAL_PATIENT_PRICE_EXECUTE_GROUP { get; set; }
        public decimal? TOTAL_PRICE_BHYT_FEE_GROUP { get; set; }
        public decimal? TOTAL_PATIENT_PRICE_BHYT_FEE_GROUP { get; set; }
        public decimal? TOTAL_PRICE_BHYT_EXECUTE_GROUP { get; set; }
        public decimal? TOTAL_PATIENT_PRICE_BHYT_EXECUTE_GROUP { get; set; }
        public decimal PRICE_FEE { get; set; }
        public decimal TOTAL_PRICE_FEE { get; set; }
        public SereServADO()
        {

        }

        public SereServADO(HIS_SERE_SERV data,List<HIS_HEIN_SERVICE_TYPE> heinServiceTypes,List<V_HIS_ROOM> rooms,List<V_HIS_SERVICE> services)
        {
            try
            {
                System.Reflection.PropertyInfo[] pi = Inventec.Common.Repository.Properties.Get<MOS.EFMODEL.DataModels.HIS_SERE_SERV>();
                foreach (var item in pi)
                {
                    item.SetValue(this, (item.GetValue(data)));
                }
                if (this.VIR_TOTAL_HEIN_PRICE.HasValue)
                {
                    this.TOTAL_HEIN_PRICE_ONE_AMOUNT = this.VIR_TOTAL_HEIN_PRICE.Value / this.AMOUNT;
                }

                if (this.HEIN_LIMIT_PRICE != null && this.HEIN_LIMIT_PRICE > 0)
                {
                    this.PRICE_BHYT = (this.HEIN_LIMIT_PRICE ?? 0);
                    this.PRICE_FEE = (this.HEIN_LIMIT_PRICE ?? 0);
                }
                else
                {
                    this.PRICE_BHYT = this.VIR_PRICE_NO_ADD_PRICE ?? 0;
                    this.PRICE_FEE = this.VIR_PRICE_NO_ADD_PRICE ?? 0;
                }

                this.TOTAL_PRICE_BHYT = this.PRICE_BHYT * this.AMOUNT;
                this.TOTAL_PRICE_FEE = this.PRICE_FEE * this.AMOUNT;

                if (heinServiceTypes != null && heinServiceTypes.Count > 0 && services != null && services.Count > 0)
                {
                    V_HIS_SERVICE service = services.FirstOrDefault(o => o.ID == data.SERVICE_ID);
                    if (service != null)
                    {
                        HIS_HEIN_SERVICE_TYPE heinServiceType = heinServiceTypes.FirstOrDefault(o => o.ID == service.HEIN_SERVICE_TYPE_ID);
                        this.SERVICE_TYPE_ID = service.SERVICE_TYPE_ID;
                        this.SERVICE_TYPE_CODE = service.SERVICE_TYPE_CODE;
                        this.SERVICE_TYPE_NAME = service.SERVICE_TYPE_NAME;
                        this.SERVICE_NAME = service.SERVICE_NAME;
                        this.SERVICE_CODE = service.SERVICE_CODE;

                        this.SERVICE_UNIT_CODE = service.SERVICE_UNIT_CODE;
                        this.SERVICE_UNIT_NAME = service.SERVICE_UNIT_NAME;
                        this.ACTIVE_INGR_BHYT_CODE = service.ACTIVE_INGR_BHYT_CODE;
                        this.ACTIVE_INGR_BHYT_NAME = service.ACTIVE_INGR_BHYT_NAME;
                        this.HEIN_SERVICE_BHYT_CODE = service.HEIN_SERVICE_BHYT_CODE;
                        this.HEIN_SERVICE_BHYT_NAME = service.HEIN_SERVICE_BHYT_NAME;
                        this.CONCENTRA = service.CONCENTRA;
                        this.NUMBER_OF_FILM = service.NUMBER_OF_FILM;

                        if (heinServiceType != null)
                        {
                            this.TDL_HEIN_SERVICE_TYPE_ID = heinServiceType.ID;
                            this.HEIN_SERVICE_TYPE_NUM_ORDER = heinServiceType.NUM_ORDER;
                            this.HEIN_SERVICE_TYPE_NAME = heinServiceType.HEIN_SERVICE_TYPE_NAME;
                        }
                    }
                }

                if (rooms != null && rooms.Count > 0)
                {
                    V_HIS_ROOM room = rooms.FirstOrDefault(o => o.ID == data.TDL_EXECUTE_ROOM_ID);
                    if (room != null)
                    {
                        this.EXECUTE_ROOM_CODE = room.ROOM_CODE;
                        this.EXECUTE_ROOM_NAME = room.ROOM_NAME;
                    }
                }

                //Dong chi tra
                if (this.HEIN_LIMIT_PRICE.HasValue && this.HEIN_LIMIT_PRICE < this.VIR_PRICE)
                {
                    this.PRICE_CO_PAYMENT = this.VIR_PRICE - this.HEIN_LIMIT_PRICE.Value;
                }

                this.RADIO_SERIVCE = this.ORIGINAL_PRICE > 0 ? (this.HEIN_LIMIT_PRICE.HasValue ? (this.HEIN_LIMIT_PRICE.Value / this.ORIGINAL_PRICE) * 100 : (this.PRICE / this.ORIGINAL_PRICE) * 100) : 0;


            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        public decimal PriceBHYTProcess(HIS_SERE_SERV sereServ, V_HIS_PATIENT_TYPE_ALTER patyAlter)
        {
            decimal priceBHYT = 0;
            try
            {
                if (patyAlter != null && !String.IsNullOrEmpty(patyAlter.HEIN_CARD_NUMBER))
                {
                    if (sereServ.VIR_TOTAL_HEIN_PRICE == null || sereServ.VIR_TOTAL_HEIN_PRICE == 0)
                        priceBHYT = 0;
                    else
                    {
                        if (sereServ.HEIN_LIMIT_PRICE != null)
                            priceBHYT = sereServ.HEIN_LIMIT_PRICE.Value;
                        else
                            priceBHYT = sereServ.VIR_PRICE_NO_ADD_PRICE.Value;
                    }
                }
                else
                {
                    priceBHYT = 0;
                }
            }
            catch (Exception ex)
            {
                priceBHYT = 0;
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
            return priceBHYT;
        }
    }

    public class PatientADO : MOS.EFMODEL.DataModels.V_HIS_PATIENT
    {
        public string AGE { get; set; }
        public string DOB_STR { get; set; }
        public string CMND_DATE_STR { get; set; }
        public string DOB_YEAR { get; set; }
        public string GENDER_MALE { get; set; }
        public string GENDER_FEMALE { get; set; }

        public PatientADO()
        {

        }

        public PatientADO(V_HIS_PATIENT data)
        {
            try
            {
                if (data != null)
                {
                    System.Reflection.PropertyInfo[] pi = Inventec.Common.Repository.Properties.Get<V_HIS_PATIENT>();
                    foreach (var item in pi)
                    {
                        item.SetValue(this, item.GetValue(data));
                    }

                    this.AGE = AgeUtil.CalculateFullAge(this.DOB);
                    this.DOB_STR = Inventec.Common.DateTime.Convert.TimeNumberToDateString(this.DOB);
                    string temp = this.DOB.ToString();
                    if (temp != null && temp.Length >= 8)
                    {
                        this.DOB_YEAR = temp.Substring(0, 4);
                    }
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }
    }

    public class PatyAlterBhytADO : V_HIS_PATIENT_TYPE_ALTER
    {
        public string HEIN_CARD_NUMBER_SEPARATE { get; set; }
        public string IS_HEIN { get; set; }
        public string IS_VIENPHI { get; set; }
        public string STR_HEIN_CARD_FROM_TIME { get; set; }
        public string STR_HEIN_CARD_TO_TIME { get; set; }
        public string RATIO { get; set; }
        public string HEIN_CARD_NUMBER_1 { get; set; }
        public string HEIN_CARD_NUMBER_2 { get; set; }
        public string HEIN_CARD_NUMBER_3 { get; set; }
        public string HEIN_CARD_NUMBER_4 { get; set; }
        public string HEIN_CARD_NUMBER_5 { get; set; }
        public string HEIN_CARD_NUMBER_6 { get; set; }
        public long TIME_IN_TREATMENT { get; set; }
    }

    public class ServiceTypeCFG
    {
        public long? SERVICE_TYPE_ID__BED { get; set; }
        public long? SERVICE_TYPE_ID__BLOOD { get; set; }
        public long? SERVICE_TYPE_ID__DIIM { get; set; }
        public long? SERVICE_TYPE_ID__ENDO { get; set; }
        public long? SERVICE_TYPE_ID__EXAM { get; set; }
        public long? SERVICE_TYPE_ID__FUEX { get; set; }
        public long? SERVICE_TYPE_ID__MATE { get; set; }
        public long? SERVICE_TYPE_ID__MEDI { get; set; }
        public long? SERVICE_TYPE_ID__MISU { get; set; }
        public long? SERVICE_TYPE_ID__PAAN { get; set; }
        public long? SERVICE_TYPE_ID__REHA { get; set; }
        public long? SERVICE_TYPE_ID__SUIM { get; set; }
        public long? SERVICE_TYPE_ID__SURG { get; set; }
        public long? SERVICE_TYPE_ID__TEST { get; set; }
    }
    public class PatientTypeCFG
    {
        public long? PATIENT_TYPE_BHYT_ID { get; set; }
        public long? PATIENT_TYPE_SERVICE_ID { get; set; }
        public long? PATIENT_TYPE_THUPHI_ID { get; set; }
        public long? PATIENT_TYPE_FEE_ID { get; set; }
        public string PATIENT_TYPE_SERVICE_CODE { get; set; }
    }

    public class BordereauSingleValue
    {
        public string ratio { get; set; }
        public long today { get; set; }
        public string departmentName { get; set; }
        public string currentDateSeparateFullTime { get; set; }
        public string userNameReturnResult { get; set; }
        public string statusTreatmentOut { get; set; }
        public string mediStockName { get; set; }
    }

    public class HeinServiceTypeCFG
    {
        public long? HIGHTECH_ID { get; set; }
        public long? MATERIAL_VTTT_ID { get; set; }
        public long? EXAM_ID { get; set; }
        public long? SURG_MISU_ID { get; set; }
        public long? MEDI_MATE_FROM_CABINET_ID { get; set; }
    }
}
