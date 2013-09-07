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
using MetroFramework.Forms;
using MinionReloggerLib.Configuration;
using MinionReloggerLib.Interfaces.Objects;

namespace BreakComponent
{
    public partial class SettingsForm : MetroForm
    {
        private readonly Account _account;

        public SettingsForm(Account account)
        {
            InitializeComponent();
            _account = account;
            metroStyleManager.Theme = Config.Singleton.GeneralSettings.ThemeSetting;
            metroStyleManager.Style = Config.Singleton.GeneralSettings.StyleSetting;
            if (account.BreakObject != null)
            {
                numericUpDown1.Value = account.BreakObject.Interval;
                numericUpDown2.Value = account.BreakObject.IntervalDelay;
                numericUpDown3.Value = account.BreakObject.BreakDuration;
                numericUpDown4.Value = account.BreakObject.BreakDurationDelay;
                metroToggle1.Checked = account.BreakObject.BreakEnabled;
            }
        }

        private void BtnOkClick(object sender, EventArgs e)
        {
            MakeBreak();
            Close();
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            Close();
        }

        private void MakeBreak()
        {
            var r = new Random();

            var breakObject = new BreakObject
            {
                TimeSinceLastBreak = DateTime.Now,
                TimeSpanInterval = new TimeSpan(0, (int) numericUpDown1.Value, 0),
                TimeSpanToAddToLastBreak = new TimeSpan(0, r.Next(0, (int) numericUpDown2.Value), 0),
                TimeSpanToPause = new TimeSpan(0, (int) numericUpDown3.Value, 0),
                TimeSpanToWaitLonger = new TimeSpan(0, r.Next(0, (int) numericUpDown4.Value), 0),
                BreakEnabled = metroToggle1.Checked,
                Interval = (int) numericUpDown1.Value,
                IntervalDelay = (int) numericUpDown2.Value,
                BreakDuration = (int) numericUpDown3.Value,
                BreakDurationDelay = (int) numericUpDown4.Value,
            };
            breakObject.TimeActualStartBreak = breakObject.TimeSinceLastBreak + breakObject.TimeSpanInterval +
                                               breakObject.TimeSpanToAddToLastBreak;
            breakObject.TimeActualStopBreak = breakObject.TimeActualStartBreak + breakObject.TimeSpanToPause +
                                              breakObject.TimeSpanToWaitLonger;
            _account.SetBreak(breakObject);
        }
    }
}