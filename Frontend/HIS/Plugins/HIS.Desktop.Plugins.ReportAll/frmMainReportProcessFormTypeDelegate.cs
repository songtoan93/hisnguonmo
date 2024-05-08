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
using HIS.Desktop.LocalStorage.BackendData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HIS.Desktop.Plugins.ReportAll
{
    public partial class frmMainReport : HIS.Desktop.Utility.FormBase
    {
        private void ProcessFormTypeDelegate(Type type)
        {
            try
            {
                if (type == typeof(MOS.EFMODEL.DataModels.HIS_NONE_MEDI_SERVICE)) HIS.UC.FormType.Config.HisFormTypeConfig.HisNoneMediServices = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_NONE_MEDI_SERVICE>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_DATA_STORE)) HIS.UC.FormType.Config.HisFormTypeConfig.HisDataStores = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_DATA_STORE>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_OTHER_PAY_SOURCE)) HIS.UC.FormType.Config.HisFormTypeConfig.HisOtherPaySources = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_OTHER_PAY_SOURCE>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_BID_TYPE)) HIS.UC.FormType.Config.HisFormTypeConfig.HisBidTypes = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_BID_TYPE>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_PATIENT_CLASSIFY)) HIS.UC.FormType.Config.HisFormTypeConfig.HisPatientClassifys = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_PATIENT_CLASSIFY>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_DEBATE_TYPE)) HIS.UC.FormType.Config.HisFormTypeConfig.HisDebateTypes = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_DEBATE_TYPE>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_AREA)) HIS.UC.FormType.Config.HisFormTypeConfig.HisAreas = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_AREA>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(SDA.EFMODEL.DataModels.SDA_DISTRICT)) HIS.UC.FormType.Config.SdaFormTypeConfig.SdaDistrict = BackendDataWorker.Get<SDA.EFMODEL.DataModels.SDA_DISTRICT>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(SDA.EFMODEL.DataModels.SDA_COMMUNE)) HIS.UC.FormType.Config.SdaFormTypeConfig.SdaCommune = BackendDataWorker.Get<SDA.EFMODEL.DataModels.SDA_COMMUNE>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(SDA.EFMODEL.DataModels.SDA_PROVINCE)) HIS.UC.FormType.Config.SdaFormTypeConfig.SdaProvince = BackendDataWorker.Get<SDA.EFMODEL.DataModels.SDA_PROVINCE>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(SAR.EFMODEL.DataModels.SAR_FORM_TYPE)) HIS.UC.FormType.Config.SarFormTypeConfig.SarFormType = BackendDataWorker.Get<SAR.EFMODEL.DataModels.SAR_FORM_TYPE>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(ACS.EFMODEL.DataModels.ACS_USER)) HIS.UC.FormType.Config.AcsFormTypeConfig.HisAcsUser = BackendDataWorker.Get<ACS.EFMODEL.DataModels.ACS_USER>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_ACCIDENT_HURT_TYPE)) HIS.UC.FormType.Config.HisFormTypeConfig.HisAccidentHurtTypes = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_ACCIDENT_HURT_TYPE>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_ACCIDENT_RESULT)) HIS.UC.FormType.Config.HisFormTypeConfig.HisAccidentResults = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_ACCIDENT_RESULT>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_WORKING_SHIFT)) HIS.UC.FormType.Config.HisFormTypeConfig.HisWorkingShifts = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_WORKING_SHIFT>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.V_HIS_BED)) HIS.UC.FormType.Config.HisFormTypeConfig.VHisBeds = BackendDataWorker.Get<MOS.EFMODEL.DataModels.V_HIS_BED>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_BLOOD_RH)) HIS.UC.FormType.Config.HisFormTypeConfig.HisBloodRh = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_BLOOD_RH>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_BLOOD_TYPE)) HIS.UC.FormType.Config.HisFormTypeConfig.HisBloodType = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_BLOOD_TYPE>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_BRANCH)) HIS.UC.FormType.Config.HisFormTypeConfig.HisBranchs = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_BRANCH>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_CAREER)) HIS.UC.FormType.Config.HisFormTypeConfig.HisCareers = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_CAREER>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.V_HIS_CASHIER_ROOM)) HIS.UC.FormType.Config.HisFormTypeConfig.HisCashierRooms = BackendDataWorker.Get<MOS.EFMODEL.DataModels.V_HIS_CASHIER_ROOM>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_DEATH_CAUSE)) HIS.UC.FormType.Config.HisFormTypeConfig.HisDeathCauses = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_DEATH_CAUSE>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_DEATH_WITHIN)) HIS.UC.FormType.Config.HisFormTypeConfig.HisDeathWithins = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_DEATH_WITHIN>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_DEPARTMENT)) HIS.UC.FormType.Config.HisFormTypeConfig.HisDepartments = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_DEPARTMENT>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_EMOTIONLESS_METHOD)) HIS.UC.FormType.Config.HisFormTypeConfig.HisEmotionlessMethod = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_EMOTIONLESS_METHOD>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_EXECUTE_GROUP)) HIS.UC.FormType.Config.HisFormTypeConfig.HisExecuteGroups = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_EXECUTE_GROUP>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_EXECUTE_ROLE)) HIS.UC.FormType.Config.HisFormTypeConfig.HisExecuteRole = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_EXECUTE_ROLE>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_EXP_MEST_STT)) HIS.UC.FormType.Config.HisFormTypeConfig.HisExpMestStts = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_EXP_MEST_STT>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_EXP_MEST_TEMPLATE)) HIS.UC.FormType.Config.HisFormTypeConfig.VHisExpMestTemplates = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_EXP_MEST_TEMPLATE>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_EXP_MEST_TYPE)) HIS.UC.FormType.Config.HisFormTypeConfig.HisExpMestTypes = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_EXP_MEST_TYPE>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_FUND)) HIS.UC.FormType.Config.HisFormTypeConfig.HisFund = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_FUND>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_GENDER)) HIS.UC.FormType.Config.HisFormTypeConfig.HisGenders = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_GENDER>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_ICD)) HIS.UC.FormType.Config.HisFormTypeConfig.HisIcds = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_ICD>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_IMP_MEST_STT)) HIS.UC.FormType.Config.HisFormTypeConfig.HisImpMestStts = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_IMP_MEST_STT>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_IMP_MEST_TYPE)) HIS.UC.FormType.Config.HisFormTypeConfig.HisImpMestTypes = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_IMP_MEST_TYPE>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_IMP_SOURCE)) HIS.UC.FormType.Config.HisFormTypeConfig.HisImpSources = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_IMP_SOURCE>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_KSK_CONTRACT)) HIS.UC.FormType.Config.HisFormTypeConfig.HisKskContracts = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_KSK_CONTRACT>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.V_HIS_MATERIAL_TYPE)) HIS.UC.FormType.Config.HisFormTypeConfig.VHisMaterialTypes = BackendDataWorker.Get<MOS.EFMODEL.DataModels.V_HIS_MATERIAL_TYPE>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_MEDI_REACT_TYPE)) HIS.UC.FormType.Config.HisFormTypeConfig.HisMediReactTypes = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_MEDI_REACT_TYPE>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_MEDI_STOCK)) HIS.UC.FormType.Config.HisFormTypeConfig.HisMediStocks = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_MEDI_STOCK>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.V_HIS_MEDICINE_TYPE)) HIS.UC.FormType.Config.HisFormTypeConfig.VHisMedicineTypes = BackendDataWorker.Get<MOS.EFMODEL.DataModels.V_HIS_MEDICINE_TYPE>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.V_HIS_MEDICINE_TYPE_ACIN)) HIS.UC.FormType.Config.HisFormTypeConfig.VHisMedicineTypeAcins = BackendDataWorker.Get<MOS.EFMODEL.DataModels.V_HIS_MEDICINE_TYPE_ACIN>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_MEDICINE_USE_FORM)) HIS.UC.FormType.Config.HisFormTypeConfig.HisMedicineUseForms = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_MEDICINE_USE_FORM>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_MEDICINE_GROUP)) HIS.UC.FormType.Config.HisFormTypeConfig.HisMedicineGroups = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_MEDICINE_GROUP>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_MEST_PATIENT_TYPE)) HIS.UC.FormType.Config.HisFormTypeConfig.HisMestPatientTypes = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_MEST_PATIENT_TYPE>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.V_HIS_MEST_ROOM)) HIS.UC.FormType.Config.HisFormTypeConfig.VHisMestRooms = BackendDataWorker.Get<MOS.EFMODEL.DataModels.V_HIS_MEST_ROOM>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_MILITARY_RANK)) HIS.UC.FormType.Config.HisFormTypeConfig.HisMilitaryRanks = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_MILITARY_RANK>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_PATIENT_TYPE)) HIS.UC.FormType.Config.HisFormTypeConfig.HisPatientTypes = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_PATIENT_TYPE>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.V_HIS_PATIENT_TYPE_ALLOW)) HIS.UC.FormType.Config.HisFormTypeConfig.VHisPatientTypeAllows = BackendDataWorker.Get<MOS.EFMODEL.DataModels.V_HIS_PATIENT_TYPE_ALLOW>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_PAY_FORM)) HIS.UC.FormType.Config.HisFormTypeConfig.HisPayForms = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_PAY_FORM>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_PTTT_CATASTROPHE)) HIS.UC.FormType.Config.HisFormTypeConfig.HIsPtttCatastrophe = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_PTTT_CATASTROPHE>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_PTTT_CONDITION)) HIS.UC.FormType.Config.HisFormTypeConfig.HisPtttCondition = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_PTTT_CONDITION>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_PTTT_GROUP)) HIS.UC.FormType.Config.HisFormTypeConfig.HisPtttGroup = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_PTTT_GROUP>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_PTTT_METHOD)) HIS.UC.FormType.Config.HisFormTypeConfig.MethodPttt = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_PTTT_METHOD>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.V_HIS_ROOM)) HIS.UC.FormType.Config.HisFormTypeConfig.VHisRooms = BackendDataWorker.Get<MOS.EFMODEL.DataModels.V_HIS_ROOM>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_ROOM_TYPE)) HIS.UC.FormType.Config.HisFormTypeConfig.HisRoomTypes = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_ROOM_TYPE>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.V_HIS_SERV_SEGR)) HIS.UC.FormType.Config.HisFormTypeConfig.VHisServSegrs = BackendDataWorker.Get<MOS.EFMODEL.DataModels.V_HIS_SERV_SEGR>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.V_HIS_SERVICE)) HIS.UC.FormType.Config.HisFormTypeConfig.VHisServices = BackendDataWorker.Get<MOS.EFMODEL.DataModels.V_HIS_SERVICE>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_SERVICE_GROUP)) HIS.UC.FormType.Config.HisFormTypeConfig.VHisServiceGroups = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_SERVICE_GROUP>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.V_HIS_SERVICE_PACKAGE)) HIS.UC.FormType.Config.HisFormTypeConfig.VHisServicePackages = BackendDataWorker.Get<MOS.EFMODEL.DataModels.V_HIS_SERVICE_PACKAGE>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.V_HIS_SERVICE_PATY)) HIS.UC.FormType.Config.HisFormTypeConfig.VHisServicePatys = BackendDataWorker.Get<MOS.EFMODEL.DataModels.V_HIS_SERVICE_PATY>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_SERVICE_REQ_STT)) HIS.UC.FormType.Config.HisFormTypeConfig.HisServiceReqStts = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_SERVICE_REQ_STT>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_SERVICE_REQ_TYPE)) HIS.UC.FormType.Config.HisFormTypeConfig.HisServiceReqTypes = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_SERVICE_REQ_TYPE>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.V_HIS_SERVICE_ROOM)) HIS.UC.FormType.Config.HisFormTypeConfig.VHisServiceRooms = BackendDataWorker.Get<MOS.EFMODEL.DataModels.V_HIS_SERVICE_ROOM>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_SERVICE_TYPE)) HIS.UC.FormType.Config.HisFormTypeConfig.HisServiceTypes = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_SERVICE_TYPE>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_SUPPLIER)) HIS.UC.FormType.Config.HisFormTypeConfig.HisSuppliers = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_SUPPLIER>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.V_HIS_TEST_INDEX_RANGE)) HIS.UC.FormType.Config.HisFormTypeConfig.VHisTestIndexRanges = BackendDataWorker.Get<MOS.EFMODEL.DataModels.V_HIS_TEST_INDEX_RANGE>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_TRAN_PATI_FORM)) HIS.UC.FormType.Config.HisFormTypeConfig.HisTranPatiForms = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_TRAN_PATI_FORM>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_TRAN_PATI_REASON)) HIS.UC.FormType.Config.HisFormTypeConfig.HisTranPatiReasons = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_TRAN_PATI_REASON>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_TREATMENT_END_TYPE)) HIS.UC.FormType.Config.HisFormTypeConfig.HisTreatmentEndTypes = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_TREATMENT_END_TYPE>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_TREATMENT_RESULT)) HIS.UC.FormType.Config.HisFormTypeConfig.HisTreatmentResults = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_TREATMENT_RESULT>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_TREATMENT_TYPE)) HIS.UC.FormType.Config.HisFormTypeConfig.HisTreatmentTypes = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_TREATMENT_TYPE>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.V_HIS_USER_ROOM)) HIS.UC.FormType.Config.HisFormTypeConfig.VHisUserRooms = BackendDataWorker.Get<MOS.EFMODEL.DataModels.V_HIS_USER_ROOM>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_WORK_PLACE)) HIS.UC.FormType.Config.HisFormTypeConfig.HisWorkPlaces = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_WORK_PLACE>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(SAR.EFMODEL.DataModels.SAR_FORM_FIELD)) HIS.UC.FormType.FormTypeConfig.FormFields = BackendDataWorker.Get<SAR.EFMODEL.DataModels.SAR_FORM_FIELD>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.LibraryHein.Bhyt.HeinLiveArea.HeinLiveAreaData)) HIS.UC.FormType.Config.OtherFormTypeConfig.HeinLiveAreas = BackendDataWorker.Get<MOS.LibraryHein.Bhyt.HeinLiveArea.HeinLiveAreaData>().ToList();
                else if (type == typeof(MOS.LibraryHein.Bhyt.HeinRightRouteType.HeinRightRouteTypeData)) HIS.UC.FormType.Config.OtherFormTypeConfig.HeinRightRouteTypes = BackendDataWorker.Get<MOS.LibraryHein.Bhyt.HeinRightRouteType.HeinRightRouteTypeData>().ToList();

                //else if (type == typeof(MOS.EFMODEL.DataModels.HIS_ACCOUNT_BOOK)) HIS.UC.FormType.Config.HisFormTypeConfig.HisAccountBooks = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_ACCOUNT_BOOK>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                //else if (type == typeof(MOS.EFMODEL.DataModels.HIS_BLOOD)) HIS.UC.FormType.Config.HisFormTypeConfig.HisBlood = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_BLOOD>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                //else if (type == typeof(MOS.EFMODEL.DataModels.HIS_INVOICE_BOOK)) HIS.UC.FormType.Config.HisFormTypeConfig.HisInvoiceBooks = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_INVOICE_BOOK>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                //else if (type == typeof(MOS.EFMODEL.DataModels.HIS_INVOICE)) HIS.UC.FormType.Config.HisFormTypeConfig.HisInvoices = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_INVOICE>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                //else if (type == typeof(MOS.EFMODEL.DataModels.HIS_PROGRAM)) HIS.UC.FormType.Config.HisFormTypeConfig.HisProgram = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_PROGRAM>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                //else if (type == typeof(MOS.EFMODEL.DataModels.HIS_REPORT_TYPE_CAT)) HIS.UC.FormType.Config.HisFormTypeConfig.HisReportTypeCats = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_REPORT_TYPE_CAT>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                //else if (type == typeof(MOS.EFMODEL.DataModels.HIS_TEXT_LIB)) HIS.UC.FormType.Config.HisFormTypeConfig.HisTextLibs = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_TEXT_LIB>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                //else if (type == typeof(MOS.EFMODEL.DataModels.V_HIS_PATIENT_PROGRAM)) HIS.UC.FormType.Config.HisFormTypeConfig.VHisPatientProgram = BackendDataWorker.Get<MOS.EFMODEL.DataModels.V_HIS_PATIENT_PROGRAM>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                //else if (type == typeof(MOS.EFMODEL.DataModels.HIS_BID)) HIS.UC.FormType.Config.HisFormTypeConfig.VHisBids = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_BID>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                //else if (type == typeof(MOS.EFMODEL.DataModels.HIS_ICD_GROUP)) HIS.UC.FormType.Config.HisFormTypeConfig.VHisIcdGroups = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_ICD_GROUP>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                //else if (type == typeof(MOS.EFMODEL.DataModels.V_HIS_MATERIAL_BEAN)) HIS.UC.FormType.Config.HisFormTypeConfig.VHisMaterialBeans = BackendDataWorker.Get<MOS.EFMODEL.DataModels.V_HIS_MATERIAL_BEAN>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                //else if (type == typeof(MOS.EFMODEL.DataModels.V_HIS_MEDICINE_BEAN)) HIS.UC.FormType.Config.HisFormTypeConfig.VHisMedicineBeans = BackendDataWorker.Get<MOS.EFMODEL.DataModels.V_HIS_MEDICINE_BEAN>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                //else if (type == typeof(MOS.EFMODEL.DataModels.V_HIS_MEDI_STOCK_PERIOD)) HIS.UC.FormType.Config.HisFormTypeConfig.VHisMediStockPeriod = BackendDataWorker.Get<MOS.EFMODEL.DataModels.V_HIS_MEDI_STOCK_PERIOD>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                //else if (type == typeof(MOS.EFMODEL.DataModels.V_HIS_SERVICE_RETY_CAT)) HIS.UC.FormType.Config.HisFormTypeConfig.VHisServiceRetyCatLists = BackendDataWorker.Get<MOS.EFMODEL.DataModels.V_HIS_SERVICE_RETY_CAT>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_MACHINE)) HIS.UC.FormType.Config.HisFormTypeConfig.HisMachines = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_MACHINE>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
                else if (type == typeof(MOS.EFMODEL.DataModels.HIS_MEDI_ORG)) HIS.UC.FormType.Config.HisFormTypeConfig.HisMediOrgs = BackendDataWorker.Get<MOS.EFMODEL.DataModels.HIS_MEDI_ORG>().Where(o => o.IS_ACTIVE == IMSys.DbConfig.HIS_RS.COMMON.IS_ACTIVE__TRUE).ToList();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }
    }
}
