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
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework.Controls;
using MetroFramework.Drawing;
using MetroFramework.Forms;
using MinionLauncherGUI.CustomControls;
using MinionLauncherGUI.Helpers;
using MinionReloggerLib.Configuration;
using MinionReloggerLib.Core;
using MinionReloggerLib.CustomEventArgs;
using MinionReloggerLib.Enums;
using MinionReloggerLib.Helpers.Input;
using MinionReloggerLib.Helpers.Language;
using MinionReloggerLib.Interfaces.Objects;
using MinionReloggerLib.Logging;

namespace MinionLauncherGUI
{
    public delegate void ReloggerHandler(object sender, ReloggerEventArgs reloggerEventArgs);

    public partial class MainForm : MetroForm
    {
        internal readonly List<AccountControl> AccountControls = new List<AccountControl>();

        private int _newSet;
        private int _totalAccounts;


        public MainForm()
        {
            InitializeComponent();
            try
            {
                if (!MinionReloggerLib.Helpers.VersionControl.VersionControl.CheckVersionBot())
                {
                    MessageBox.Show("Minion version does not match game version!\nPlease wait for an update.");
                }
                else
                {
                    Logger.Initialize(lstBoxLog);
                    ComponentManager.Singleton.LoadComponents();
                    ThreadManager.Singleton.Initialize();
                    if (!LoadConfig(false) || !File.Exists(Config.Singleton.GeneralSettings.GW2Path))
                        FreshStart();
                    FixNamesForLanguage();

                    if (File.Exists(".\\MinionFiles\\RunningAccounts.ini"))
                    {
                        IniFile ini = new IniFile(".\\MinionFiles\\RunningAccounts.ini");
                        bool value;
                        string str = ini.IniReadValue("RunningAccounts", "Active");
                        if (bool.TryParse(str, out value))
                        {
                            if (value)
                            {
                                str = ini.IniReadValue("RunningAccounts", "Accounts");
                                string[] strSplitted = str.Split(';');
                                foreach (var accName in strSplitted)
                                {
                                    foreach (
                                        var account in
                                            Config.Singleton.AccountSettings.Where(
                                                account => account.LoginName == accName))
                                    {
                                        account.SetShouldBeRunning(true);
                                    }
                                }
                            }
                        }
                        ini.IniWriteValue("RunningAccounts", "Active", "False");
                    }
                }
            }
            catch
            {
                MessageBox.Show("ERROR");
                Close();
                Application.Exit();
            }
        }

        private void FixNamesForLanguage()
        {
            tabPage1.Text = LanguageManager.Singleton.GetTranslation(ETranslations.MainFormAccounts);
            tabPage2.Text = LanguageManager.Singleton.GetTranslation(ETranslations.MainFormSettings);
            btnSetFrozenTime.Text = LanguageManager.Singleton.GetTranslation(ETranslations.MainFormSetFrozenTime);
            btnEnableComponent.Text = LanguageManager.Singleton.GetTranslation(ETranslations.MainFormMoveToLeft);
            btnDisableComponent.Text = LanguageManager.Singleton.GetTranslation(ETranslations.MainFormMoveToRight);
            metroLabel4.Text = LanguageManager.Singleton.GetTranslation(ETranslations.MainFormDisabledComponents);
            metroLabel3.Text = LanguageManager.Singleton.GetTranslation(ETranslations.MainFormEnabledComponents);
            metroTileAddAccount.Text = LanguageManager.Singleton.GetTranslation(ETranslations.MainFormAddAccount);
            btnSetPollingDelay.Text =
                LanguageManager.Singleton.GetTranslation(ETranslations.MainFormSetPollingDelay);
            btnLoad.Text = LanguageManager.Singleton.GetTranslation(ETranslations.MainFormLoad);
            btnSave.Text = LanguageManager.Singleton.GetTranslation(ETranslations.MainFormSave);
            metroLabel2.Text = LanguageManager.Singleton.GetTranslation(ETranslations.MainFormMinimizeGW2Windows);
            btnSettings.Text = LanguageManager.Singleton.GetTranslation(ETranslations.MainFormOpenSettings);
            btnSetExePath.Text = LanguageManager.Singleton.GetTranslation(ETranslations.MainFormSetGW2EXEPath);
            tabPage3.Text = LanguageManager.Singleton.GetTranslation(ETranslations.MainFormLog);
            metroTileStartAll.Text = " " + LanguageManager.Singleton.GetTranslation(ETranslations.MainFormStartAll);
            metroTileStopAll.Text = " " + LanguageManager.Singleton.GetTranslation(ETranslations.MainFormStopAll);
            metroTileChangeTheme.Text = " " +
                                        LanguageManager.Singleton.GetTranslation(ETranslations.MainFormChangeTheme);
            metroTileChangeColor.Text = " " +
                                        LanguageManager.Singleton.GetTranslation(ETranslations.MainFormChangeColor);
            btnSetLanguage.Text = LanguageManager.Singleton.GetTranslation(ETranslations.MainFormSetLanguage);
            CleanupFirstTab();
            UpdateFormWithAccountSettings();
            PopulateGlobalSettings();
            FillComponentManagementComboBoxes();
            PopulateLanguageComboBox();
            FixVisibility();
        }

