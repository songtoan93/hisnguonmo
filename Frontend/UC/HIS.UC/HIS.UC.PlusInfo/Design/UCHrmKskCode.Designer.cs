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
namespace HIS.UC.PlusInfo.Design
{
    partial class UCHrmKskCode
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtHrmKskCode = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciHrmKskCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHrmKskCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciHrmKskCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtHrmKskCode);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(219, 24);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtHrmKskCode
            // 
            this.txtHrmKskCode.Location = new System.Drawing.Point(75, 0);
            this.txtHrmKskCode.Name = "txtHrmKskCode";
            this.txtHrmKskCode.Size = new System.Drawing.Size(144, 20);
            this.txtHrmKskCode.StyleController = this.layoutControl1;
            this.txtHrmKskCode.TabIndex = 31;
            this.txtHrmKskCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHrmKskCode_KeyDown);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciHrmKskCode});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(219, 24);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // lciHrmKskCode
            // 
            this.lciHrmKskCode.AppearanceItemCaption.ForeColor = System.Drawing.Color.Black;
            this.lciHrmKskCode.AppearanceItemCaption.Options.UseForeColor = true;
            this.lciHrmKskCode.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lciHrmKskCode.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lciHrmKskCode.Control = this.txtHrmKskCode;
            this.lciHrmKskCode.Location = new System.Drawing.Point(0, 0);
            this.lciHrmKskCode.MaxSize = new System.Drawing.Size(0, 20);
            this.lciHrmKskCode.MinSize = new System.Drawing.Size(110, 20);
            this.lciHrmKskCode.Name = "lciHrmKskCode";
            this.lciHrmKskCode.OptionsToolTip.ToolTip = "Mã đợt khám sức khỏe của nhân viên";
            this.lciHrmKskCode.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lciHrmKskCode.Size = new System.Drawing.Size(219, 24);
            this.lciHrmKskCode.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciHrmKskCode.Text = "Mã đợt KSK:";
            this.lciHrmKskCode.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.lciHrmKskCode.TextSize = new System.Drawing.Size(70, 20);
            this.lciHrmKskCode.TextToControlDistance = 5;
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // UCHrmKskCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "UCHrmKskCode";
            this.Size = new System.Drawing.Size(219, 24);
            this.Load += new System.EventHandler(this.UCHrmKskCode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtHrmKskCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciHrmKskCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        internal DevExpress.XtraEditors.TextEdit txtHrmKskCode;
        private DevExpress.XtraLayout.LayoutControlItem lciHrmKskCode;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
    }
}