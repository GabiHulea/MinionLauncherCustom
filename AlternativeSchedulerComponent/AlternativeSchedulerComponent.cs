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
using System.IO;
using System.Windows.Forms;
using MinionReloggerLib.Core;
using MinionReloggerLib.Enums;
using MinionReloggerLib.Helpers.Language;
using MinionReloggerLib.Interfaces;
using MinionReloggerLib.Interfaces.Objects;
using MinionReloggerLib.Logging;
using MinionReloggerLib.Logging;

namespace AlternativeSchedulerComponent
{
    public class AlternativeSchedulerComponent : IRelogComponent, IRelogComponentExtension
    {
        public IRelogComponent DoWork(Account account, ref ComponentResult result)
        {
            if (Check(account))
            {
                result = new ComponentResult
                    {
                        Result = EComponentResult.Halt,
                        LogMessage = "Halting due to alternative scheduler component settings for {0}.",
                    };
                if (IsReady(account))
                {
                    Update(account);
                    result = new ComponentResult
                        {
                            Result = EComponentResult.Kill,
                            LogMessage = "Stopping due to alternative scheduler component settings for {0}.",
                        };
                }
            }
            else
            {
                result = new ComponentResult
                    {
                        Result = EComponentResult.Ignore,
                    };
            }
            return this;
        }

        public string GetName() { return "AlternativeSchedulerComponent"; }

        public void OnEnable() { }

        public void OnDisable() { }

        public void OnLoad() { }

        public void OnUnload() { }

        public Form ShowSettingsForm(Account account = null) { return new Form(); }

        public ESettingsType GetSettingType() { return ESettingsType.None; }

        public bool Check(Account account)
        {
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "Components\\AlternativeSchedulerSettings\\"))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory +
                                          "Components\\AlternativeSchedulerSettings");
                if (
                    !File.Exists(AppDomain.CurrentDomain.BaseDirectory +
                                 "Components\\AlternativeSchedulerSettings\\settings.ini"))
                {
                    IniFile create = new IniFile(AppDomain.CurrentDomain.BaseDirectory +
                            "Components\\AlternativeSchedulerSettings\\settings.ini");
                    create.IniWriteValue("demoaccount@somedomain.com", "Enabled", "false");
                    DateTime start = DateTime.Now;
                    DateTime end = DateTime.Now.AddHours(1);
                    create.IniWriteValue("demoaccount@somedomain.com", "StartTime", start.Hour + ":" + start.Minute);
                    create.IniWriteValue("demoaccount@somedomain.com", "EndTime", end.Hour + ":" + end.Minute);
                }
            }
            IniFile ini =
                new IniFile(AppDomain.CurrentDomain.BaseDirectory +
                            "Components\\AlternativeSchedulerSettings\\settings.ini");
            string val = ini.IniReadValue(account.LoginName, "Enabled");
            bool result = false;
            if (val != string.Empty && bool.TryParse(val, out result))
            {
                if (result)
                {
                    string startTime = ini.IniReadValue(account.LoginName, "StartTime");
                    if (startTime != string.Empty)
                    {
                        string endTime = ini.IniReadValue(account.LoginName, "EndTime");
                        if (endTime != string.Empty)
                        {
                            string[] splittedStart = startTime.Split(':');
                            string[] splittedEnd = endTime.Split(':');
                            if (splittedStart.Length == 2 && splittedEnd.Length == 2)
                            {
                                int hourStart = 0;
                                int minuteStart = 0;
                                int hourEnd = 0;
                                int minuteEnd = 0;
                                if (Int32.TryParse(splittedStart[0], out hourStart) &&
                                    Int32.TryParse(splittedStart[1], out minuteStart))
                                {
                                    DateTime start = DateTime.Now;
                                    int difference = Math.Abs(start.Hour - hourStart);
                                    if (start.Hour > hourStart)
                                    {
                                        difference = difference*-1;
                                        start = start.AddHours(difference);
                                    }
                                    else
                                    {
                                        start = start.AddHours(difference);
                                    }
                                    difference = Math.Abs(start.Minute - minuteStart);
                                    if (start.Minute > minuteStart)
                                    {
                                        difference = difference*-1;
                                        start = start.AddMinutes(difference);
                                    }
                                    else
                                    {
                                        start = start.AddMinutes(difference);
                                    }
                                    if (Int32.TryParse(splittedEnd[0], out hourEnd) &&
                                        Int32.TryParse(splittedEnd[1], out minuteEnd))
                                    {
                                        DateTime end = start;
                                        end = end.AddHours(hourEnd - hourStart);
                                        end = end.AddMinutes(minuteEnd - minuteStart);

                                        double differenceFuture = (DateTime.Now - end).TotalSeconds;
                                        double differencePast = (start - DateTime.Now).TotalSeconds;
                                        return differenceFuture > 0 || differencePast > 0;
                                    }
                                }
                            }
                        }
                    }
                }

            }
            else
            {
                ini.IniWriteValue(account.LoginName, "Enabled", "false");
                DateTime start = DateTime.Now;
                DateTime end = DateTime.Now.AddHours(1);
                ini.IniWriteValue(account.LoginName, "StartTime", start.Hour + ":" + start.Minute);
                ini.IniWriteValue(account.LoginName, "EndTime", end.Hour + ":" + end.Minute);
            }
            return false;
        }

        public
            bool IsReady(Account account) { return account.Running; }

        public void Update(Account account) { account.Update(); }

        public void PostWork(Account account) { }
    }
}