        private void FixVisibility()
        {
            metroComboBox1.Visible = Config.Singleton.GeneralSettings.UseExpertMode;
            metroComboBox2.Visible = Config.Singleton.GeneralSettings.UseExpertMode;
            metroComboBoxGlobalSettingsComponents.Visible = Config.Singleton.GeneralSettings.UseExpertMode;
            btnSettings.Visible = Config.Singleton.GeneralSettings.UseExpertMode;
            btnSetPollingDelay.Visible = Config.Singleton.GeneralSettings.UseExpertMode;
            btnSetFrozenTime.Visible = Config.Singleton.GeneralSettings.UseExpertMode;
            metroToggle1.Visible = Config.Singleton.GeneralSettings.UseExpertMode;
            // metroToggle2.Visible = Config.Singleton.GeneralSettings.UseExpertMode;  <== Disabled beta crap
            metroLabel3.Visible = Config.Singleton.GeneralSettings.UseExpertMode;
            metroLabel4.Visible = Config.Singleton.GeneralSettings.UseExpertMode;
            // metroLabel5.Visible = Config.Singleton.GeneralSettings.UseExpertMode;  <== Disabled beta crap
            metroLabel1.Visible = Config.Singleton.GeneralSettings.UseExpertMode;
            btnEnableComponent.Visible = Config.Singleton.GeneralSettings.UseExpertMode;
            btnDisableComponent.Visible = Config.Singleton.GeneralSettings.UseExpertMode;
        }

        private void FreshStart()
        {
            MessageBox.Show(
                LanguageManager.Singleton.GetTranslation(ETranslations.MainFormFreshConfig),
                LanguageManager.Singleton.GetTranslation(ETranslations.MainFormWelcome), MessageBoxButtons.OK);
            BringToFront();
            SetGW2Path();
            BringToFront();
            MessageBox.Show(
                LanguageManager.Singleton.GetTranslation(ETranslations.MainFormWhichComponents),
                LanguageManager.Singleton.GetTranslation(ETranslations.MainFormFirstStep), MessageBoxButtons.OK);
            BringToFront();
            MessageBox.Show(
                LanguageManager.Singleton.GetTranslation(ETranslations.MainFormPleaseSave),
                LanguageManager.Singleton.GetTranslation(ETranslations.MainFormTip), MessageBoxButtons.OK);
            BringToFront();
            metroTabControl1.SelectTab(1);
            ComponentManager.Singleton.EnableAllComponents();
        }

        private void MetroTileStartAllClick(object sender, EventArgs e)
        {
            foreach (Account account in Config.Singleton.AccountSettings)
            {
                account.SetShouldBeRunning(true);
            }
            foreach (TabPage page in metroTabControl2.TabPages)
            {
                foreach (
                    object control in
                        page.Controls.Cast<object>()
                            .Where(
                                control =>
                                    control as MetroLabel != null &&
                                    ((MetroLabel) control).Text ==
                                    LanguageManager.Singleton.GetTranslation(ETranslations.MainFormDisabled)))
                {
                    ((MetroLabel) control).Text = LanguageManager.Singleton.GetTranslation(ETranslations.MainFormEnabled);
                }
            }
        }

