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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.Desktop.Plugins.ExpMestDepaCreate.Base
{
    class ResourceMessageLang
    {
        static System.Resources.ResourceManager languageMessage = new System.Resources.ResourceManager("HIS.Desktop.Plugins.ExpMestDepaCreate.Resources.Message.Lang", System.Reflection.Assembly.GetExecutingAssembly());

        internal static string TruongDuLieuBatBuoc
        {
            get
            {
                try
                {
                    return Inventec.Common.Resource.Get.Value("Plugins_ExpMestDepaCreate__TruongDuLieuBatBuoc", languageMessage, Inventec.Desktop.Common.LanguageManager.LanguageManager.GetCulture());
                }
                catch (Exception ex)
                {
                    Inventec.Common.Logging.LogSystem.Error(ex);
                }
                return "";
            }
        }

        internal static string SoLuongXuatPhaiLonHonKhong
        {
            get
            {
                try
                {
                    return Inventec.Common.Resource.Get.Value("Plugins_ExpMestDepaCreate__SoLuongXuatPhaiLonHonKhong", languageMessage, Inventec.Desktop.Common.LanguageManager.LanguageManager.GetCulture());
                }
                catch (Exception ex)
                {
                    Inventec.Common.Logging.LogSystem.Error(ex);
                }
                return "";
            }
        }

        internal static string SoLuongXuatLonHonSoLuonKhaDungTrongKho
        {
            get
            {
                try
                {
                    return Inventec.Common.Resource.Get.Value("Plugins_ExpMestDepaCreate__SoLuongXuatLonHonSoLuonKhaDungTrongKho", languageMessage, Inventec.Desktop.Common.LanguageManager.LanguageManager.GetCulture());
                }
                catch (Exception ex)
                {
                    Inventec.Common.Logging.LogSystem.Error(ex);
                }
                return "";
            }
        }

        internal static string XuLyThatBai
        {
            get
            {
                try
                {
                    return Inventec.Common.Resource.Get.Value("Plugins_ExpMestDepaCreate__XuLyThatBai", languageMessage, Inventec.Desktop.Common.LanguageManager.LanguageManager.GetCulture());
                }
                catch (Exception ex)
                {
                    Inventec.Common.Logging.LogSystem.Error(ex);
                }
                return "";
            }
        }

        internal static string ThuocVatTuDaCoTrongDanhSachXuat_BanCoMuonThayThe
        {
            get
            {
                try
                {
                    return Inventec.Common.Resource.Get.Value("Plugins_ExpMestDepaCreate__ThuocVatTuDaCoTrongDanhSachXuat_BanCoMuonThayThe", languageMessage, Inventec.Desktop.Common.LanguageManager.LanguageManager.GetCulture());
                }
                catch (Exception ex)
                {
                    Inventec.Common.Logging.LogSystem.Error(ex);
                }
                return "";
            }
        }

        internal static string TieuDeCuaSoThongBaoLaThongBao
        {
            get
            {
                try
                {
                    return Inventec.Common.Resource.Get.Value("Plugins_ExpMestDepaCreate__TieuDeCuaSoThongBaoLaThongBao", languageMessage, Inventec.Desktop.Common.LanguageManager.LanguageManager.GetCulture());
                }
                catch (Exception ex)
                {
                    Inventec.Common.Logging.LogSystem.Error(ex);
                }
                return "";
            }
        }

        internal static string TieuDeCuaSoThongBaoLaCanhBao
        {
            get
            {
                try
                {
                    return Inventec.Common.Resource.Get.Value("Plugins_ExpMestDepaCreate__TieuDeCuaSoThongBaoLaCanhBao", languageMessage, Inventec.Desktop.Common.LanguageManager.LanguageManager.GetCulture());
                }
                catch (Exception ex)
                {
                    Inventec.Common.Logging.LogSystem.Error(ex);
                }
                return "";
            }
        }
    }
}
