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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MOS.EFMODEL.DataModels;
using Inventec.Core;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList.Data;
using System.Collections;
using DevExpress.XtraTreeList;
using DevExpress.Utils.Menu;
using DevExpress.XtraTreeList.Nodes;
using HIS.UC.HisMestPeriodMaterial.ADO;

namespace HIS.UC.HisMestPeriodMaterial.Run
{
    public partial class UCHisMestPeriodMaterial : UserControl
    {
        #region Declare
        HisMestPeriodMaterialInitADO HisMestPeriodMaterialADO;
        BindingList<HisMestPeriodMaterialADO> records;
        List<HisMestPeriodMaterialADO> HisMestPeriodMaterialADOs = new List<HisMestPeriodMaterialADO>();
        List<ColumnButtonEditADO> columnButtonEdits;
        HisMestPeriodMaterial_NodeCellStyle HisMestPeriodMaterialNodeCellStyle;
        HisMestPeriodMaterial_CustomUnboundColumnData HisMestPeriodMaterial_CustomUnboundColumnData;
        HisMestPeriodMaterialHandler HisMestPeriodMaterialClick;
        HisMestPeriodMaterialHandler HisMestPeriodMaterialDoubleClick;
        HisMestPeriodMaterialHandler HisMestPeriodMaterialRowEnter;
        HisMestPeriodMaterial_GetStateImage HisMestPeriodMaterial_GetStateImage;
        HisMestPeriodMaterial_GetSelectImage HisMestPeriodMaterial_GetSelectImage;
        HisMestPeriodMaterialHandler HisMestPeriodMaterial_StateImageClick;
        HisMestPeriodMaterialHandler HisMestPeriodMaterial_SelectImageClick;
        HisMestPeriodMaterial_AfterCheck HisMestPeriodMaterial_AfterCheck;
        HisMestPeriodMaterial_BeforeCheck HisMestPeriodMaterial_BeforeCheck;
        HisMestPeriodMaterial_CheckAllNode HisMestPeriodMaterial_CheckAllNode;
        HisMestPeriodMaterial_CustomDrawNodeCell HisMestPeriodMaterial_CustomDrawNodeCell;
        bool IsShowCheckNode;
        DevExpress.Utils.ImageCollection selectImageCollection;
        DevExpress.Utils.ImageCollection stateImageCollection;
        HisMestPeriodMaterialHandler updateSingleRow;
        MenuItems menuItems;
        const int GroupType__All = 1;
        const int GroupType__Group = 2;
        bool isCreateParentNodeWithHisMestPeriodMaterialExpend = true;
        #endregion