        private void MetroTileStopAllClick(object sender, EventArgs e)
        {
            foreach (Account account in Config.Singleton.AccountSettings)
            {
                account.SetShouldBeRunning(false);
                foreach (TabPage page in metroTabControl2.TabPages)
                {
                    foreach (
                        object control in
                            page.Controls.Cast<object>()
                                .Where(
                                    control =>
                                        control as MetroLabel != null &&
                                        ((MetroLabel) control).Text ==
                                        LanguageManager.Singleton.GetTranslation(ETranslations.MainFormEnabled)))
                    {
                        ((MetroLabel) control).Text =
                            LanguageManager.Singleton.GetTranslation(ETranslations.MainFormDisabled);
                    }
                }
            }
            foreach (TabPage page in metroTabControl2.TabPages)
            {
                foreach (object control in page.Controls)
                {
                    if (control as MetroControlBase != null)
                    {
                        ((MetroControlBase) control).Theme = metroStyleManager.Theme;
                        ((MetroControlBase) control).Style = metroStyleManager.Style;
                    }
                    else if (control as MetroButton != null)
                    {
                        ((MetroButton) control).Theme = metroStyleManager.Theme;
                        ((MetroButton) control).Style = metroStyleManager.Style;
                    }
                    else if (control as MetroLabel != null)
                    {
                        ((MetroLabel) control).Theme = metroStyleManager.Theme;
                        ((MetroLabel) control).Style = metroStyleManager.Style;
                    }
                    else if (control as MetroComboBox != null)
                    {
                        ((MetroComboBox) control).Theme = metroStyleManager.Theme;
                        ((MetroComboBox) control).Style = metroStyleManager.Style;
                    }
                }
            }
        }

        private void MetroTileChangeThemeClick(object sender, EventArgs e)
        {
            var rng = new Random();
            ICollection<string> themes = MetroStyleManager.Styles.Themes.Keys;
            while (true)
            {
                string newTheme = themes.ElementAt(rng.Next(themes.Count));
                if (newTheme == metroStyleManager.Theme) continue;
                metroStyleManager.Theme = newTheme;
                Config.Singleton.GeneralSettings.SetTheme(newTheme);
                metroStyleManager.Update();
                break;
            }

            foreach (TabPage page in metroTabControl1.TabPages)
            {
                foreach (object control in page.Controls)
                {
                    if (control as MetroControlBase != null)
                    {
                        ((MetroControlBase) control).Theme = metroStyleManager.Theme;
                        ((MetroControlBase) control).Style = metroStyleManager.Style;
                    }
                    else if (control as MetroButton != null)
                    {
                        ((MetroButton) control).Theme = metroStyleManager.Theme;
                        ((MetroButton) control).Style = metroStyleManager.Style;
                    }
                    else if (control as MetroLabel != null)
                    {
                        ((MetroLabel) control).Theme = metroStyleManager.Theme;
                        ((MetroLabel) control).Style = metroStyleManager.Style;
                    }
                    else if (control as MetroComboBox != null)
                    {
                        ((MetroComboBox) control).Theme = metroStyleManager.Theme;
                        ((MetroComboBox) control).Style = metroStyleManager.Style;
                    }
                }
            }

            foreach (TabPage page in metroTabControl2.TabPages)
            {
                foreach (object control in page.Controls)
                {
                    if (control as MetroControlBase != null)
                    {
                        ((MetroControlBase) control).Theme = metroStyleManager.Theme;
                        ((MetroControlBase) control).Style = metroStyleManager.Style;
                    }
                    else if (control as MetroButton != null)
                    {
                        ((MetroButton) control).Theme = metroStyleManager.Theme;
                        ((MetroButton) control).Style = metroStyleManager.Style;
                    }
                    else if (control as MetroLabel != null)
                    {
                        ((MetroLabel) control).Theme = metroStyleManager.Theme;
                        ((MetroLabel) control).Style = metroStyleManager.Style;
                    }
                    else if (control as MetroComboBox != null)
                    {
                        ((MetroComboBox) control).Theme = metroStyleManager.Theme;
                        ((MetroComboBox) control).Style = metroStyleManager.Style;
                    }
                }
            }
        }

