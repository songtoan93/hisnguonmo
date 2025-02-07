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
//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SAR.EFMODEL.DataModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class SAR_PRINT_TYPE
    {
        public SAR_PRINT_TYPE()
        {
            this.SAR_PRINT = new HashSet<SAR_PRINT>();
            this.SAR_PRINT_TYPE_CFG = new HashSet<SAR_PRINT_TYPE_CFG>();
        }
    
        public long ID { get; set; }
        public Nullable<long> CREATE_TIME { get; set; }
        public Nullable<long> MODIFY_TIME { get; set; }
        public string CREATOR { get; set; }
        public string MODIFIER { get; set; }
        public string APP_CREATOR { get; set; }
        public string APP_MODIFIER { get; set; }
        public Nullable<short> IS_ACTIVE { get; set; }
        public Nullable<short> IS_DELETE { get; set; }
        public string GROUP_CODE { get; set; }
        public string PRINT_TYPE_CODE { get; set; }
        public string FILE_PATTERN { get; set; }
        public string PRINT_TYPE_NAME { get; set; }
        public Nullable<short> IS_NO_GROUP { get; set; }
        public Nullable<short> IS_PRINT_LOG { get; set; }
        public string EMR_DOCUMENT_TYPE_CODE { get; set; }
        public Nullable<short> IS_AUTO_CHOOSE_BUSINESS { get; set; }
        public string BUSINESS_CODES { get; set; }
        public Nullable<short> DO_NOT_ALLOW_REPRINT { get; set; }
        public string REPRINT_EXCEPTION_LOGINNAME { get; set; }
        public Nullable<short> IS_DIGITAL_SIGN { get; set; }
        public Nullable<short> IS_SINGLE_COPY { get; set; }
        public Nullable<short> DO_NOT_ALLOW_PRINT { get; set; }
        public string PRINT_EXCEPTION_LOGINNAME { get; set; }
        public Nullable<short> PRINT_LOG_ENABLE { get; set; }
        public string EMR_COLUMN_MAPPING { get; set; }
        public string DISABLE_PRINT_BY_KEY_CFG { get; set; }
        public string GEN_SIGNATURE_BY_KEY_CFG { get; set; }
        public Nullable<short> GEN_SIGNATURE_ENABLE { get; set; }
        public string EMR_DOCUMENT_GROUP_CODE { get; set; }
        public Nullable<short> IS_ALLOW_ATTACH_PRINT { get; set; }
        public Nullable<short> IS_PRINT_EXCEPTION_REASON { get; set; }
        public string NUM_COPY_BY_KEY_CFG { get; set; }
    
        public virtual ICollection<SAR_PRINT> SAR_PRINT { get; set; }
        public virtual ICollection<SAR_PRINT_TYPE_CFG> SAR_PRINT_TYPE_CFG { get; set; }
    }
}
