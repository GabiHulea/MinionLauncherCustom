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
using System.Globalization;
using MetroFramework.Forms;
using MinionReloggerLib.Configuration;
using MinionReloggerLib.Enums;
using MinionReloggerLib.Helpers.Language;
using MinionReloggerLib.Interfaces.Objects;
using MinionReloggerLib.Logging;

namespace SchedulerComponent
{
    public partial class SettingsForm : MetroForm
    {
        private readonly Account _account;

        public SettingsForm(Account account)
        {
            InitializeComponent();
            metroStyleManager.Theme = Config.Singleton.GeneralSettings.ThemeSetting;
            metroStyleManager.Style = Config.Singleton.GeneralSettings.StyleSetting;
            _account = account;
            BindEvents();
            SetTimeFields();
            metroToggle1.Checked = _account.EnableScheduling;
        }

        private void BtnOkClick(object sender, EventArgs e)
        {
            SaveScheduleSettings();
            Close();
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            Close();
        }

        private void BindEvents()
        {
            dateTimePicker2.ValueChanged += OnValueChanged;
            dateTimePicker3.ValueChanged += OnValueChanged;
            numericUpDown1.ValueChanged += OnValueChanged;
        }

        private void SaveScheduleSettings()
        {
            Logger.LoggingObject.Log(ELogType.Info,
                LanguageManager.Singleton.GetTranslation(
                    ETranslations.SchedulerComponentSaveSettings),
                _account.LoginName,
                lblTimeInMinutes.Text);
            DateTime currentTime = DateTime.Now;
            var startingTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day,
                dateTimePicker2.Value.Hour, dateTimePicker2.Value.Minute,
                dateTimePicker2.Value.Second);
            var endingTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day,
                dateTimePicker3.Value.Hour, dateTimePicker3.Value.Minute,
                dateTimePicker3.Value.Second);
            endingTime = endingTime.AddDays(1);
            TimeSpan t = endingTime - startingTime;
            if (t.Days > 0)
                t = new TimeSpan(0, t.Hours, t.Minutes, t.Seconds);
            var t2 = new TimeSpan((int) numericUpDown1.Value, 0, 0, 0);
            TimeSpan final = t + t2;
            _account.SetStartTime(startingTime);
            _account.SetEndTime(startingTime.Add(final));
            _account.SetManuallyScheduled(true);
            _account.SetSchedulingEnabled(metroToggle1.Checked);
        }

        private void SetTimeFields()
        {
            if (_account.ManuallyScheduled)
            {
                dateTimePicker2.Text = (_account.StartTime - DateTime.Now).TotalSeconds > 0
                    ? _account.StartTime.ToShortTimeString()
                    : DateTime.Now.ToShortTimeString();
                dateTimePicker3.Text = (_account.EndTime - DateTime.Now).TotalSeconds > 0
                    ? _account.EndTime.ToShortTimeString()
                    : (DateTime.Now + new TimeSpan(23, 57, 59)).ToShortTimeString();
            }
            else
            {
                dateTimePicker2.Text = DateTime.Now.ToShortTimeString();
                dateTimePicker3.Text = (DateTime.Now + new TimeSpan(23, 57, 59)).ToShortTimeString();
            }
        }

        private TimeSpan GetDuration()
        {
            TimeSpan t = new DateTime(1990, 1, 2, dateTimePicker3.Value.Hour, dateTimePicker3.Value.Minute,
                dateTimePicker3.Value.Second) -
                         new DateTime(1990, 1, 1, dateTimePicker2.Value.Hour, dateTimePicker2.Value.Minute,
                             dateTimePicker2.Value.Second);
            if (t.Days > 0)
                t = new TimeSpan(0, t.Hours, t.Minutes, t.Seconds);
            var t2 = new TimeSpan((int) numericUpDown1.Value, 0, 0, 0);
            TimeSpan final = t + t2;
            return final;
        }

        private void SetTotalValue()
        {
            lblTimeInMinutes.Text = GetDuration().TotalMinutes.ToString(CultureInfo.InvariantCulture);
        }

        private void OnValueChanged(object sender, EventArgs eventArgs)
        {
            SetTotalValue();
        }
    }
}