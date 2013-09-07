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

using System;
using System.Linq;
using MetroFramework.Forms;
using MinionLauncherGUI.Helpers;
using MinionReloggerLib.Configuration;
using MinionReloggerLib.Enums;
using MinionReloggerLib.Helpers.Language;
using MinionReloggerLib.Interfaces.Objects;
using System.Windows.Forms;
using System.IO;

namespace MinionLauncherGUI
{
    public partial class AccountForm : MetroForm
    {
        private readonly Account _account;
        private readonly EAccountManagementType _type;

        public AccountForm(EAccountManagementType type, Account account = null)
        {
            InitializeComponent();
            _account = account;
            _type = type;
           // metroToggle2.Checked = true;
            metroStyleManager.Theme = Config.Singleton.GeneralSettings.ThemeSetting;
            metroStyleManager.Style = Config.Singleton.GeneralSettings.StyleSetting;
            switch (type)
            {
                case EAccountManagementType.Add:
                    btnDelete.Visible = false;
                    Text = LanguageManager.Singleton.GetTranslation(ETranslations.AccountFormAddAccount);
                    break;
                case EAccountManagementType.Edit:
                    btnDelete.Visible = true;
                    Text = LanguageManager.Singleton.GetTranslation(ETranslations.AccountFormEditAccount);
                    break;
            }
            if (account != null)
            {
                txtBoxLoginName.Text = account.LoginName.Replace(@"""", "");
                txtBoxPassword.Text = account.Password;
                metroToggle1.Checked = account.NoSound;
                metroToggle2.Checked = account.AttachBot2;
                metroToggle3.Checked = account.UseCustomGW2Path;
                txtBoxCustomPath.Text = account.CustomGW2Path;
            }
        }

        private void BtnOkClick(object sender, EventArgs e)
        {
            switch (_type)
            {
                case EAccountManagementType.Add:
                    if (!string.IsNullOrEmpty(txtBoxLoginName.Text) && !string.IsNullOrEmpty(txtBoxPassword.Text) &&
                        Config.Singleton.AccountSettings.All(account => account.LoginName != txtBoxLoginName.Text))
                    {
                        var toAdd = new Account();
                        string pass = txtBoxPassword.Text;
                        if (!pass.Contains(@""""))
                            pass = @"""" + pass + @"""";
                        toAdd.SetLoginName(txtBoxLoginName.Text);
                        toAdd.SetPassword(pass);
                        toAdd.SetBotPath(AppDomain.CurrentDomain.BaseDirectory);
                        toAdd.SetEndTime(DateTime.Now.AddYears(1337));
                        toAdd.SetManuallyScheduled(false);
                        toAdd.SetNoSound(metroToggle1.Checked);
                        toAdd.SetAttachBot(metroToggle2.Checked);
                        toAdd.SetUseCostumGW2Path(metroToggle3.Checked);
                        toAdd.SetCostumGW2Path(txtBoxCustomPath.Text);
                        Config.Singleton.AddAccount(toAdd);
                    }
                    break;
                case EAccountManagementType.Edit:
                    Account wanted =
                        Config.Singleton.AccountSettings.FirstOrDefault(
                            account => account.LoginName == _account.LoginName);
                    if (wanted != null)
                    {
                        string pass = txtBoxPassword.Text;
                        if (!pass.Contains(@""""))
                            pass = @"""" + pass + @"""";
                        wanted.SetPassword(pass);
                        wanted.SetNoSound(metroToggle1.Checked);
                        wanted.SetLoginName(txtBoxLoginName.Text);
                        wanted.SetAttachBot(metroToggle2.Checked);
                        try
                        {
                            wanted.SetUseCostumGW2Path(metroToggle3.Checked);
                            wanted.SetCostumGW2Path(txtBoxCustomPath.Text);
                        }
                        catch { }
                    }
                    break;
            }
            Close();
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnDeleteClick(object sender, EventArgs e)
        {
            Account wanted =
                Config.Singleton.AccountSettings.FirstOrDefault(account => account.LoginName == _account.LoginName);
            if (wanted != null)
            {
                Config.Singleton.DeleteAccount(wanted);
            }
            Close();
        }

        private void btnBrowseCustomeGW2_Click(object sender, EventArgs e)
        {

            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Guild Wars 2 Executables (.exe)|GW*.exe|Executables (.exe)|*.exe";
            openFileDialog.InitialDirectory = Config.Singleton.GeneralSettings.GW2Path;
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Multiselect = false;

            MessageBox.Show(LanguageManager.Singleton.GetTranslation(ETranslations.MainFormLocateGW2Long),
                LanguageManager.Singleton.GetTranslation(ETranslations.MainFormLocateGW2Short));
            while (
                openFileDialog.ShowDialog() !=
                DialogResult.OK || !File.Exists(openFileDialog.FileName)) ;
            txtBoxCustomPath.Text = openFileDialog.FileName;
        }
    }
}