        private void MetroTileChangeColorClick(object sender, EventArgs e)
        {
            var rng = new Random();
            ICollection<string> styles = MetroStyleManager.Styles.Styles.Keys;
            while (true)
            {
                string newStyle = styles.ElementAt(rng.Next(styles.Count));
                if (newStyle == metroStyleManager.Style || newStyle == "White") continue;
                metroStyleManager.Style = newStyle;
                Config.Singleton.GeneralSettings.SetStyle(metroStyleManager.Style);
                break;
            }

            foreach (TabPage page in metroTabControl2.TabPages)
            {
                foreach (object control in page.Controls)
                {
                    if (control as MetroControlBase != null)
                    {
                        ((MetroControlBase) control).Theme = metroStyleManager.Theme;
                        ((MetroControlBase) control).Style = metroStyleManager.Style;
                    }
                    else if (control as MetroButton != null)
                    {
                        ((MetroButton) control).Theme = metroStyleManager.Theme;
                        ((MetroButton) control).Style = metroStyleManager.Style;
                    }
                    else if (control as MetroLabel != null)
                    {
                        ((MetroLabel) control).Theme = metroStyleManager.Theme;
                        ((MetroLabel) control).Style = metroStyleManager.Style;
                    }
                    else if (control as MetroComboBox != null)
                    {
                        ((MetroComboBox) control).Theme = metroStyleManager.Theme;
                        ((MetroComboBox) control).Style = metroStyleManager.Style;
                    }
                }
            }
        }


        private void MetroTileAddAccountClick(object sender, EventArgs e)
        {
            new AccountForm(EAccountManagementType.Add).ShowDialog();
            CleanupFirstTab();
            metroStyleManager.Style = Config.Singleton.GeneralSettings.StyleSetting;
            metroStyleManager.Theme = Config.Singleton.GeneralSettings.ThemeSetting;
            metroToggleMinimizeGW2.Checked = Config.Singleton.GeneralSettings.MinimizeWindows;
            metroToggle1.Checked = Config.Singleton.GeneralSettings.ExtensiveLogging;
            metroToggle2.Checked = Config.Singleton.GeneralSettings.UseBeta;
            UpdateFormWithAccountSettings();
        }

        private void BtnSettingsClick(object sender, EventArgs e)
        {
            if (metroComboBoxGlobalSettingsComponents.SelectedIndex != -1)
                ComponentManager.Singleton.OpenSettingsForm(
                    ComponentManager.Singleton.GetEnabledGlobalSettingsComponentNames()[
                        metroComboBoxGlobalSettingsComponents.SelectedIndex]);
        }

        private void MetroToggleMinimizeGW2CheckedChanged(object sender, EventArgs e)
        {
            Config.Singleton.GeneralSettings.SetMinimizeWindows(metroToggleMinimizeGW2.Checked);
        }


        private void MetroToggle1CheckedChanged(object sender, EventArgs e)
        {
            Config.Singleton.GeneralSettings.SetExtensiveLogging(metroToggle1.Checked);
        }

        private void MetroToggle2CheckedChanged(object sender, EventArgs e)
        {
            Config.Singleton.GeneralSettings.SetUseBeta(metroToggle2.Checked);
        }

        private void BtnLoadClick(object sender, EventArgs e)
        {
            LoadConfig(true);
        }

        private void BtnSaveClick(object sender, EventArgs e)
        {
            Config.SaveSettingsToFile();
        }

        private void BtnSetExePathClick(object sender, EventArgs e)
        {
            SetGW2Path(Config.Singleton.GeneralSettings.GW2Path);
        }

