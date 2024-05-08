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
using HTC.EFMODEL.DataModels;
using HIS.Desktop.ApiConsumer;
using HTC.Filter;
using HIS.Desktop.Plugins.ExpenseTypeList.ADO;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ViewInfo;
using HIS.Desktop.Plugins.ExpenseTypeList.Validation;
using Inventec.Desktop.Common.Message;
using Inventec.Core;
using DevExpress.XtraTreeList;
using System.Resources;
using Inventec.Desktop.Common.LanguageManager;

namespace HIS.Desktop.Plugins.ExpenseTypeList
{
    public partial class UCExpenseTypeList : HIS.Desktop.Utility.UserControlBase
    {
        private int positionHandleControl = -1;

        List<HTC_EXPENSE_TYPE> listExpenseType = null;

        ExpenseTypeADO currentAdo = null;

        public UCExpenseTypeList()
        {
            InitializeComponent();
        }

        private void UCExpenseTypeList_Load(object sender, EventArgs e)
        {
            try
            {
                WaitingManager.Show();
                ValidControl();
                LoadDataToComboParent();
                FillDataToTreeList();
                SetDataSourceFoCboParent();
                ResetCommonValue();
                SetValueControl();
                SetCaptionByLanguageKey();
                WaitingManager.Hide();
            }
            catch (Exception ex)
            {
                WaitingManager.Hide();
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }
        private void SetCaptionByLanguageKey()
        {
            try
            {
                ////Khoi tao doi tuong resource
                Resources.ResourceLanguageManager.LanguageResource = new ResourceManager("Plugins.Resources.Lang", typeof(HIS.Desktop.Plugins.ExpenseTypeList.UCExpenseTypeList).Assembly);

                ////Gan gia tri cho cac control editor co Text/Caption/ToolTip/NullText/NullValuePrompt/FindNullPrompt
                this.layoutControl1.Text = Inventec.Common.Resource.Get.Value("UCExpenseTypeList.layoutControl1.Text", Resources.ResourceLanguageManager.LanguageResource, LanguageManager.GetCulture());
                this.btnNew.Text = Inventec.Common.Resource.Get.Value("UCExpenseTypeList.btnNew.Text", Resources.ResourceLanguageManager.LanguageResource, LanguageManager.GetCulture());
                this.btnEdit.Text = Inventec.Common.Resource.Get.Value("UCExpenseTypeList.btnEdit.Text", Resources.ResourceLanguageManager.LanguageResource, LanguageManager.GetCulture());
                this.btnAdd.Text = Inventec.Common.Resource.Get.Value("UCExpenseTypeList.btnAdd.Text", Resources.ResourceLanguageManager.LanguageResource, LanguageManager.GetCulture());
                this.checkIsPlus.Properties.Caption = Inventec.Common.Resource.Get.Value("UCExpenseTypeList.checkIsPlus.Properties.Caption", Resources.ResourceLanguageManager.LanguageResource, LanguageManager.GetCulture());
                this.checkAllowExpense.Properties.Caption = Inventec.Common.Resource.Get.Value("UCExpenseTypeList.checkAllowExpense.Properties.Caption", Resources.ResourceLanguageManager.LanguageResource, LanguageManager.GetCulture());
                this.cboParent.Properties.NullText = Inventec.Common.Resource.Get.Value("UCExpenseTypeList.cboParent.Properties.NullText", Resources.ResourceLanguageManager.LanguageResource, LanguageManager.GetCulture());
                this.treeListColumn1.Caption = Inventec.Common.Resource.Get.Value("UCExpenseTypeList.treeListColumn1.Caption", Resources.ResourceLanguageManager.LanguageResource, LanguageManager.GetCulture());
                this.treeListColumn2.Caption = Inventec.Common.Resource.Get.Value("UCExpenseTypeList.treeListColumn2.Caption", Resources.ResourceLanguageManager.LanguageResource, LanguageManager.GetCulture());
                this.treeListColumn3.Caption = Inventec.Common.Resource.Get.Value("UCExpenseTypeList.treeListColumn3.Caption", Resources.ResourceLanguageManager.LanguageResource, LanguageManager.GetCulture());
                this.treeListColumn4.Caption = Inventec.Common.Resource.Get.Value("UCExpenseTypeList.treeListColumn4.Caption", Resources.ResourceLanguageManager.LanguageResource, LanguageManager.GetCulture());
                this.treeListColumn5.Caption = Inventec.Common.Resource.Get.Value("UCExpenseTypeList.treeListColumn5.Caption", Resources.ResourceLanguageManager.LanguageResource, LanguageManager.GetCulture());
                this.treeListColumn6.Caption = Inventec.Common.Resource.Get.Value("UCExpenseTypeList.treeListColumn6.Caption", Resources.ResourceLanguageManager.LanguageResource, LanguageManager.GetCulture());
                this.treeListColumn7.Caption = Inventec.Common.Resource.Get.Value("UCExpenseTypeList.treeListColumn7.Caption", Resources.ResourceLanguageManager.LanguageResource, LanguageManager.GetCulture());
                this.treeListColumn8.Caption = Inventec.Common.Resource.Get.Value("UCExpenseTypeList.treeListColumn8.Caption", Resources.ResourceLanguageManager.LanguageResource, LanguageManager.GetCulture());
                this.layoutExpenseTypeCode.Text = Inventec.Common.Resource.Get.Value("UCExpenseTypeList.layoutExpenseTypeCode.Text", Resources.ResourceLanguageManager.LanguageResource, LanguageManager.GetCulture());
                this.layoutExpenseTypeName.Text = Inventec.Common.Resource.Get.Value("UCExpenseTypeList.layoutExpenseTypeName.Text", Resources.ResourceLanguageManager.LanguageResource, LanguageManager.GetCulture());
                this.layoutParent.Text = Inventec.Common.Resource.Get.Value("UCExpenseTypeList.layoutParent.Text", Resources.ResourceLanguageManager.LanguageResource, LanguageManager.GetCulture());
                this.layoutControlItem6.Text = Inventec.Common.Resource.Get.Value("UCExpenseTypeList.layoutControlItem6.Text", Resources.ResourceLanguageManager.LanguageResource, LanguageManager.GetCulture());
                this.layoutControlItem7.Text = Inventec.Common.Resource.Get.Value("UCExpenseTypeList.layoutControlItem7.Text", Resources.ResourceLanguageManager.LanguageResource, LanguageManager.GetCulture());
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }


        private void FillDataToTreeList()
        {
            try
            {
                List<ExpenseTypeADO> listAdo = new List<ExpenseTypeADO>();
                BindingList<ExpenseTypeADO> records = null;
                listExpenseType = new Inventec.Common.Adapter.BackendAdapter(new Inventec.Core.CommonParam()).Get<List<HTC_EXPENSE_TYPE>>(HtcRequestUriStore.HTC_EXPENSE_TYPE__GET, ApiConsumers.HtcConsumer, new HtcExpenseTypeFilter(), null);
                if (listExpenseType != null && listExpenseType.Count > 0)
                {
                    listAdo = (from r in listExpenseType select new ExpenseTypeADO(r)).OrderBy(o => o.ID).ToList();
                    records = new BindingList<ExpenseTypeADO>(listAdo);
                }
                treeListExpenseType.DataSource = records;
                treeListExpenseType.ExpandAll();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void LoadDataToComboParent()
        {
            try
            {
                cboParent.Properties.DataSource = null;
                cboParent.Properties.DisplayMember = "EXPENSE_TYPE_NAME";
                cboParent.Properties.ValueMember = "ID";
                cboParent.Properties.ForceInitialize();
                cboParent.Properties.Columns.Clear();
                cboParent.Properties.Columns.Add(new LookUpColumnInfo("EXPENSE_TYPE_CODE", "Mã", 50));
                cboParent.Properties.Columns.Add(new LookUpColumnInfo("EXPENSE_TYPE_NAME", "Tên", 200));
                cboParent.Properties.ShowHeader = true;
                cboParent.Properties.ImmediatePopup = true;
                cboParent.Properties.DropDownRows = 10;
                cboParent.Properties.PopupWidth = 250;
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        private void SetDataSourceFoCboParent()
        {
            try
            {
                cboParent.Properties.DataSource = listExpenseType;
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void ResetCommonValue()
        {
            try
            {
                this.currentAdo = null;
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void SetValueControl()
        {
            try
            {
                if (this.currentAdo != null)
                {
                    txtExpenseTypeCode.Text = this.currentAdo.EXPENSE_TYPE_CODE;
                    txtExpenseTypeName.Text = this.currentAdo.EXPENSE_TYPE_NAME;
                    if (this.currentAdo.PARENT_ID.HasValue)
                    {
                        cboParent.EditValue = this.currentAdo.PARENT_ID.Value;
                        txtParentCode.Text = this.currentAdo.EXPENSE_TYPE_CODE;
                    }
                    else
                    {
                        cboParent.EditValue = null;
                        txtParentCode.Text = "";
                    }
                    if (this.currentAdo.AllowCreateExpense)
                    {
                        checkAllowExpense.Checked = true;
                    }
                    else
                    {
                        checkAllowExpense.Checked = false;
                    }
                    if (this.currentAdo.IsPlus)
                    {
                        checkIsPlus.Checked = true;
                    }
                    else
                    {
                        checkIsPlus.Checked = false;
                    }
                    btnAdd.Enabled = false;
                    btnEdit.Enabled = true;
                }
                else
                {
                    txtExpenseTypeCode.Text = "";
                    txtExpenseTypeName.Text = "";
                    cboParent.EditValue = null;
                    txtParentCode.Text = "";
                    checkAllowExpense.Checked = false;
                    checkIsPlus.Checked = false;
                    btnAdd.Enabled = true;
                    btnEdit.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void ValidControl()
        {
            try
            {
                ValidControlExpenseTypeCode();
                ValidControlExpenseTypeName();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void ValidControlExpenseTypeCode()
        {
            try
            {
                ExpenseTypeCodeValidationRule codeRule = new ExpenseTypeCodeValidationRule();
                codeRule.txtExpenseTypeCode = txtExpenseTypeCode;
                dxValidationProvider1.SetValidationRule(txtExpenseTypeCode, codeRule);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void ValidControlExpenseTypeName()
        {
            try
            {
                ExpenseTypeNameValidationRule nameRule = new ExpenseTypeNameValidationRule();
                nameRule.txtExpenseTypeName = txtExpenseTypeName;
                dxValidationProvider1.SetValidationRule(txtExpenseTypeName, nameRule);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void txtExpenseTypeCode_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtExpenseTypeName.Focus();
                    txtExpenseTypeName.SelectAll();
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void txtExpenseTypeName_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtParentCode.Focus();
                    txtParentCode.SelectAll();
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void txtParentCode_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    bool valid = false;
                    if (!String.IsNullOrEmpty(txtParentCode.Text))
                    {
                        string key = txtParentCode.Text.Trim().ToLower();
                        var listData = listExpenseType.Where(o => o.EXPENSE_TYPE_CODE.ToLower().Contains(key) || o.EXPENSE_TYPE_NAME.ToLower().Contains(key)).ToList();
                        if (listData != null && listData.Count == 1)
                        {
                            valid = true;
                            txtParentCode.Text = listData.First().EXPENSE_TYPE_CODE;
                            cboParent.EditValue = listData.First().ID;
                            checkAllowExpense.Focus();
                        }
                    }
                    if (!valid)
                    {
                        cboParent.Focus();
                        cboParent.ShowPopup();
                    }
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void cboParent_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            try
            {
                if (e.CloseMode == PopupCloseMode.Normal)
                {
                    if (cboParent.EditValue != null)
                    {
                        var parent = listExpenseType.FirstOrDefault(o => o.ID == Convert.ToInt64(cboParent.EditValue));
                        if (parent != null)
                        {
                            txtParentCode.Text = parent.EXPENSE_TYPE_CODE;
                        }
                    }
                    SendKeys.Send("{TAB}");
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void cboParent_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                if (e.Button.Kind == ButtonPredefines.Delete)
                {
                    cboParent.EditValue = null;
                    txtParentCode.Text = "";
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void checkAllowExpense_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                SendKeys.Send("{TAB}");
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void checkIsPlus_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                SendKeys.Send("{TAB}");
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void checkAllowExpense_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{TAB}");
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void checkIsPlus_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{TAB}");
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                positionHandleControl = -1;
                if (!btnAdd.Enabled || !dxValidationProvider1.Validate())
                    return;
                WaitingManager.Show();
                bool success = false;
                CommonParam param = new CommonParam();
                HTC_EXPENSE_TYPE data = new HTC_EXPENSE_TYPE();
                data.EXPENSE_TYPE_CODE = txtExpenseTypeCode.Text.Trim();
                data.EXPENSE_TYPE_NAME = txtExpenseTypeName.Text;
                if (cboParent.EditValue != null)
                {
                    data.PARENT_ID = Convert.ToInt64(cboParent.EditValue);
                }
                if (checkAllowExpense.Checked)
                {
                    data.IS_ALLOW_EXPENSE = IMSys.DbConfig.HTC_RS.HTC_EXPENSE_TYPE.IS_ALLOW_EXPENSE__TRUE;
                }
                if (checkIsPlus.Checked)
                {
                    data.IS_PLUS = IMSys.DbConfig.HTC_RS.HTC_EXPENSE_TYPE.IS_PLUS__TRUE;
                }

                var rs = new Inventec.Common.Adapter.BackendAdapter(param).Post<HTC_EXPENSE_TYPE>("api/HtcExpenseType/Create", ApiConsumers.HtcConsumer, data, param);
                if (rs != null)
                {
                    FillDataToTreeList();
                    SetDataSourceFoCboParent();
                    this.currentAdo = new ExpenseTypeADO(rs);
                    SetValueControl();
                }
                WaitingManager.Hide();
                MessageManager.Show(param, success);
            }
            catch (Exception ex)
            {
                WaitingManager.Hide();
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                positionHandleControl = -1;
                if (!btnEdit.Enabled || !dxValidationProvider1.Validate() || this.currentAdo == null)
                    return;
                WaitingManager.Show();
                bool success = false;
                CommonParam param = new CommonParam();
                HTC_EXPENSE_TYPE data = new HTC_EXPENSE_TYPE();
                data = this.currentAdo;
                data.EXPENSE_TYPE_CODE = txtExpenseTypeCode.Text.Trim();
                data.EXPENSE_TYPE_NAME = txtExpenseTypeName.Text;
                if (cboParent.EditValue != null)
                {
                    data.PARENT_ID = Convert.ToInt64(cboParent.EditValue);
                }
                if (checkAllowExpense.Checked)
                {
                    data.IS_ALLOW_EXPENSE = IMSys.DbConfig.HTC_RS.HTC_EXPENSE_TYPE.IS_ALLOW_EXPENSE__TRUE;
                }
                if (checkIsPlus.Checked)
                {
                    data.IS_PLUS = IMSys.DbConfig.HTC_RS.HTC_EXPENSE_TYPE.IS_PLUS__TRUE;
                }

                var rs = new Inventec.Common.Adapter.BackendAdapter(param).Post<HTC_EXPENSE_TYPE>("api/HtcExpenseType/Update", ApiConsumers.HtcConsumer, data, param);
                if (rs != null)
                {
                    FillDataToTreeList();
                    SetDataSourceFoCboParent();
                    this.currentAdo = new ExpenseTypeADO(rs);
                    SetValueControl();
                }
                WaitingManager.Hide();
                MessageManager.Show(param, success);
            }
            catch (Exception ex)
            {
                WaitingManager.Hide();
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (!btnNew.Enabled)
                    return;
                ResetCommonValue();
                SetValueControl();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void treeListExpenseType_Click(object sender, EventArgs e)
        {
            try
            {
                TreeList tree = sender as TreeList;
                TreeListHitInfo hi = tree.CalcHitInfo(tree.PointToClient(Control.MousePosition));
                if (hi.Node != null)
                {
                    currentAdo = null;
                    currentAdo = (ExpenseTypeADO)treeListExpenseType.GetDataRecordByNode(hi.Node);
                }
                SetValueControl();
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        private void dxValidationProvider1_ValidationFailed(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventArgs e)
        {
            try
            {
                BaseEdit edit = e.InvalidControl as BaseEdit;
                if (edit == null)
                    return;
                BaseEditViewInfo viewInfo = edit.GetViewInfo() as BaseEditViewInfo;
                if (viewInfo == null)
                    return;
                if (positionHandleControl == -1)
                {
                    positionHandleControl = edit.TabIndex;
                    if (edit.Visible)
                    {
                        edit.SelectAll();
                        edit.Focus();
                    }
                }
                if (positionHandleControl > edit.TabIndex)
                {
                    positionHandleControl = edit.TabIndex;
                    if (edit.Visible)
                    {
                        edit.Focus();
                        edit.SelectAll();
                    }
                }
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Warn(ex);
            }
        }

        public void BtnAdd()
        {
            try
            {
                btnAdd_Click(null, null);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        public void BtnEdit()
        {
            try
            {
                btnEdit_Click(null, null);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

        public void BtnNew()
        {
            try
            {
                btnNew_Click(null, null);
            }
            catch (Exception ex)
            {
                Inventec.Common.Logging.LogSystem.Error(ex);
            }
        }

    }
}
