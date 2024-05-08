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
using Inventec.Common.QRCoder;
using MOS.EFMODEL.DataModels;
using MPS.Processor.Mps000028.PDO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MPS.Processor.Mps000028
{
    class SereServQrADO : SereServADO
    {
        public byte[] QrCT540 { get; set; }
        private V_HIS_SERVICE_REQ ServiceReqPrint;

        public SereServQrADO(SereServADO data, V_HIS_SERVICE_REQ serviceReqPrint)
        {
            if (data != null)
            {
                System.Reflection.PropertyInfo[] pi = Inventec.Common.Repository.Properties.Get<SereServADO>();
                foreach (var item in pi)
                {
                    item.SetValue(this, (item.GetValue(data)));
                }

                this.ServiceReqPrint = serviceReqPrint;
                processQrCode();
            }
        }

        #region QRCODE
        private void processQrCode()
        {
            Task[] taskArray = new Task[6];
            taskArray[0] = Task.Factory.StartNew(ProcessQrPatient);
            taskArray[1] = Task.Factory.StartNew(ProcessQrPatientName);
            taskArray[2] = Task.Factory.StartNew(ProcessQrDescription);
            taskArray[3] = Task.Factory.StartNew(ProcessQrDiim);
            taskArray[4] = Task.Factory.StartNew(ProcessQrDiimV2);
            taskArray[5] = Task.Factory.StartNew(ProcessQrCT540);
            Task.WaitAll(taskArray);
        }

        private void ProcessQrDescription()
        {
            try
            {
                QRCodeGenerator qrGeneratorStudyDescription = new QRCodeGenerator();
                QRCodeData qrCodeDataStudyDescription = qrGeneratorStudyDescription.CreateQrCode(this.studyDescriptionQr, QRCodeGenerator.ECCLevel.Q);
                BitmapByteQRCode qrCodeStudyDescription = new BitmapByteQRCode(qrCodeDataStudyDescription);
                byte[] qrCodeImageStudyDescription = qrCodeStudyDescription.GetGraphic(20);
                this.bStudyDescriptionQr = qrCodeImageStudyDescription;
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void ProcessQrPatientName()
        {
            try
            {
                QRCodeGenerator qrGeneratorPatientName = new QRCodeGenerator();
                QRCodeData qrCodeDataPatientName = qrGeneratorPatientName.CreateQrCode(this.patientNameQr, QRCodeGenerator.ECCLevel.Q);
                BitmapByteQRCode qrCodePatientName = new BitmapByteQRCode(qrCodeDataPatientName);
                byte[] qrCodeImagePatientName = qrCodePatientName.GetGraphic(20);
                this.bPatientNameQr = qrCodeImagePatientName;
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void ProcessQrPatient()
        {
            try
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(this.patientIdQr, QRCodeGenerator.ECCLevel.Q);
                BitmapByteQRCode qrCode = new BitmapByteQRCode(qrCodeData);
                byte[] qrCodeImage = qrCode.GetGraphic(20);
                this.bPatientQr = qrCodeImage;
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void ProcessQrDiim()
        {
            try
            {
                if (ServiceReqPrint != null)
                {
                    List<string> qrInfos = new List<string>();
                    qrInfos.Add(ServiceReqPrint.TDL_PATIENT_CODE);

                    int namSinh = 0;
                    int.TryParse(ServiceReqPrint.TDL_PATIENT_DOB.ToString().Substring(0, 4), out namSinh);
                    DateTime dtNow = Inventec.Common.DateTime.Convert.TimeNumberToSystemDateTime(ServiceReqPrint.INTRUCTION_TIME) ?? DateTime.Now;
                    int tuoi = dtNow.Year - namSinh;
                    if (tuoi < 6)
                    {
                        qrInfos.Add(Inventec.Common.String.Convert.UnSignVNese2(ServiceReqPrint.TDL_PATIENT_NAME) + " " + CalculatorAge(ServiceReqPrint.INTRUCTION_TIME, ServiceReqPrint.TDL_PATIENT_DOB));
                        qrInfos.Add(namSinh.ToString());
                        qrInfos.Add(" ");
                    }
                    else
                    {
                        qrInfos.Add(Inventec.Common.String.Convert.UnSignVNese2(ServiceReqPrint.TDL_PATIENT_NAME));
                        qrInfos.Add(namSinh.ToString());
                        qrInfos.Add(tuoi.ToString());
                    }

                    if (ServiceReqPrint.TDL_PATIENT_GENDER_ID == IMSys.DbConfig.HIS_RS.HIS_GENDER.ID__MALE)
                    {
                        qrInfos.Add("M");
                    }
                    else if (ServiceReqPrint.TDL_PATIENT_GENDER_ID == IMSys.DbConfig.HIS_RS.HIS_GENDER.ID__FEMALE)
                    {
                        qrInfos.Add("F");
                    }
                    else
                    {
                        qrInfos.Add("O");
                    }

                    qrInfos.Add(this.ID.ToString());
                    qrInfos.Add(" ");

                    string totalQrInfo = string.Join("\t", qrInfos);
                    QRCodeGenerator qrInfo = new QRCodeGenerator();
                    QRCodeData qrInfoData = qrInfo.CreateQrCode(totalQrInfo, QRCodeGenerator.ECCLevel.Q);
                    BitmapByteQRCode qrICode = new BitmapByteQRCode(qrInfoData);
                    byte[] qrICodeImage = qrICode.GetGraphic(20);
                    this.ServiceReqExecuteQr = qrICodeImage;
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void ProcessQrDiimV2()
        {
            try
            {
                if (ServiceReqPrint != null)
                {
                    List<string> qrInfos = new List<string>();
                    qrInfos.Add(ServiceReqPrint.TDL_PATIENT_CODE);

                    int namSinh = 0;
                    int.TryParse(ServiceReqPrint.TDL_PATIENT_DOB.ToString().Substring(0, 4), out namSinh);
                    DateTime dtNow = Inventec.Common.DateTime.Convert.TimeNumberToSystemDateTime(ServiceReqPrint.INTRUCTION_TIME) ?? DateTime.Now;
                    int tuoi = dtNow.Year - namSinh;
                    if (tuoi < 6)
                    {
                        qrInfos.Add(Inventec.Common.String.Convert.UnSignVNese2(ServiceReqPrint.TDL_PATIENT_NAME) + " " + CalculatorAge(ServiceReqPrint.INTRUCTION_TIME, ServiceReqPrint.TDL_PATIENT_DOB));
                        qrInfos.Add(namSinh.ToString());
                        qrInfos.Add(" ");
                    }
                    else
                    {
                        qrInfos.Add(Inventec.Common.String.Convert.UnSignVNese2(ServiceReqPrint.TDL_PATIENT_NAME));
                        qrInfos.Add(namSinh.ToString());
                        qrInfos.Add(tuoi.ToString());
                    }

                    if (ServiceReqPrint.TDL_PATIENT_GENDER_ID == IMSys.DbConfig.HIS_RS.HIS_GENDER.ID__MALE)
                    {
                        qrInfos.Add("M");
                    }
                    else if (ServiceReqPrint.TDL_PATIENT_GENDER_ID == IMSys.DbConfig.HIS_RS.HIS_GENDER.ID__FEMALE)
                    {
                        qrInfos.Add("F");
                    }
                    else
                    {
                        qrInfos.Add("O");
                    }

                    qrInfos.Add("");
                    qrInfos.Add(this.ID.ToString());

                    string totalQrInfo = string.Join("\t", qrInfos);
                    QRCodeGenerator qrInfo = new QRCodeGenerator();
                    QRCodeData qrInfoData = qrInfo.CreateQrCode(totalQrInfo, QRCodeGenerator.ECCLevel.Q);
                    BitmapByteQRCode qrICode = new BitmapByteQRCode(qrInfoData);
                    byte[] qrICodeImage = qrICode.GetGraphic(20);
                    this.QrDiimV2 = qrICodeImage;
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void ProcessQrCT540()
        {
            try
            {
                if (ServiceReqPrint != null)
                {
                    List<string> qrInfos = new List<string>();
                    qrInfos.Add(this.TDL_SERVICE_REQ_CODE);
                    qrInfos.Add(this.TDL_TREATMENT_CODE);
                    qrInfos.Add(ServiceReqPrint.TDL_PATIENT_NAME);

                    if (ServiceReqPrint.TDL_PATIENT_GENDER_ID == IMSys.DbConfig.HIS_RS.HIS_GENDER.ID__MALE)
                    {
                        qrInfos.Add("M");
                    }
                    else if (ServiceReqPrint.TDL_PATIENT_GENDER_ID == IMSys.DbConfig.HIS_RS.HIS_GENDER.ID__FEMALE)
                    {
                        qrInfos.Add("F");
                    }
                    else
                    {
                        qrInfos.Add("O");
                    }

                    qrInfos.Add("");

                    int namSinh = 0;
                    int.TryParse(ServiceReqPrint.TDL_PATIENT_DOB.ToString().Substring(0, 4), out namSinh);
                    DateTime dtNow = Inventec.Common.DateTime.Convert.TimeNumberToSystemDateTime(ServiceReqPrint.INTRUCTION_TIME) ?? DateTime.Now;
                    int tuoi = dtNow.Year - namSinh;
                    qrInfos.Add(tuoi.ToString());

                    string totalQrInfo = string.Join("\t", qrInfos);
                    QRCodeGenerator qrInfo = new QRCodeGenerator();
                    QRCodeData qrInfoData = qrInfo.CreateQrCode(totalQrInfo, QRCodeGenerator.ECCLevel.Q);
                    BitmapByteQRCode qrICode = new BitmapByteQRCode(qrInfoData);
                    byte[] qrICodeImage = qrICode.GetGraphic(20);
                    this.QrCT540 = qrICodeImage;
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private string CalculatorAge(long dtNow, long ageYearNumber)
        {
            string tuoi = "";
            try
            {
                string caption__Tuoi = "T";
                string caption__ThangTuoi = "TH";
                string caption__NgayTuoi = "NT";
                string caption__GioTuoi = "GT";

                if (ageYearNumber > 0)
                {
                    System.DateTime dtNgSinh = Inventec.Common.DateTime.Convert.TimeNumberToSystemDateTime(ageYearNumber).Value;
                    if (dtNgSinh == System.DateTime.MinValue) throw new ArgumentNullException("dtNgSinh");

                    DateTime current = Inventec.Common.DateTime.Convert.TimeNumberToSystemDateTime(dtNow) ?? DateTime.Now;

                    TimeSpan diff__hour = (current - dtNgSinh);
                    TimeSpan diff__month = (current.Date - dtNgSinh.Date);

                    //- Dưới 24h: tính chính xác đến giờ.
                    double hour = diff__hour.TotalHours;
                    if (hour < 24)
                    {
                        tuoi = ((int)hour + caption__GioTuoi);
                    }
                    else
                    {
                        long tongsogiay__hour = diff__hour.Ticks;
                        System.DateTime newDate__hour = new System.DateTime(tongsogiay__hour);
                        int month__hour = ((newDate__hour.Year - 1) * 12 + newDate__hour.Month - 1);
                        if (month__hour == 0)
                        {
                            //Nếu Bn trên 24 giờ và dưới 1 tháng tuổi => hiển thị "xyz ngày tuổi"
                            tuoi = ((int)diff__month.TotalDays + caption__NgayTuoi);
                        }
                        else
                        {
                            long tongsogiay = diff__month.Ticks;
                            System.DateTime newDate = new System.DateTime(tongsogiay);
                            int month = ((newDate.Year - 1) * 12 + newDate.Month - 1);
                            if (month == 0)
                            {
                                //Nếu Bn trên 24 giờ và dưới 1 tháng tuổi => hiển thị "xyz ngày tuổi"
                                tuoi = ((int)diff__month.TotalDays + caption__NgayTuoi);
                            }
                            else
                            {
                                //- Dưới 72 tháng tuổi: tính chính xác đến tháng như hiện tại
                                if (month < 72)
                                {
                                    tuoi = (month + caption__ThangTuoi);
                                }
                                //- Trên 72 tháng tuổi: tính chính xác đến năm: tuổi= năm hiện tại - năm sinh
                                else
                                {
                                    int year = current.Year - dtNgSinh.Year;
                                    tuoi = (year + caption__Tuoi);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                tuoi = "";
            }
            return tuoi;
        }
        #endregion
    }
}