        private void BtnSetPollingDelayClick(object sender, EventArgs e)
        {
            SetPollingDelay(false, Config.Singleton.GeneralSettings.PollingDelay);
        }

        private void NewControlOnSettingsClick(object sender, ReloggerEventArgs reloggereventargs)
        {
            if (((AccountControl) reloggereventargs.Control).CmbSettings.SelectedIndex != -1)
                ComponentManager.Singleton.OpenSettingsForm(
                    ComponentManager.Singleton.GetEnabledAccountSettingsComponentNames()[
                        ((AccountControl) reloggereventargs.Control).CmbSettings.SelectedIndex],
                    reloggereventargs.Account);
        }

        private void MetroTileUnlockExpertClick(object sender, EventArgs e)
        {
            Config.Singleton.GeneralSettings.SetUseExpertMode(!Config.Singleton.GeneralSettings.UseExpertMode);
            CleanupFirstTab();
            metroStyleManager.Style = Config.Singleton.GeneralSettings.StyleSetting;
            metroStyleManager.Theme = Config.Singleton.GeneralSettings.ThemeSetting;
            metroToggleMinimizeGW2.Checked = Config.Singleton.GeneralSettings.MinimizeWindows;
            metroToggle1.Checked = Config.Singleton.GeneralSettings.ExtensiveLogging;
            metroToggle2.Checked = Config.Singleton.GeneralSettings.UseBeta;
            metroComboBox1.Visible = Config.Singleton.GeneralSettings.UseExpertMode;
            metroComboBox2.Visible = Config.Singleton.GeneralSettings.UseExpertMode;
            metroComboBoxGlobalSettingsComponents.Visible = Config.Singleton.GeneralSettings.UseExpertMode;
            btnSettings.Visible = Config.Singleton.GeneralSettings.UseExpertMode;
            btnSetPollingDelay.Visible = Config.Singleton.GeneralSettings.UseExpertMode;
            btnSetFrozenTime.Visible = Config.Singleton.GeneralSettings.UseExpertMode;
            metroToggle1.Visible = Config.Singleton.GeneralSettings.UseExpertMode;
            //metroToggle2.Visible = Config.Singleton.GeneralSettings.UseExpertMode; <== Disabled beta crap
            metroLabel3.Visible = Config.Singleton.GeneralSettings.UseExpertMode;
            metroLabel4.Visible = Config.Singleton.GeneralSettings.UseExpertMode;
            //metroLabel5.Visible = Config.Singleton.GeneralSettings.UseExpertMode;   <== Disabled beta crap
            metroLabel1.Visible = Config.Singleton.GeneralSettings.UseExpertMode;
            btnEnableComponent.Visible = Config.Singleton.GeneralSettings.UseExpertMode;
            btnDisableComponent.Visible = Config.Singleton.GeneralSettings.UseExpertMode;
            UpdateFormWithAccountSettings();
        }

        private void NewControlOnKillClick(object sender, ReloggerEventArgs reloggereventargs)
        {
            reloggereventargs.Account.SetShouldBeRunning(false);
            ((AccountControl) reloggereventargs.Control).LblStatus.Text =
                LanguageManager.Singleton.GetTranslation(ETranslations.MainFormDisabled);
        }

        private void NewControlOnStartClick(object sender, ReloggerEventArgs reloggereventargs)
        {
            reloggereventargs.Account.SetShouldBeRunning(true);
            ((AccountControl) reloggereventargs.Control).LblStatus.Text =
                LanguageManager.Singleton.GetTranslation(ETranslations.MainFormEnabled);
        }

        private void NewControlOnManageClick(object sender, ReloggerEventArgs reloggerEventArgs)
        {
            new AccountForm(EAccountManagementType.Edit, reloggerEventArgs.Account).ShowDialog();
            CleanupFirstTab();
            metroStyleManager.Style = Config.Singleton.GeneralSettings.StyleSetting;
            metroStyleManager.Theme = Config.Singleton.GeneralSettings.ThemeSetting;
            metroToggleMinimizeGW2.Checked = Config.Singleton.GeneralSettings.MinimizeWindows;
            metroToggle1.Checked = Config.Singleton.GeneralSettings.ExtensiveLogging;
            metroToggle2.Checked = Config.Singleton.GeneralSettings.UseBeta;
            UpdateFormWithAccountSettings();
        }

