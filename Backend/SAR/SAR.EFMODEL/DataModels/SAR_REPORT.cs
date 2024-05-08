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
    
    public partial class SAR_REPORT
    {
        public SAR_REPORT()
        {
            this.SAR_REPORT_CALENDAR = new HashSet<SAR_REPORT_CALENDAR>();
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
        public string REPORT_CODE { get; set; }
        public string REPORT_NAME { get; set; }
        public long REPORT_TYPE_ID { get; set; }
        public long REPORT_STT_ID { get; set; }
        public Nullable<long> REPORT_TEMPLATE_ID { get; set; }
        public Nullable<short> IS_PUBLIC { get; set; }
        public string REPORT_URL { get; set; }
        public Nullable<short> IS_URL_ERROR { get; set; }
        public string DESCRIPTION { get; set; }
        public Nullable<long> START_TIME { get; set; }
        public Nullable<long> FINISH_QUERY_TIME { get; set; }
        public Nullable<long> START_PREPARE_DATA_TIME { get; set; }
        public Nullable<long> FINISH_PREPARE_DATA_TIME { get; set; }
        public Nullable<long> START_GENERATE_FILE_TIME { get; set; }
        public Nullable<long> FINISH_TIME { get; set; }
        public string JSON_FILTER { get; set; }
        public string JSON_READER { get; set; }
        public Nullable<decimal> VIR_TOTAL_TIME { get; set; }
        public Nullable<decimal> VIR_QUERY_TIME { get; set; }
        public Nullable<decimal> VIR_PREPARE_DATA_TIME { get; set; }
        public Nullable<decimal> VIR_GENERATE_FILE_TIME { get; set; }
        public string REPORT_URL_PDF { get; set; }
        public string ERROR { get; set; }
        public Nullable<short> IS_REFERENCE_TESTING { get; set; }
    
        public virtual ICollection<SAR_REPORT_CALENDAR> SAR_REPORT_CALENDAR { get; set; }
        public virtual SAR_REPORT_STT SAR_REPORT_STT { get; set; }
        public virtual SAR_REPORT_TYPE SAR_REPORT_TYPE { get; set; }
        public virtual SAR_REPORT_TEMPLATE SAR_REPORT_TEMPLATE { get; set; }
    }
}