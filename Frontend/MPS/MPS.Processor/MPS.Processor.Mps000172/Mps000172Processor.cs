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
using Inventec.Core;
using MOS.EFMODEL.DataModels;
using MPS.Processor.Mps000172.PDO;
using MPS.ProcessorBase.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.Processor.Mps000172
{
    class Mps000172Processor : AbstractProcessor
    {
        Mps000172PDO rdo;
        public Mps000172Processor(CommonParam param, PrintData printData)
            : base(param, printData)
        {
            rdo = (Mps000172PDO)rdoBase;
        }

        public override bool ProcessData()
        {
            bool result = false;
            try
            {
                Inventec.Common.FlexCellExport.ProcessSingleTag singleTag = new Inventec.Common.FlexCellExport.ProcessSingleTag();

                store.ReadTemplate(System.IO.Path.GetFullPath(fileName));
                this.SetSingleKey();
                //ghi đè PrintLogData và UniqueCodeData
                ProcessPrintLogData();
                //lấy số lần in
                SetNumOrderKey(GetNumOrderPrint(ProcessUniqueCodeData()));

                singleTag.ProcessData(store, singleValueDictionary);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                Inventec.Common.Logging.LogSystem.Error(ex);
            }

            return result;
        }

        public override string ProcessPrintLogData()
        {
            string log = "";
            try
            {
                log = LogDataTransaction(rdo._Transaction.TREATMENT_CODE, rdo._Transaction.TRANSACTION_CODE, "");
                log += "SoTien: " + rdo._Transaction.AMOUNT;
            }
            catch (Exception ex)
            {
                log = "";
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
            return log;
        }

        public override string ProcessUniqueCodeData()
        {
            string result = "";
            try
            {
                if (rdo != null && rdo._Transaction != null)
                    result = String.Format("{0}_{1}_{2}_{3}", "Mps000172", rdo._Transaction.TREATMENT_CODE, rdo._Transaction.TRANSACTION_CODE, rdo._Transaction.ACCOUNT_BOOK_CODE);
            }
            catch (Exception ex)
            {
                result = "";
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
            return result;
        }

        public void SetSingleKey()
        {
            try
            {
                if (rdo._Transaction != null)
                {
                    AddObjectKeyIntoListkey<V_HIS_TRANSACTION>(rdo._Transaction, false);
                    SetSingleKey(new KeyValue(Mps000172ExtendSingleKey.DOB_STR, Inventec.Common.DateTime.Convert.TimeNumberToDateString(rdo._Transaction.TDL_PATIENT_DOB ?? 0)));
                    string amountStr = string.Format("{0:0.####}", Inventec.Common.Number.Convert.NumberToNumberRoundMax4(rdo._Transaction.AMOUNT));
                    string amountText = Inventec.Common.String.Convert.CurrencyToVneseString(amountStr);
                    SetSingleKey(new KeyValue(Mps000172ExtendSingleKey.AMOUNT_TEXT, amountText));
                    SetSingleKey(new KeyValue(Mps000172ExtendSingleKey.AMOUNT_TEXT_UPPER_FIRST, amountText));
                    SetSingleKey(new KeyValue(Mps000172ExtendSingleKey.CREATE_DATE_SEPARATE_STR, Inventec.Common.DateTime.Convert.TimeNumberToDateStringSeparateString(rdo._Transaction.CREATE_TIME ?? 0)));
                }
                else
                {
                    throw new Exception("Nguoi dung khong truyen vao V_HIS_TRANSACTION: Mps000172. ");
                }

                if (rdo._BatyAlterBhyt != null)
                {
                    AddObjectKeyIntoListkey<V_HIS_PATIENT_TYPE_ALTER>(rdo._BatyAlterBhyt, false);
                    SetSingleKey(new KeyValue(Mps000172ExtendSingleKey.HEIN_CARD_FROM_DATE_STR, Inventec.Common.DateTime.Convert.TimeNumberToDateString(rdo._BatyAlterBhyt.HEIN_CARD_FROM_TIME ?? 0)));
                    SetSingleKey(new KeyValue(Mps000172ExtendSingleKey.HEIN_CARD_TO_DATE_STR, Inventec.Common.DateTime.Convert.TimeNumberToDateString(rdo._BatyAlterBhyt.HEIN_CARD_TO_TIME ?? 0)));
                    SetSingleKey(new KeyValue(Mps000172ExtendSingleKey.HEIN_CARD_ADDRESS, rdo._BatyAlterBhyt.ADDRESS));
                }
                if (rdo._DepartmentTran != null)
                {
                    AddObjectKeyIntoListkey<V_HIS_DEPARTMENT_TRAN>(rdo._DepartmentTran, false);
                }
                if (rdo._Patient != null)
                {
                    AddObjectKeyIntoListkey<HIS_PATIENT>(rdo._Patient, false);
                }

                if (rdo.DepartmentTranAllByTreatments != null)
                {
                    var requestDepartment = rdo.DepartmentTranAllByTreatments
                        .Where(o => o.DEPARTMENT_IN_TIME.HasValue && o.DEPARTMENT_IN_TIME <= rdo._Transaction.TRANSACTION_TIME)
                        .OrderByDescending(o => o.DEPARTMENT_IN_TIME)
                        .ThenByDescending(o => o.ID).FirstOrDefault();
                    if (requestDepartment != null)
                    {
                        SetSingleKey(new KeyValue(Mps000172ExtendSingleKey.REQUEST_DEPARTMENT_CODE, requestDepartment.DEPARTMENT_CODE));
                        SetSingleKey(new KeyValue(Mps000172ExtendSingleKey.REQUEST_DEPARTMENT_NAME, requestDepartment.DEPARTMENT_NAME));
                    }

                    var currentDepartment = rdo.DepartmentTranAllByTreatments
                        .Where(o => o.CREATE_TIME <= rdo._Transaction.TRANSACTION_TIME)
                        .OrderByDescending(o => o.CREATE_TIME)
                        .ThenByDescending(o => o.ID).FirstOrDefault();
                    if (currentDepartment != null)
                    {
                        SetSingleKey(new KeyValue(Mps000172ExtendSingleKey.CURRENT_DEPARTMENT_CODE, currentDepartment.DEPARTMENT_CODE));
                        SetSingleKey(new KeyValue(Mps000172ExtendSingleKey.CURRENT_DEPARTMENT_NAME, currentDepartment.DEPARTMENT_NAME));
                        SetSingleKey(new KeyValue(Mps000172ExtendSingleKey.CURRENT_PREVIOUS_DEPARTMENT_CODE, currentDepartment.PREVIOUS_DEPARTMENT_CODE));
                        SetSingleKey(new KeyValue(Mps000172ExtendSingleKey.CURRENT_PREVIOS_DEPARTMENT_NAME, currentDepartment.PREVIOUS_DEPARTMENT_NAME));
                    }
                }

                SetSingleKey(new KeyValue(Mps000172ExtendSingleKey.RATIO, rdo.ratio));
                SetSingleKey(new KeyValue(Mps000172ExtendSingleKey.RATIO_STR, (rdo.ratio * 100) + "%"));
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }
    }
}