        private void NewControlOnResetTimeClick(object sender, ReloggerEventArgs reloggereventargs)
        {
            reloggereventargs.Account.SetLastStartTime(new DateTime());
            reloggereventargs.Account.SetLastStopTime(new DateTime());
            reloggereventargs.Account.SetLastCrash(new DateTime());
        }

        private void BtnSetFrozenTimeClick(object sender, EventArgs e)
        {
            SetFrozenTime(false, Config.Singleton.GeneralSettings.FrozenTime);
        }

        private void BtnDisableComponentClick(object sender, EventArgs e)
        {
            if (metroComboBox1.SelectedIndex != -1)
                ComponentManager.Singleton.DisableComponent(
                    ComponentManager.Singleton.GetComponentNamesForEnabled()[
                        metroComboBox1.SelectedIndex]);
            FillComponentManagementComboBoxes();
            PopulateGlobalSettings();
            PopulateAccountComponentComboBoxes();
        }

        private void BtnEnableComponentClick(object sender, EventArgs e)
        {
            if (metroComboBox2.SelectedIndex != -1)
                ComponentManager.Singleton.EnableComponent(
                    ComponentManager.Singleton.GetComponentNamesForDisabled()[
                        metroComboBox2.SelectedIndex]);
            FillComponentManagementComboBoxes();
            PopulateGlobalSettings();
            PopulateAccountComponentComboBoxes();
        }


        private void BtnSetLanguageClick(object sender, EventArgs e)
        {
            if (metroComboBox3.SelectedIndex >= 0)
                LanguageManager.Singleton.SetNewLanguage((ELanguages) metroComboBox3.SelectedIndex);
            PopulateLanguageComboBox();
            FixNamesForLanguage();
        }

        private void PopulateAccountComponentComboBoxes()
        {
            foreach (TabPage page in metroTabControl2.TabPages)
            {
                foreach (object control in page.Controls)
                {
                    if (control as MetroComboBox != null)
                    {
                        PopulateAccountSettings((MetroComboBox) control);
                    }
                }
            }
        }

        private void PopulateLanguageComboBox()
        {
            metroComboBox3.Items.Clear();
            foreach (var language in LanguageManager.Singleton.GetLanguages())
            {
                metroComboBox3.Items.Add(language.Value.GetLanguageDescription());
                if (language.Key == LanguageManager.Singleton.GetCurrentLanguage())
                    metroComboBox3.SelectedIndex = metroComboBox3.Items.Count - 1;
            }
            // Force redraw :/
            if (metroComboBox3.Theme == "Dark")
            {
                metroComboBox3.Theme = "Light";
                metroComboBox3.Theme = "Dark";
            }
            else
            {
                metroComboBox3.Theme = "Dark";
                metroComboBox3.Theme = "Light";
            }
        }

        private void FillComponentManagementComboBoxes()
        {
            metroComboBox1.Items.Clear();
            foreach (string component in ComponentManager.Singleton.GetComponentNamesForEnabled())
            {
                metroComboBox1.Items.Add(component);
            }
            if (metroComboBox1.Items.Count > 0)
            {
                metroComboBox1.SelectedIndex = 0;
            }
            // Force redraw :/
            if (metroComboBox1.Theme == "Dark")
            {
                metroComboBox1.Theme = "Light";
                metroComboBox1.Theme = "Dark";
            }
            else
            {
                metroComboBox1.Theme = "Dark";
                metroComboBox1.Theme = "Light";
            }

            metroComboBox2.Items.Clear();
            foreach (string component in ComponentManager.Singleton.GetComponentNamesForDisabled())
            {
                metroComboBox2.Items.Add(component);
            }
            if (metroComboBox2.Items.Count > 0)
            {
                metroComboBox2.SelectedIndex = 0;
            }

            // Force redraw :/
            if (metroComboBox2.Theme == "Dark")
            {
                metroComboBox2.Theme = "Light";
                metroComboBox2.Theme = "Dark";
            }
            else
            {
                metroComboBox2.Theme = "Dark";
                metroComboBox2.Theme = "Light";
            }
        }

