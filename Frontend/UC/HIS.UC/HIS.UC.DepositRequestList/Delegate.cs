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
using DevExpress.XtraGrid.Views.Base;
using HIS.UC.DepositRequestList.ADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.UC.DepositRequestList
{
    public delegate void gridViewDeposit_CustomUnboundColumnData(DepositRequestADO data, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e);
    public delegate void gridViewDeposit_CustomDrawCell(DepositRequestADO data, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e);
    public delegate void gridViewDeposit_CustomRowCellEdit(DepositRequestADO data, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e);
    public delegate void gridviewHandler(DepositRequestADO data);
}