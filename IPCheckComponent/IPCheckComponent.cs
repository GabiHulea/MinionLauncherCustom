﻿/*****************************************************************************
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

using System.Windows.Forms;
using MinionReloggerLib.Configuration;
using MinionReloggerLib.Core;
using MinionReloggerLib.Enums;
using MinionReloggerLib.Helpers.Language;
using MinionReloggerLib.Helpers.MyIP;
using MinionReloggerLib.Interfaces;
using MinionReloggerLib.Interfaces.Objects;

namespace IPCheckComponent
{
    public class IPCheckComponent : IRelogComponent, IRelogComponentExtension
    {
        public IRelogComponent DoWork(Account account, ref ComponentResult result)
        {
            if (Check(account))
            {
                result = new ComponentResult
                {
                    Result = EComponentResult.Continue,
                };
                if (IsReady(account))
                {
                    result = new ComponentResult
                    {
                        Result = EComponentResult.Halt,
                        LogMessage = LanguageManager.Singleton.GetTranslation(ETranslations.IPCheckComponentHalt),
                    };
                    if (account.Running)
                        result = new ComponentResult
                        {
                            Result = EComponentResult.Kill,
                            LogMessage =
                                LanguageManager.Singleton.GetTranslation(ETranslations.IPCheckComponentKill),
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

        public string GetName()
        {
            return "IPCheckComponent";
        }

        public void OnEnable()
        {
        }

        public void OnDisable()
        {
        }

        public void OnLoad()
        {
        }

        public void OnUnload()
        {
        }

        public Form ShowSettingsForm(Account account = null)
        {
            return new SettingsForm();
        }

        public ESettingsType GetSettingType()
        {
            return ESettingsType.Global;
        }

        public bool Check(Account account)
        {
            return Config.Singleton.GeneralSettings.CheckForIP;
        }

        public bool IsReady(Account account)
        {
            return !GetMyIP.ListContainsMyIPAddress(Config.Singleton.GeneralSettings.AllowedIPAddresses);
        }

        public void Update(Account account)
        {
        }

        public void PostWork(Account account)
        {
        }
    }
}