        private void CycleTabsForRenderer()
        {
            metroTabPage1.Controls.Add(new MetroLabel
            {
                FontWeight = MetroFontWeight.Bold,
                Text = LanguageManager.Singleton.GetTranslation(ETranslations.MainFormLoginName),
                Theme = metroStyleManager.Theme,
                Style = metroStyleManager.Style,
                Location = new Point(3, 10),
                BackColor = Color.Transparent,
            });

            metroTabPage1.Controls.Add(new MetroLabel
            {
                FontWeight = MetroFontWeight.Bold,
                Text = LanguageManager.Singleton.GetTranslation(ETranslations.MainFormStatus),
                Theme = metroStyleManager.Theme,
                Style = metroStyleManager.Style,
                Location = new Point(490, 10),
                BackColor = Color.Transparent,
            });

            metroTabControl1.SelectTab(0);
            metroTabControl1.SelectTab(1);
            metroTabControl1.SelectTab(2);
            metroTabControl1.SelectTab(0);
        }

        private void PopulateGlobalSettings()
        {
            metroComboBoxGlobalSettingsComponents.Items.Clear();
            foreach (string component in ComponentManager.Singleton.GetEnabledGlobalSettingsComponentNames())
            {
                metroComboBoxGlobalSettingsComponents.Items.Add(component);
            }
            if (metroComboBoxGlobalSettingsComponents.Items.Count > 0)
            {
                metroComboBoxGlobalSettingsComponents.SelectedIndex = 0;
            }
            // Force redraw :/
            if (metroComboBoxGlobalSettingsComponents.Theme == "Dark")
            {
                metroComboBoxGlobalSettingsComponents.Theme = "Light";
                metroComboBoxGlobalSettingsComponents.Theme = "Dark";
            }
            else
            {
                metroComboBoxGlobalSettingsComponents.Theme = "Dark";
                metroComboBoxGlobalSettingsComponents.Theme = "Light";
            }
        }

        private void SetGW2Path(string path = "")
        {
            var openFileDialog = new OpenFileDialog();


            openFileDialog.Filter = "Guild Wars 2 Executables (.exe)|GW*.exe|Executables (.exe)|*.exe";
            if (path != "")
                openFileDialog.InitialDirectory = path;
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Multiselect = false;

            MessageBox.Show(LanguageManager.Singleton.GetTranslation(ETranslations.MainFormLocateGW2Long),
                LanguageManager.Singleton.GetTranslation(ETranslations.MainFormLocateGW2Short));
            while (
                openFileDialog.ShowDialog() !=
                DialogResult.OK || !File.Exists(openFileDialog.FileName)) ;
            Config.Singleton.GeneralSettings.SetGW2Path(openFileDialog.FileName);
        }

        private void SetPollingDelay(bool mustBeEntered = true, int currentValue = 0)
        {
            int final;
            string result = currentValue == 0 ? @"3" : currentValue.ToString();
            var dialogResult = DialogResult.OK;
            bool done = false;
            while ((!Int32.TryParse(result, out final) || final < 3 || !done) &&
                   (dialogResult == DialogResult.OK || mustBeEntered))
            {
                dialogResult =
                    InputBox.ShowInputBox(
                        LanguageManager.Singleton.GetTranslation(ETranslations.MainFormPollingDelayShort),
                        LanguageManager.Singleton.GetTranslation(ETranslations.MainFormPollingDelayLong),
                        ref result);
                done = true;
            }

            if (dialogResult == DialogResult.OK)
                Config.Singleton.GeneralSettings.SetPollingDelay(final);
        }

