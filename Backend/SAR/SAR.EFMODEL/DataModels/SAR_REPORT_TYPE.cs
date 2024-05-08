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
    
    public partial class SAR_REPORT_TYPE
    {
        public SAR_REPORT_TYPE()
        {
            this.SAR_REPORT = new HashSet<SAR_REPORT>();
            this.SAR_REPORT_TEMPLATE = new HashSet<SAR_REPORT_TEMPLATE>();
            this.SAR_RETY_FOFI = new HashSet<SAR_RETY_FOFI>();
            this.SAR_USER_REPORT_TYPE = new HashSet<SAR_USER_REPORT_TYPE>();
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
        public string REPORT_TYPE_CODE { get; set; }
        public string REPORT_TYPE_NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public Nullable<long> REPORT_TYPE_GROUP_ID { get; set; }
        public Nullable<short> IS_IMPORTANCE { get; set; }
        public string HOUR_FROM { get; set; }
        public string HOUR_TO { get; set; }
        public byte[] SQL { get; set; }
        public string DLL_CODE { get; set; }
    
        public virtual ICollection<SAR_REPORT> SAR_REPORT { get; set; }
        public virtual ICollection<SAR_REPORT_TEMPLATE> SAR_REPORT_TEMPLATE { get; set; }
        public virtual SAR_REPORT_TYPE_GROUP SAR_REPORT_TYPE_GROUP { get; set; }
        public virtual ICollection<SAR_RETY_FOFI> SAR_RETY_FOFI { get; set; }
        public virtual ICollection<SAR_USER_REPORT_TYPE> SAR_USER_REPORT_TYPE { get; set; }
    }
}
