/*****************************************************************************
*                                                                            *
*  MinionReloggerLib 0.x Beta  -- https://github.com/Vipeax/MinionRelogger   *
*  Copyright (C) 2013, Robert van den Boorn                                  *
*                                                                            *
*  This program is free software: you can redistribute it and/or modify      *
*   it under the terms of the GNU General Public License as published by     *
*   the Free Software Foundation, either version 3 of the License, or        *
*   (at your option) any later version.                                      *
*                                                                            *
*   This program is distributed in the hope that it will be useful,          *
*   but WITHOUT ANY WARRANTY; without even the implied warranty of           *
*   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the            *
*   GNU General Public License for more details.                             *
*                                                                            *
*   You should have received a copy of the GNU General Public License        *
*   along with this program.  If not, see <http://www.gnu.org/licenses/>.    *
*                                                                            *
******************************************************************************/

using MinionReloggerLib.Enums;
using MinionReloggerLib.Helpers.Language;

namespace IPCheckComponent
{
    partial class SettingsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.btnOK = new MetroFramework.Controls.MetroButton();
            this.btnCancel = new MetroFramework.Controls.MetroButton();
            this.btnDeleteIP = new MetroFramework.Controls.MetroButton();
            this.btnAddIP = new MetroFramework.Controls.MetroButton();
            this.metroToggle1 = new MetroFramework.Controls.MetroToggle();
            this.cmbBoxIPs = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btnAddRange = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // metroStyleManager
            // 
            this.metroStyleManager.Owner = this;
            // 
            // btnOK
            // 
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOK.Location = new System.Drawing.Point(255, 199);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = LanguageManager.Singleton.GetTranslation(ETranslations.IPCheckComponentOk);
            this.btnOK.Click += new System.EventHandler(this.BtnOkClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(23, 199);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = LanguageManager.Singleton.GetTranslation(ETranslations.IPCheckComponentCancel);
            this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
            // 
            // btnDeleteIP
            // 
            this.btnDeleteIP.Location = new System.Drawing.Point(192, 70);
            this.btnDeleteIP.Name = "btnDeleteIP";
            this.btnDeleteIP.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteIP.TabIndex = 2;
            this.btnDeleteIP.Text = LanguageManager.Singleton.GetTranslation(ETranslations.IPCheckComponentDeleteIP);
            this.btnDeleteIP.Click += new System.EventHandler(this.BtnDeleteIPClick);
            // 
            // btnAddIP
            // 
            this.btnAddIP.Location = new System.Drawing.Point(192, 100);
            this.btnAddIP.Name = "btnAddIP";
            this.btnAddIP.Size = new System.Drawing.Size(75, 23);
            this.btnAddIP.TabIndex = 3;
            this.btnAddIP.Text = LanguageManager.Singleton.GetTranslation(ETranslations.IPCheckComponentAddNewIP);
            this.btnAddIP.Click += new System.EventHandler(this.BtnAddIPClick);
            // 
            // metroToggle1
            // 
            this.metroToggle1.AutoSize = true;
            this.metroToggle1.Location = new System.Drawing.Point(187, 165);
            this.metroToggle1.Name = "metroToggle1";
            this.metroToggle1.Size = new System.Drawing.Size(80, 17);
            this.metroToggle1.TabIndex = 4;
            this.metroToggle1.Text = "Off";
            // 
            // cmbBoxIPs
            // 
            this.cmbBoxIPs.FormattingEnabled = true;
            this.cmbBoxIPs.ItemHeight = 23;
            this.cmbBoxIPs.Location = new System.Drawing.Point(24, 67);
            this.cmbBoxIPs.Name = "cmbBoxIPs";
            this.cmbBoxIPs.Size = new System.Drawing.Size(162, 29);
            this.cmbBoxIPs.TabIndex = 5;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(69, 164);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(113, 19);
            this.metroLabel1.TabIndex = 6;
            this.metroLabel1.Text =
                LanguageManager.Singleton.GetTranslation(ETranslations.IPCheckComponentEnableIPChecks);
            // 
            // btnAddRange
            // 
            this.btnAddRange.Location = new System.Drawing.Point(192, 130);
            this.btnAddRange.Name = "btnAddRange";
            this.btnAddRange.Size = new System.Drawing.Size(75, 23);
            this.btnAddRange.TabIndex = 7;
            this.btnAddRange.Text = LanguageManager.Singleton.GetTranslation(ETranslations.IPCheckComponentAddRange);
            this.btnAddRange.Click += new System.EventHandler(this.BtnAddRangeClick);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 243);
            this.Controls.Add(this.btnAddRange);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.cmbBoxIPs);
            this.Controls.Add(this.metroToggle1);
            this.Controls.Add(this.btnAddIP);
            this.Controls.Add(this.btnDeleteIP);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Resizable = false;
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "IP Check Component Settings";
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager;
        private MetroFramework.Controls.MetroButton btnCancel;
        private MetroFramework.Controls.MetroButton btnOK;
        private MetroFramework.Controls.MetroComboBox cmbBoxIPs;
        private MetroFramework.Controls.MetroToggle metroToggle1;
        private MetroFramework.Controls.MetroButton btnAddIP;
        private MetroFramework.Controls.MetroButton btnDeleteIP;
        private MetroFramework.Controls.MetroButton btnAddRange;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}