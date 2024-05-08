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
using HIS.Desktop.ADO;
using HIS.Desktop.LocalStorage.BackendData;
using HIS.Desktop.Plugins.Library.PrintOtherForm.Base;
using HIS.Desktop.Plugins.Library.PrintOtherForm.RunPrintTemplate;
using Inventec.Desktop.Common.Message;
using MOS.EFMODEL.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.Desktop.Plugins.Library.PrintOtherForm.MpsBehavior.Mps000410
{
    public partial class Mps000410Behavior : MpsDataBase, ILoad
    {
        private V_HIS_TREATMENT treatment { get; set; }
        private HIS_DHST dhst { get; set; }

        private long dhstId;

        public Mps000410Behavior(long _treatmentId, long _dhstId)
            : base()
        {
            this.TreatmentId = _treatmentId;
            this.dhstId = _dhstId;
        }

        bool ILoad.Load(string printTypeCode, UpdateType.TYPE updateType)
        {
            bool result = false;
            try
            {
                WaitingManager.Show();
                this.LoadData();

                SAR.EFMODEL.DataModels.SAR_PRINT_TYPE printTemplate = BackendDataWorker.Get<SAR.EFMODEL.DataModels.SAR_PRINT_TYPE>().FirstOrDefault(o => o.PRINT_TYPE_CODE == printTypeCode);
                if (printTemplate == null)
                {
                    throw new Exception("Khong tim thay template");
                }

                this.SetDicParamCommon(ref dicParamPlus);

                //Thoi gian vao,ra vien
                if (this.treatment != null)
                {
                    AddKeyIntoDictionaryPrint<V_HIS_TREATMENT>(this.treatment, dicParamPlus);
                    if (this.treatment.CLINICAL_IN_TIME.HasValue)
                    {
                        dicParamPlus.Add("CLINICAL_IN_TIME_SEPARATE_STR", HIS.Desktop.Utilities.GlobalReportQuery.GetTimeSeparateFromTime(this.treatment.CLINICAL_IN_TIME.Value));
                        dicParamPlus.Add("CLINICAL_IN_TIME_STR", Inventec.Common.DateTime.Convert.TimeNumberToTimeStringWithoutSecond(this.treatment.CLINICAL_IN_TIME.Value));
                    }
                    else
                    {
                        dicParamPlus.Add("CLINICAL_IN_TIME_SEPARATE_STR", "");
                        dicParamPlus.Add("CLINICAL_IN_TIME_STR", "");
                    }

                    dicParamPlus.Add("IN_TIME_STR", Inventec.Common.DateTime.Convert.TimeNumberToTimeStringWithoutSecond(this.treatment.IN_TIME));
                    DateTime intime = Inventec.Common.DateTime.Convert.TimeNumberToSystemDateTime(this.treatment.IN_TIME) ?? DateTime.Now;
                    dicParamPlus.Add("IND",gan(intime.Day));
                    dicParamPlus.Add("INM", gan(intime.Month));
                    dicParamPlus.Add("INY", gan(intime.Year));

                    dicParamPlus.Add("OUT_TIME_STR", Inventec.Common.DateTime.Convert.TimeNumberToTimeStringWithoutSecond(this.treatment.OUT_TIME ?? 0));
                    DateTime outtime = Inventec.Common.DateTime.Convert.TimeNumberToSystemDateTime(this.treatment.OUT_TIME ?? 0) ?? DateTime.MaxValue;
                    if (outtime.Year == DateTime.MaxValue.Year)
                    {
                        dicParamPlus.Add("OUTD", null);
                        dicParamPlus.Add("OUTM", null);
                        dicParamPlus.Add("OUTY", null);
                    }
                    else
                    {
                        dicParamPlus.Add("OUTD", gan(outtime.Day));
                        dicParamPlus.Add("OUTM", gan(outtime.Month));
                        dicParamPlus.Add("OUTY", gan(outtime.Year));
                    }


                    dicParamPlus.Add("AGE", this.CalculateFullAge(this.treatment.TDL_PATIENT_DOB));
                    DateTime dob = Inventec.Common.DateTime.Convert.TimeNumberToSystemDateTime(this.treatment.TDL_PATIENT_DOB) ?? DateTime.Now;
                    dicParamPlus.Add("AGE_BY_YEAR1", DateTime.Now.Year - dob.Year);
                    dicParamPlus.Add("AGE_BY_YEAR", gan(dob.Year));
                    dicParamPlus.Add("AGE_BY_M", gan(dob.Month));
                    dicParamPlus.Add("AGE_BY_DAY", gan(dob.Day));
                }

                if (this.dhst == null) this.dhst = new HIS_DHST();

                if (this.dhst != null)
                {

                    AddKeyIntoDictionaryPrint<HIS_DHST>(this.dhst, dicParamPlus);
                }

                List<string> keys = new List<string>();
                foreach (var item in dicParamPlus)
                {
                    if (item.Value == null)
                    {
                        keys.Add(item.Key);
                    }
                }

                if (keys.Count > 0)
                {
                    foreach (var key in keys)
                    {
                        dicParamPlus[key] = "";
                    }
                }
                WaitingManager.Hide();

                if (updateType == UpdateType.TYPE.OPEN_OTHER_ASS_TREATMENT)
                {
                    OtherFormAssTreatmentInputADO otherFormAssTreatmentInputADO = new OtherFormAssTreatmentInputADO();
                    otherFormAssTreatmentInputADO.TreatmentId = this.TreatmentId;
                    otherFormAssTreatmentInputADO.PrintTypeCode = printTypeCode;
                    otherFormAssTreatmentInputADO.DicParam = dicParamPlus;
                    List<object> listObj = new List<object>();
                    listObj.Add(otherFormAssTreatmentInputADO);

                    HIS.Desktop.ModuleExt.PluginInstanceBehavior.ShowModule("HIS.Desktop.Plugins.OtherFormAssTreatment", 0, 0, listObj);
                }
                else
                {
                    IRunTemp behavior = RunUpdateFactory.RunTemplateByUpdateType(this.treatment, updateType);
                    result = behavior != null ? (behavior.Run(printTemplate, dicParamPlus, dicImagePlus, richEditorMain, null)) : false;
                }
            }
            catch (Exception ex)
            {
                result = false;
                WaitingManager.Hide();
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
            return result;
        }
        private string gan(int a)
        {
            string b = "";
            if (a != null)
            {
                if (a.ToString().Length == 1)
                {
                    b = "0" + a.ToString();
                }
                else
                {
                    b = a.ToString();
                }
            }
            return b;
        }
    }
}
