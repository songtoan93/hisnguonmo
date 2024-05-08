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

namespace ACS.EFMODEL.DataModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class ACS_MODULE
    {
        public ACS_MODULE()
        {
            this.ACS_MODULE_ROLE = new HashSet<ACS_MODULE_ROLE>();
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
        public string MODULE_NAME { get; set; }
        public string MODULE_LINK { get; set; }
        public Nullable<short> IS_VISIBLE { get; set; }
        public Nullable<long> NUM_ORDER { get; set; }
        public Nullable<short> IS_LEAF { get; set; }
        public Nullable<long> PARENT_ID { get; set; }
        public long APPLICATION_ID { get; set; }
        public Nullable<long> MODULE_GROUP_ID { get; set; }
        public string ICON_LINK { get; set; }
        public Nullable<short> IS_ANONYMOUS { get; set; }
        public string MODULE_URL { get; set; }
        public string VIR_MODULE_LINK { get; set; }
        public string VIDEO_URLS { get; set; }
        public Nullable<short> IS_NOT_SHOW_DIALOG { get; set; }
    
        public virtual ACS_APPLICATION ACS_APPLICATION { get; set; }
        public virtual ACS_MODULE_GROUP ACS_MODULE_GROUP { get; set; }
        public virtual ICollection<ACS_MODULE_ROLE> ACS_MODULE_ROLE { get; set; }
    }
}
