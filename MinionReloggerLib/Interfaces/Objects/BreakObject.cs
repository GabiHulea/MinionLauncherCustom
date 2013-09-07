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
using MinionReloggerLib.Configuration;
using MinionReloggerLib.Enums;
using MinionReloggerLib.Helpers.Language;
using MinionReloggerLib.Logging;
using ProtoBuf;

namespace MinionReloggerLib.Interfaces.Objects
{
    [ProtoContract]
    public class BreakObject : IObject
    {
        public BreakObject()
        {
            TimeSinceLastBreak = DateTime.Now;
            TimeActualStartBreak = DateTime.Now;
            TimeActualStopBreak = DateTime.Now;

            TimeSpanInterval = new TimeSpan(0, 0, 0);
            TimeSpanToAddToLastBreak = new TimeSpan(0, 0, 0);
            TimeSpanToPause = new TimeSpan(0, 0, 0);
            TimeSpanToWaitLonger = new TimeSpan(0, 0, 0);

            BreakEnabled = false;
        }

        public DateTime TimeSinceLastBreak { get; set; }

        public DateTime TimeActualStartBreak { get; set; }

        public DateTime TimeActualStopBreak { get; set; }

        public TimeSpan TimeSpanInterval { get; set; }

        public TimeSpan TimeSpanToAddToLastBreak { get; set; }

        public TimeSpan TimeSpanToPause { get; set; }

        public TimeSpan TimeSpanToWaitLonger { get; set; }

        [ProtoMember(1)]
        public bool BreakEnabled { get; set; }

        [ProtoMember(2)]
        public string LoginName { get; set; }

        [ProtoMember(3)]
        public int Interval { get; set; }

        [ProtoMember(4)]
        public int IntervalDelay { get; set; }

        [ProtoMember(5)]
        public int BreakDuration { get; set; }

        [ProtoMember(6)]
        public int BreakDurationDelay { get; set; }

        public bool Check()
        {
            return BreakEnabled && (DateTime.Now - TimeActualStartBreak).TotalSeconds > 0;
        }

        public IObject DoWork()
        {
            return this;
        }

        public bool IsReady()
        {
            return BreakEnabled && (DateTime.Now - TimeActualStopBreak).TotalSeconds <= 0;
        }

        public void Update()
        {
            var r = new Random();
            Account wanted = Config.Singleton.AccountSettings.FirstOrDefault(a => a.LoginName == LoginName);
            TimeSinceLastBreak = wanted != null &&
                                 (wanted.EnableScheduling && (wanted.StartTime - DateTime.Now).TotalSeconds > 0)
                ? wanted.StartTime
                : DateTime.Now;
            TimeSpanInterval = new TimeSpan(0, Interval, 0);
            TimeSpanToAddToLastBreak = new TimeSpan(0, r.Next(0, IntervalDelay), 0);
            TimeSpanToPause = new TimeSpan(0, BreakDuration, 0);
            TimeSpanToWaitLonger = new TimeSpan(0, r.Next(0, BreakDurationDelay), 0);
            TimeActualStartBreak = TimeSinceLastBreak +
                                   TimeSpanInterval +
                                   TimeSpanToAddToLastBreak;
            TimeActualStopBreak = TimeActualStartBreak +
                                  TimeSpanToPause +
                                  TimeSpanToWaitLonger;
            if (wanted != null)
            {
                Logger.LoggingObject.Log(ELogType.Info,
                    LanguageManager.Singleton.GetTranslation(ETranslations.BreakObjectExpired),
                    wanted.LoginName);
            }
            Logger.LoggingObject.Log(ELogType.Info,
                LanguageManager.Singleton.GetTranslation(ETranslations.BreakObjectNew),
                TimeActualStartBreak,
                TimeActualStopBreak);
        }
    }
}