        #region Construct
        public UCHisMestPeriodMaterial(HisMestPeriodMaterialInitADO HisMestPeriodMaterialADO)
        {
            InitializeComponent();
            try
            {
                this.HisMestPeriodMaterialADO = HisMestPeriodMaterialADO;
                this.HisMestPeriodMaterialNodeCellStyle = HisMestPeriodMaterialADO.HisMestPeriodMaterialNodeCellStyle;
                this.HisMestPeriodMaterialClick = HisMestPeriodMaterialADO.HisMestPeriodMaterialClick;
                this.HisMestPeriodMaterialDoubleClick = HisMestPeriodMaterialADO.HisMestPeriodMaterialDoubleClick;
                this.HisMestPeriodMaterialRowEnter = HisMestPeriodMaterialADO.HisMestPeriodMaterialRowEnter;
                this.HisMestPeriodMaterial_GetStateImage = HisMestPeriodMaterialADO.HisMestPeriodMaterial_GetStateImage;
                this.HisMestPeriodMaterial_GetSelectImage = HisMestPeriodMaterialADO.HisMestPeriodMaterial_GetSelectImage;
                this.HisMestPeriodMaterial_StateImageClick = HisMestPeriodMaterialADO.HisMestPeriodMaterial_StateImageClick;
                this.HisMestPeriodMaterial_SelectImageClick = HisMestPeriodMaterialADO.HisMestPeriodMaterial_SelectImageClick;
                this.columnButtonEdits = HisMestPeriodMaterialADO.ColumnButtonEdits;
                this.selectImageCollection = HisMestPeriodMaterialADO.SelectImageCollection;
                this.stateImageCollection = HisMestPeriodMaterialADO.StateImageCollection;
                this.updateSingleRow = HisMestPeriodMaterialADO.UpdateSingleRow;
                this.HisMestPeriodMaterial_CustomUnboundColumnData = HisMestPeriodMaterialADO.HisMestPeriodMaterial_CustomUnboundColumnData;
                this.menuItems = HisMestPeriodMaterialADO.MenuItems;
                this.HisMestPeriodMaterial_AfterCheck = HisMestPeriodMaterialADO.HisMestPeriodMaterial_AfterCheck;
                this.HisMestPeriodMaterial_BeforeCheck = HisMestPeriodMaterialADO.HisMestPeriodMaterial_BeforeCheck;
                this.HisMestPeriodMaterial_CheckAllNode = HisMestPeriodMaterialADO.HisMestPeriodMaterial_CheckAllNode;
                this.HisMestPeriodMaterial_CustomDrawNodeCell = HisMestPeriodMaterialADO.HisMestPeriodMaterial_CustomDrawNodeCell;
                if (HisMestPeriodMaterialADO.IsShowCheckNode.HasValue)
                {
                    this.IsShowCheckNode = HisMestPeriodMaterialADO.IsShowCheckNode.Value;
                }
                if (HisMestPeriodMaterialADO.IsCreateParentNodeWithHisMestPeriodMaterialExpend.HasValue)
                {
                    this.isCreateParentNodeWithHisMestPeriodMaterialExpend = HisMestPeriodMaterialADO.IsCreateParentNodeWithHisMestPeriodMaterialExpend.Value;
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }
        #endregion

        #region Private method
        private void UCServiceTree_Load(object sender, EventArgs e)
        {
            try
            {
                if (HisMestPeriodMaterialADO != null)
                {
                    InitializeTree();
                    BindTreePlus();
                    if (this.stateImageCollection != null)
                    {
                        trvService.StateImageList = this.stateImageCollection;
                    }
                    if (this.selectImageCollection != null)
                    {
                        trvService.SelectImageList = this.selectImageCollection;
                    }
                    SetVisibleSearchPanel();
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void BindTreePlus()
        {
            try
            {
                HisMestPeriodMaterialADOs = new List<HisMestPeriodMaterialADO>();
                if (HisMestPeriodMaterialADO.HisMestPeriodMaterials != null)
                {
                    HisMestPeriodMaterialADOs = (from r in HisMestPeriodMaterialADO.HisMestPeriodMaterials select new HisMestPeriodMaterialADO(r)).ToList();
                    // HisMestPeriodMaterialADOs = HisMestPeriodMaterialADOs.OrderBy(o => o.NUM_ORDER).ThenBy(o => o.BLOOD_TYPE_NAME).ToList();
                }
                records = new BindingList<HisMestPeriodMaterialADO>(HisMestPeriodMaterialADOs);
                trvService.DataSource = records;
                trvService.ExpandAll();
                if (this.HisMestPeriodMaterial_CheckAllNode != null)
                    this.HisMestPeriodMaterial_CheckAllNode(trvService.Nodes);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void InitializeTree()
        {
            try
            {
                this.trvService.OptionsView.ShowCheckBoxes = this.IsShowCheckNode;
                if (HisMestPeriodMaterialADO.HisMestPeriodMaterialColumns != null && HisMestPeriodMaterialADO.HisMestPeriodMaterialColumns.Count > 0)
                {
                    foreach (var svtr in HisMestPeriodMaterialADO.HisMestPeriodMaterialColumns)
                    {
                        TreeListColumn col = this.trvService.Columns.AddField(svtr.FieldName);
                        col.Visible = svtr.Visible;
                        col.VisibleIndex = svtr.VisibleIndex;
                        col.Width = svtr.ColumnWidth;
                        col.FieldName = svtr.FieldName;
                        col.OptionsColumn.AllowEdit = svtr.AllowEdit;
                        col.Caption = svtr.Caption;
                        if (svtr.UnboundColumnType != null && svtr.UnboundColumnType != UnboundColumnType.Bound)
                            col.UnboundType = svtr.UnboundColumnType;
                        if (svtr.Format != null)
                        {
                            col.Format.FormatString = svtr.Format.FormatString;
                            col.Format.FormatType = svtr.Format.FormatType;
                        }
                    }
                }
                if (HisMestPeriodMaterialADO.ColumnButtonEdits != null && HisMestPeriodMaterialADO.ColumnButtonEdits.Count > 0)
                {
                    foreach (var svtr in HisMestPeriodMaterialADO.ColumnButtonEdits)
                    {
                        RepositoryItemButtonEdit buttonEdit = new RepositoryItemButtonEdit();
                        buttonEdit.AutoHeight = false;
                        buttonEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
                        DevExpress.Utils.SuperToolTip superToolTip = new DevExpress.Utils.SuperToolTip();
                        superToolTip.Items.Add(new DevExpress.Utils.ToolTipItem());
                        buttonEdit.Tag = svtr.ActionHandler;
                        buttonEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph,svtr.Image,superToolTip)});
                        buttonEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(RepositoryItemButtonClick);
                        DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn = new DevExpress.XtraTreeList.Columns.TreeListColumn();

                        treeListColumn.ColumnEdit = buttonEdit;
                        treeListColumn.Width = 20;
                        treeListColumn.ToolTip = svtr.Tooltip;
                        treeListColumn.VisibleIndex = svtr.VisibleIndex;
                        treeListColumn.Caption = svtr.Caption;
                        treeListColumn.ImageAlignment = StringAlignment.Center;
                        trvService.Columns.Add(treeListColumn);
                    }
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void SetVisibleSearchPanel()
        {
            try
            {
                if (HisMestPeriodMaterialADO.IsShowSearchPanel.HasValue)
                {
                    lciKeyword.Visibility = (HisMestPeriodMaterialADO.IsShowSearchPanel.Value ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never);
                }
                if (HisMestPeriodMaterialADO.IsShowButtonAdd.HasValue)
                {
                    lciHisMestPeriodMaterialAdd.Visibility = (HisMestPeriodMaterialADO.IsShowButtonAdd.Value ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never);
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void txtKeyword_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                string strValue = (sender as DevExpress.XtraEditors.TextEdit).Text;
                SearchClick(strValue);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void SearchClick(string keyword)
        {
            try
            {
                BindingList<HisMestPeriodMaterialADO> listResult = null;
                if (!String.IsNullOrEmpty(keyword.Trim()))
                {
                    List<HisMestPeriodMaterialADO> rearchResult = new List<HisMestPeriodMaterialADO>();

                    rearchResult = HisMestPeriodMaterialADOs.Where(o =>
                                                    ((o.MATERIAL_TYPE_NAME ?? "").ToString().ToLower().Contains(keyword.Trim().ToLower())
                                                    || (o.MATERIAL_TYPE_CODE ?? "").ToString().ToLower().Contains(keyword.Trim().ToLower())
                                                        //|| (o.HEIN_SERVICE_BHYT_NAME ?? "").ToString().ToLower().Contains(keyword.Trim().ToLower())
                                                    || (o.SERVICE_UNIT_NAME ?? "").ToString().ToLower().Contains(keyword.Trim().ToLower())
                                                    )
                                                    ).Distinct().ToList();

                    listResult = new BindingList<HisMestPeriodMaterialADO>(rearchResult);
                }
                else
                {
                    listResult = new BindingList<HisMestPeriodMaterialADO>(HisMestPeriodMaterialADOs);
                }
                trvService.DataSource = listResult;
                trvService.ExpandAll();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Search();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        #endregion

        #region Public method
        public void Search()
        {
            try
            {
                SearchClick(txtKeyword.Text.Trim());
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        public void Reload(List<MOS.EFMODEL.DataModels.V_HIS_MEST_PERIOD_MATY> HisMestPeriodMaterials)
        {
            try
            {
                txtKeyword.Text = "";
                this.HisMestPeriodMaterialADO.HisMestPeriodMaterials = HisMestPeriodMaterials;
                if (this.HisMestPeriodMaterialADO.HisMestPeriodMaterials == null)
                    records = null;
                BindTreePlus();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }
        #endregion

        private void trvService_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            try
            {
                var data = (HisMestPeriodMaterialADO)trvService.GetDataRecordByNode(e.Node);
                if (HisMestPeriodMaterialNodeCellStyle != null && HisMestPeriodMaterialADO != null)
                {
                    HisMestPeriodMaterialNodeCellStyle(data, e);
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void trvService_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    var node = trvService.FocusedNode;
                    var data = trvService.GetDataRecordByNode(node);
                    if (node != null && data != null && data is HisMestPeriodMaterialADO)
                    {
                        if (HisMestPeriodMaterialRowEnter != null)
                        {
                            HisMestPeriodMaterialRowEnter((HisMestPeriodMaterialADO)data);
                        }
                        else
                        {
                            txtKeyword.Focus();
                            txtKeyword.SelectAll();
                        }
                    }
                    else
                    {
                        txtKeyword.Focus();
                        txtKeyword.SelectAll();
                    }
                }
                else if (e.KeyCode == Keys.Space)
                {
                    var node = trvService.FocusedNode;
                    var data = trvService.GetDataRecordByNode(node);
                    if (node != null && node.HasChildren && data != null && data is HisMestPeriodMaterialADO)
                    {
                        node.Expanded = !node.Expanded;
                    }
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void trvService_BeforeCheckNode(object sender, DevExpress.XtraTreeList.CheckNodeEventArgs e)
        {
            try
            {
                e.State = (e.PrevState == CheckState.Checked ? CheckState.Unchecked : CheckState.Checked);
                TreeListNode node = e.Node;
                if (this.HisMestPeriodMaterial_BeforeCheck != null)
                    this.HisMestPeriodMaterial_BeforeCheck(node);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void trvService_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            try
            {
                if (this.HisMestPeriodMaterial_AfterCheck == null)
                    return;
                var row = trvService.GetDataRecordByNode(e.Node);
                if (row != null && row is HisMestPeriodMaterialADO)
                {
                    HisMestPeriodMaterial_AfterCheck(e.Node, (HisMestPeriodMaterialADO)row);
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void RepositoryItemButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (sender != null && sender is DevExpress.XtraEditors.ButtonEdit)
                {
                    var btn = sender as DevExpress.XtraEditors.ButtonEdit;
                    if (btn.Tag != null)
                    {
                        HisMestPeriodMaterialHandler clickhandler = btn.Tag as HisMestPeriodMaterialHandler;
                        if (clickhandler != null)
                        {
                            var data = trvService.GetDataRecordByNode(trvService.FocusedNode);
                            if (data != null && data is HisMestPeriodMaterialADO)
                            {
                                clickhandler((HisMestPeriodMaterialADO)data);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void trvService_GetSelectImage(object sender, DevExpress.XtraTreeList.GetSelectImageEventArgs e)
        {
            try
            {
                var data = trvService.GetDataRecordByNode(e.Node);
                if (data != null && data is HisMestPeriodMaterialADO)
                {
                    if (this.HisMestPeriodMaterial_GetSelectImage != null)
                        this.HisMestPeriodMaterial_GetSelectImage((HisMestPeriodMaterialADO)data, e);
                    else
                        e.NodeImageIndex = -1;
                }
                else
                {
                    e.NodeImageIndex = -1;
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void trvService_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {
            try
            {
                var data = trvService.GetDataRecordByNode(e.Node);
                if (data != null && data is HisMestPeriodMaterialADO)
                {
                    if (this.HisMestPeriodMaterial_GetStateImage != null)
                        this.HisMestPeriodMaterial_GetStateImage((HisMestPeriodMaterialADO)data, e);
                    else
                        e.NodeImageIndex = -1;
                }
                else
                {
                    e.NodeImageIndex = -1;
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void trvService_SelectImageClick(object sender, DevExpress.XtraTreeList.NodeClickEventArgs e)
        {
            try
            {
                var data = trvService.GetDataRecordByNode(e.Node);
                if (data != null && data is HisMestPeriodMaterialADO)
                {
                    if (this.HisMestPeriodMaterial_SelectImageClick != null)
                        this.HisMestPeriodMaterial_SelectImageClick((HisMestPeriodMaterialADO)data);
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void trvService_StateImageClick(object sender, DevExpress.XtraTreeList.NodeClickEventArgs e)
        {
            try
            {
                var data = trvService.GetDataRecordByNode(e.Node);
                if (data != null && data is HisMestPeriodMaterialADO)
                {
                    if (this.HisMestPeriodMaterial_StateImageClick != null)
                        this.HisMestPeriodMaterial_StateImageClick((HisMestPeriodMaterialADO)data);
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void trvService_CustomUnboundColumnData(object sender, DevExpress.XtraTreeList.TreeListCustomColumnDataEventArgs e)
        {
            try
            {
                if (e.IsGetData)
                {
                    HisMestPeriodMaterialADO currentRow = e.Row as HisMestPeriodMaterialADO;
                    if (currentRow == null || this.HisMestPeriodMaterial_CustomUnboundColumnData == null) return;
                    this.HisMestPeriodMaterial_CustomUnboundColumnData(currentRow, e);
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void trvService_CustomNodeCellEdit(object sender, DevExpress.XtraTreeList.GetCustomNodeCellEditEventArgs e)
        {
            try
            {
                var data = trvService.GetDataRecordByNode(e.Node);
                if (data != null && data is HisMestPeriodMaterialADO)
                {
                    var rowData = data as HisMestPeriodMaterialADO;

                    if (e.Column.FieldName == "IsLeaf")
                    {
                        if (this.updateSingleRow != null)
                        {
                            e.RepositoryItem = repositoryItemchkIsExpend__Enable;
                        }
                        else
                        {
                            e.RepositoryItem = repositoryItemchkIsExpend__Disable;
                        }

                        //if (rowData != null && rowData.IS_LEAF == IMSys.DbConfig.HIS_RS.HIS_BLOOD_TYPE.IS_LEAF__TRUE)
                        //{
                        //    rowData.IsLeaf = true;
                        //}
                        //else
                        //{
                        //    rowData.IsLeaf = false;
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void repositoryItemchkIsExpend__Enable_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                var data = trvService.GetDataRecordByNode(trvService.FocusedNode);
                if (data != null && data is HisMestPeriodMaterialADO)
                {
                    var rowData = data as HisMestPeriodMaterialADO;
                    //if (rowData.IsLeaf != null && rowData.IsLeaf.Value)
                    //    rowData.IS_LEAF = IMSys.DbConfig.HIS_RS.HIS_BLOOD_TYPE.IS_LEAF__TRUE;
                    //else
                    //    rowData.IS_LEAF = null;
                    if (this.updateSingleRow != null)
                    {
                        updateSingleRow(rowData);
                    }
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void trvService_PopupMenuShowing(object sender, DevExpress.XtraTreeList.PopupMenuShowingEventArgs e)
        {
            try
            {
                if (this.menuItems != null)
                {
                    TreeList tree = sender as TreeList;
                    if (tree != null)
                    {
                        Point pt = tree.PointToClient(MousePosition);
                        TreeListHitInfo hitInfo = tree.CalcHitInfo(e.Point);
                        if (hitInfo != null && (hitInfo.HitInfoType == HitInfoType.Row
                            || hitInfo.HitInfoType == HitInfoType.Cell))
                        {
                            e.Menu.Items.Clear();
                            tree.FocusedNode = hitInfo.Node;
                            var data = trvService.GetDataRecordByNode(hitInfo.Node);
                            if (data != null && data is HisMestPeriodMaterialADO)
                            {
                                foreach (var menu in this.menuItems((HisMestPeriodMaterialADO)data))
                                {
                                    e.Menu.Items.Add(menu);
                                }
                                e.Menu.Show(pt);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void clearAllMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                TreeListColumn clickedColumn = (sender as DXMenuItem).Tag as TreeListColumn;
                if (clickedColumn == null) return;
                TreeList tl = clickedColumn.TreeList;
                foreach (TreeListColumn column in tl.Columns)
                    column.SummaryFooter = SummaryItemType.None;
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void trvService_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
            try
            {
                var data = trvService.GetDataRecordByNode(e.Node);
                if (data != null && data is HisMestPeriodMaterialADO)
                {
                    var rowData = data as HisMestPeriodMaterialADO;
                    if (rowData != null && this.HisMestPeriodMaterial_CustomDrawNodeCell != null)
                    {
                        this.HisMestPeriodMaterial_CustomDrawNodeCell(rowData, e);
                    }
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        public List<HisMestPeriodMaterialADO> GetListCheck()
        {
            List<HisMestPeriodMaterialADO> result = new List<HisMestPeriodMaterialADO>();
            try
            {
                foreach (TreeListNode node in trvService.Nodes)
                {
                    GetListNodeCheck(ref result, node);
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
                result = new List<HisMestPeriodMaterialADO>();
            }
            return result;
        }

        private void GetListNodeCheck(ref List<HisMestPeriodMaterialADO> result, TreeListNode node)
        {
            try
            {
                if (node.Nodes == null || node.Nodes.Count == 0)
                {
                    if (node.Checked)
                    {
                        result.Add((HisMestPeriodMaterialADO)trvService.GetDataRecordByNode(node));
                    }
                }
                else
                {
                    foreach (TreeListNode child in node.Nodes)
                    {
                        GetListNodeCheck(ref result, child);
                    }
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void trvService_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                TreeList tree = sender as TreeList;
                TreeListHitInfo hi = tree.CalcHitInfo(tree.PointToClient(Control.MousePosition));
                if (hi.Node != null)
                {
                    HisMestPeriodMaterialADO HisMestPeriodMaterialFocus = (HisMestPeriodMaterialADO)trvService.GetDataRecordByNode(hi.Node);
                    if (HisMestPeriodMaterialFocus != null && HisMestPeriodMaterialDoubleClick != null)
                    {
                        HisMestPeriodMaterialDoubleClick(HisMestPeriodMaterialFocus);
                    }
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void trvService_Click(object sender, EventArgs e)
        {
            try
            {
                TreeList tree = sender as TreeList;
                TreeListHitInfo hi = tree.CalcHitInfo(tree.PointToClient(Control.MousePosition));
                if (hi.Node != null)
                {
                    HisMestPeriodMaterialADO HisMestPeriodMaterialFocus = (HisMestPeriodMaterialADO)trvService.GetDataRecordByNode(hi.Node);
                    if (HisMestPeriodMaterialFocus != null && this.HisMestPeriodMaterialClick != null)
                    {
                        this.HisMestPeriodMaterialClick(HisMestPeriodMaterialFocus);
                    }
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {

        }
    }
}