        private void SetFrozenTime(bool mustBeEntered = true, int currentValue = 0)
        {
            int final;
            string result = currentValue == 0 ? @"300" : currentValue.ToString();
            var dialogResult = DialogResult.OK;
            bool done = false;
            while ((!Int32.TryParse(result, out final) || final < 60 || !done) &&
                   (dialogResult == DialogResult.OK || mustBeEntered))
            {
                dialogResult =
                    InputBox.ShowInputBox(
                        LanguageManager.Singleton.GetTranslation(ETranslations.MainFormFrozenTimeShort),
                        LanguageManager.Singleton.GetTranslation(ETranslations.MainFormFrozenTimeLong),
                        ref result);
                done = true;
            }

            if (dialogResult == DialogResult.OK)
                Config.Singleton.GeneralSettings.SetFrozenTime(final);
        }


        private bool LoadConfig(bool manual)
        {
            if (Config.LoadConfig(manual))
            {
                CleanupFirstTab();
                metroStyleManager.Style = Config.Singleton.GeneralSettings.StyleSetting;
                metroStyleManager.Theme = Config.Singleton.GeneralSettings.ThemeSetting;
                metroToggleMinimizeGW2.Checked = Config.Singleton.GeneralSettings.MinimizeWindows;
                metroToggle1.Checked = Config.Singleton.GeneralSettings.ExtensiveLogging;
                metroToggle2.Checked = Config.Singleton.GeneralSettings.UseBeta;
                UpdateFormWithAccountSettings();
                return true;
            }
            return false;
        }

        private void CreateCustomControlForLauncher(Account account)
        {
            _newSet++;
            var newControl = new AccountControl(metroTabControl2,
                AccountControls.Count,
                _totalAccounts, _newSet, metroStyleManager, account);
            newControl.StartClick += NewControlOnStartClick;
            newControl.KillClick += NewControlOnKillClick;
            newControl.ManageClick += NewControlOnManageClick;
            newControl.SettingsClick += NewControlOnSettingsClick;
            newControl.ResetTimeClick += NewControlOnResetTimeClick;
            PopulateAccountSettings(newControl.CmbSettings);
            AccountControls.Add(newControl);
            _totalAccounts++;
            if (_newSet == 10)
            {
                _newSet = 0;
            }
            metroStyleManager.Update();
        }

        private void PopulateAccountSettings(MetroComboBox control)
        {
            control.Items.Clear();
            foreach (string component in ComponentManager.Singleton.GetEnabledAccountSettingsComponentNames())
            {
                control.Items.Add(component);
            }
            if (control.Items.Count > 0)
            {
                control.SelectedIndex = 0;
            }
        }

        private void CleanupFirstTab()
        {
            //if (_totalAccounts > 0)
            {
                for (int i = 1; i < metroTabControl2.TabPages.Count; i++)
                {
                    metroTabControl2.TabPages.Remove(metroTabControl2.TabPages[i]);
                    i = i - 1;
                }
                metroTabPage1.Controls.Clear();
                metroTabPage1.Controls.Add(new MetroLabel
                {
                    FontWeight = MetroFontWeight.Bold,
                    Text = LanguageManager.Singleton.GetTranslation(ETranslations.MainFormLoginName),
                    Theme = metroStyleManager.Theme,
                    Style = metroStyleManager.Style,
                    Location = new Point(3, 10),
                    BackColor = Color.Transparent,
                });

                metroTabPage1.Controls.Add(new MetroLabel
                {
                    FontWeight = MetroFontWeight.Bold,
                    Text = LanguageManager.Singleton.GetTranslation(ETranslations.MainFormStatus),
                    Theme = metroStyleManager.Theme,
                    Style = metroStyleManager.Style,
                    Location = new Point(490, 10),
                    BackColor = Color.Transparent,
                });
                _newSet = 0;
                _totalAccounts = 0;
                AccountControls.Clear();
            }
        }

        private void UpdateFormWithAccountSettings()
        {
            foreach (Account account in Config.Singleton.AccountSettings)
            {
                CreateCustomControlForLauncher(account);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config.SaveSettingsToFile();
        }
    }
}