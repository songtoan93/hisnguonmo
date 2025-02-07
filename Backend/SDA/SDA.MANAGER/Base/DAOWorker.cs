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
using Inventec.Common.Repository;

namespace SDA.MANAGER.Base
{
    static class DAOWorker
    {
        internal static SDA.DAO.SdaCommune.SdaCommuneDAO SdaCommuneDAO { get { return (SDA.DAO.SdaCommune.SdaCommuneDAO)Worker.Get<SDA.DAO.SdaCommune.SdaCommuneDAO>(); } }
        internal static SDA.DAO.SdaConfig.SdaConfigDAO SdaConfigDAO { get { return (SDA.DAO.SdaConfig.SdaConfigDAO)Worker.Get<SDA.DAO.SdaConfig.SdaConfigDAO>(); } }
        internal static SDA.DAO.SdaConfigApp.SdaConfigAppDAO SdaConfigAppDAO { get { return (SDA.DAO.SdaConfigApp.SdaConfigAppDAO)Worker.Get<SDA.DAO.SdaConfigApp.SdaConfigAppDAO>(); } }
        internal static SDA.DAO.SdaConfigAppUser.SdaConfigAppUserDAO SdaConfigAppUserDAO { get { return (SDA.DAO.SdaConfigAppUser.SdaConfigAppUserDAO)Worker.Get<SDA.DAO.SdaConfigAppUser.SdaConfigAppUserDAO>(); } }
        internal static SDA.DAO.SdaDistrict.SdaDistrictDAO SdaDistrictDAO { get { return (SDA.DAO.SdaDistrict.SdaDistrictDAO)Worker.Get<SDA.DAO.SdaDistrict.SdaDistrictDAO>(); } }
        internal static SDA.DAO.SdaEthnic.SdaEthnicDAO SdaEthnicDAO { get { return (SDA.DAO.SdaEthnic.SdaEthnicDAO)Worker.Get<SDA.DAO.SdaEthnic.SdaEthnicDAO>(); } }
        internal static SDA.DAO.SdaEventLog.SdaEventLogDAO SdaEventLogDAO { get { return (SDA.DAO.SdaEventLog.SdaEventLogDAO)Worker.Get<SDA.DAO.SdaEventLog.SdaEventLogDAO>(); } }
        internal static SDA.DAO.SdaGroup.SdaGroupDAO SdaGroupDAO { get { return (SDA.DAO.SdaGroup.SdaGroupDAO)Worker.Get<SDA.DAO.SdaGroup.SdaGroupDAO>(); } }
        internal static SDA.DAO.SdaGroupType.SdaGroupTypeDAO SdaGroupTypeDAO { get { return (SDA.DAO.SdaGroupType.SdaGroupTypeDAO)Worker.Get<SDA.DAO.SdaGroupType.SdaGroupTypeDAO>(); } }
        internal static SDA.DAO.SdaLanguage.SdaLanguageDAO SdaLanguageDAO { get { return (SDA.DAO.SdaLanguage.SdaLanguageDAO)Worker.Get<SDA.DAO.SdaLanguage.SdaLanguageDAO>(); } }
        internal static SDA.DAO.SdaLicense.SdaLicenseDAO SdaLicenseDAO { get { return (SDA.DAO.SdaLicense.SdaLicenseDAO)Worker.Get<SDA.DAO.SdaLicense.SdaLicenseDAO>(); } }
        internal static SDA.DAO.SdaNational.SdaNationalDAO SdaNationalDAO { get { return (SDA.DAO.SdaNational.SdaNationalDAO)Worker.Get<SDA.DAO.SdaNational.SdaNationalDAO>(); } }
        internal static SDA.DAO.SdaNotify.SdaNotifyDAO SdaNotifyDAO { get { return (SDA.DAO.SdaNotify.SdaNotifyDAO)Worker.Get<SDA.DAO.SdaNotify.SdaNotifyDAO>(); } }
        internal static SDA.DAO.SdaProvince.SdaProvinceDAO SdaProvinceDAO { get { return (SDA.DAO.SdaProvince.SdaProvinceDAO)Worker.Get<SDA.DAO.SdaProvince.SdaProvinceDAO>(); } }
        internal static SDA.DAO.SdaReligion.SdaReligionDAO SdaReligionDAO { get { return (SDA.DAO.SdaReligion.SdaReligionDAO)Worker.Get<SDA.DAO.SdaReligion.SdaReligionDAO>(); } }
        internal static SDA.DAO.SdaTranslate.SdaTranslateDAO SdaTranslateDAO { get { return (SDA.DAO.SdaTranslate.SdaTranslateDAO)Worker.Get<SDA.DAO.SdaTranslate.SdaTranslateDAO>(); } }
        internal static SDA.DAO.SdaTrouble.SdaTroubleDAO SdaTroubleDAO { get { return (SDA.DAO.SdaTrouble.SdaTroubleDAO)Worker.Get<SDA.DAO.SdaTrouble.SdaTroubleDAO>(); } }
        internal static SDA.DAO.SdaModuleField.SdaModuleFieldDAO SdaModuleFieldDAO { get { return (SDA.DAO.SdaModuleField.SdaModuleFieldDAO)Worker.Get<SDA.DAO.SdaModuleField.SdaModuleFieldDAO>(); } }
        internal static SDA.DAO.SdaDeleteData.SdaDeleteDataDAO SdaDeleteDataDAO { get { return (SDA.DAO.SdaDeleteData.SdaDeleteDataDAO)Worker.Get<SDA.DAO.SdaDeleteData.SdaDeleteDataDAO>(); } }
        internal static SDA.DAO.Sql.SqlDAO SqlDAO { get { return (SDA.DAO.Sql.SqlDAO)Worker.Get<SDA.DAO.Sql.SqlDAO>(); } }
        internal static SDA.DAO.SdaHideControl.SdaHideControlDAO SdaHideControlDAO { get { return (SDA.DAO.SdaHideControl.SdaHideControlDAO)Worker.Get<SDA.DAO.SdaHideControl.SdaHideControlDAO>(); } }
        internal static SDA.DAO.SdaCustomizeButton.SdaCustomizeButtonDAO SdaCustomizeButtonDAO { get { return (SDA.DAO.SdaCustomizeButton.SdaCustomizeButtonDAO)Worker.Get<SDA.DAO.SdaCustomizeButton.SdaCustomizeButtonDAO>(); } }
        internal static SDA.DAO.SdaCustomizeUi.SdaCustomizeUiDAO SdaCustomizeUiDAO { get { return (SDA.DAO.SdaCustomizeUi.SdaCustomizeUiDAO)Worker.Get<SDA.DAO.SdaCustomizeUi.SdaCustomizeUiDAO>(); } }
        internal static SDA.DAO.SdaMetadata.SdaMetadataDAO SdaMetadataDAO { get { return (SDA.DAO.SdaMetadata.SdaMetadataDAO)Worker.Get<SDA.DAO.SdaMetadata.SdaMetadataDAO>(); } }
        internal static SDA.DAO.SdaSqlParam.SdaSqlParamDAO SdaSqlParamDAO { get { return (SDA.DAO.SdaSqlParam.SdaSqlParamDAO)Worker.Get<SDA.DAO.SdaSqlParam.SdaSqlParamDAO>(); } }
        internal static SDA.DAO.SdaSql.SdaSqlDAO SdaSqlDAO { get { return (SDA.DAO.SdaSql.SdaSqlDAO)Worker.Get<SDA.DAO.SdaSql.SdaSqlDAO>(); } }
        internal static SDA.DAO.SdaCommuneMap.SdaCommuneMapDAO SdaCommuneMapDAO { get { return (SDA.DAO.SdaCommuneMap.SdaCommuneMapDAO)Worker.Get<SDA.DAO.SdaCommuneMap.SdaCommuneMapDAO>(); } }
        internal static SDA.DAO.SdaDistrictMap.SdaDistrictMapDAO SdaDistrictMapDAO { get { return (SDA.DAO.SdaDistrictMap.SdaDistrictMapDAO)Worker.Get<SDA.DAO.SdaDistrictMap.SdaDistrictMapDAO>(); } }
        internal static SDA.DAO.SdaProvinceMap.SdaProvinceMapDAO SdaProvinceMapDAO { get { return (SDA.DAO.SdaProvinceMap.SdaProvinceMapDAO)Worker.Get<SDA.DAO.SdaProvinceMap.SdaProvinceMapDAO>(); } }
    }
}
