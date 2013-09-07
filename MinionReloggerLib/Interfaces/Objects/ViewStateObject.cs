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
using System.Diagnostics;
using System.Threading;
using MinionReloggerLib.Configuration;
using MinionReloggerLib.Enums;
using MinionReloggerLib.Helpers.Language;
using MinionReloggerLib.Imports;
using MinionReloggerLib.Logging;

namespace MinionReloggerLib.Interfaces.Objects
{
    public class ViewStateObject : IObject
    {
        public ViewStateObject(Account account, DateTime time, Process process, EViewState viewstate)
        {
            Account = account;
            Time = time;
            Process = process;
            ViewState = viewstate;
        }

        public Account Account { get; private set; }
        public DateTime Time { get; private set; }
        public Process Process { get; private set; }
        public EViewState ViewState { get; private set; }

        public bool Check()
        {
            return IsReady() &&
                   (DateTime.Now - Process.StartTime).TotalSeconds > Config.Singleton.GeneralSettings.FrozenTime &&
                   ViewState != EViewState.ViewGameplay;
        }

        public IObject DoWork()
        {
            if (!Process.HasExited)
            {
                try
                {
                    GW2MinionLauncher.KillInstance((uint) Process.Id);
                    Thread.Sleep(3000);
                }
                catch
                {
                }
            }
            Update();
            return this;
        }

        public bool IsReady()
        {
            return (DateTime.Now - Time).TotalSeconds > Config.Singleton.GeneralSettings.FrozenTime;
        }

        public void Update()
        {
            Account.SetLastStopTime(DateTime.Now);
            Account.SetLastCrash(DateTime.Now);
            Logger.LoggingObject.Log(ELogType.Critical,
                LanguageManager.Singleton.GetTranslation(
                    ETranslations.ViewStateObjectClientStuckSomewhere),
                Account.LoginName, Config.Singleton.GeneralSettings.FrozenTime);
        }

        public bool IsViewState(EViewState toCompare)
        {
            return ViewState == toCompare;
        }
    }
}