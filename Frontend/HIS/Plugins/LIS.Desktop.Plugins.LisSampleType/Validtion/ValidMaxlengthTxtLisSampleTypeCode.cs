using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIS.Desktop.Plugins.LisSampleType.Validtion
{
    /* IVT
     * @Project : hisnguonmo
     * @Author : INVENTEC
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
    class ValidMaxlengthTxtLisSampleTypeCode : DevExpress.XtraEditors.DXErrorProvider.ValidationRule
    {
        internal DevExpress.XtraEditors.TextEdit txtLisSampleTypeCode;
        public override bool Validate(System.Windows.Forms.Control control, object value)
        {
            bool valid = false;
            try
            {
                if (string.IsNullOrEmpty(txtLisSampleTypeCode.Text) )
                {
                    this.ErrorText = HIS.Desktop.LibraryMessage.MessageUtil.GetMessage(HIS.Desktop.LibraryMessage.Message.Enum.TruongDuLieuBatBuoc);
                    return valid;
                }
                else
                {
                    if (Inventec.Common.String.CountVi.Count(txtLisSampleTypeCode.Text) > 6 )
                    {
                        this.ErrorText = "Độ dài mã vượt quá " + 6 ;
                        return valid;
                    }
                    else
                    {
                        if (Inventec.Common.String.CountVi.Count(txtLisSampleTypeCode.Text) > 6)
                        {
                            this.ErrorText = "Độ dài mã vượt quá " + 6;
                            return valid;
                        }
                        
                        else
                            valid = true;
                    }
                    

                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
            return valid;
        }
    }
}
