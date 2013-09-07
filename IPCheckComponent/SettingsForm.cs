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
using System.Net;
using System.Windows.Forms;
using MetroFramework.Forms;
using MinionReloggerLib.Configuration;
using MinionReloggerLib.Enums;
using MinionReloggerLib.Helpers.Input;
using MinionReloggerLib.Helpers.Language;

namespace IPCheckComponent
{
    public partial class SettingsForm : MetroForm
    {
        private readonly List<string> _currentIPList;

        public SettingsForm()
        {
            InitializeComponent();
            metroStyleManager.Theme = Config.Singleton.GeneralSettings.ThemeSetting;
            metroStyleManager.Style = Config.Singleton.GeneralSettings.StyleSetting;
            _currentIPList = Config.Singleton.GeneralSettings.AllowedIPAddressesAsString;
            PopulateIPList();
            metroToggle1.Checked = Config.Singleton.GeneralSettings.CheckForIP;
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnOkClick(object sender, EventArgs e)
        {
            Config.Singleton.GeneralSettings.SetCheckForIP(metroToggle1.Checked);
            Config.Singleton.GeneralSettings.EmptyIPList();
            foreach (string ip in _currentIPList)
            {
                IPAddress final;
                if (IPAddress.TryParse(ip, out final) && !Config.Singleton.GeneralSettings.AlreadyContainsIP(final))
                    Config.Singleton.GeneralSettings.AddIP(final);
            }
            Close();
        }

        private void BtnAddIPClick(object sender, EventArgs e)
        {
            IPAddress final;
            string result = "";
            var dialogResult = DialogResult.OK;
            while (!IPAddress.TryParse(result, out final) && (dialogResult == DialogResult.OK))
                dialogResult =
                    InputBox.ShowInputBox(
                        LanguageManager.Singleton.GetTranslation(ETranslations.IPCheckComponentIPToAdd),
                        LanguageManager.Singleton.GetTranslation(ETranslations.IPCheckComponentEnterIP),
                        ref result);
            if (dialogResult == DialogResult.OK)
                _currentIPList.Add(final.ToString());
            PopulateIPList();
        }

        private void BtnAddRangeClick(object sender, EventArgs e)
        {
            MessageBox.Show(
                LanguageManager.Singleton.GetTranslation(ETranslations.IPCheckComponentAddingNewIPRange));
            IPAddress final;
            string result = "";
            var dialogResult = DialogResult.OK;
            while (!IPAddress.TryParse(result, out final) && (dialogResult == DialogResult.OK))
                dialogResult =
                    InputBox.ShowInputBox(
                        LanguageManager.Singleton.GetTranslation(ETranslations.IPCheckComponentIPRangeToAdd),
                        LanguageManager.Singleton.GetTranslation(ETranslations.IPCheckComponentEnterIPRange),
                        ref result);
            if (dialogResult == DialogResult.OK)
            {
                var first3 = new[]
                {final.GetAddressBytes()[0], final.GetAddressBytes()[1], final.GetAddressBytes()[2]};
                for (int i = 0; i < 256; i++)
                {
                    _currentIPList.Add(string.Format("{0}.{1}.{2}.{3}", first3[0], first3[1], first3[2], i));
                }
            }
            PopulateIPList();
        }

        private void BtnDeleteIPClick(object sender, EventArgs e)
        {
            if (cmbBoxIPs.SelectedIndex != -1)
                _currentIPList.RemoveAt(cmbBoxIPs.SelectedIndex);
            PopulateIPList();
        }

        private void PopulateIPList()
        {
            cmbBoxIPs.Items.Clear();
            foreach (string ip in _currentIPList)
            {
                cmbBoxIPs.Items.Add(ip);
            }
        }
    }
}