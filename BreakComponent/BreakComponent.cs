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

using System.Windows.Forms;
using MinionReloggerLib.Core;
using MinionReloggerLib.Enums;
using MinionReloggerLib.Helpers.Language;
using MinionReloggerLib.Interfaces;
using MinionReloggerLib.Interfaces.Objects;

namespace BreakComponent
{
    public class BreakComponent : IRelogComponent, IRelogComponentExtension
    {
        public IRelogComponent DoWork(Account account, ref ComponentResult result)
        {
            if (account.BreakObject != null && account.BreakObject.Check())
            {
                if (account.BreakObject.IsReady())
                {
                    result = Check(account)
                        ? new ComponentResult
                        {
                            Result = EComponentResult.Kill,
                            LogMessage =
                                LanguageManager.Singleton.GetTranslation(ETranslations.BreakComponentKill),
                        }
                        : new ComponentResult
                        {
                            Result = EComponentResult.Halt,
                            LogMessage =
                                LanguageManager.Singleton.GetTranslation(ETranslations.BreakComponentHalt),
                        };
                }
                else
                {
                    result = new ComponentResult
                    {
                        Result = EComponentResult.Continue,
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
            if (IsReady(account))
            {
                Update(account);
            }
            return this;
        }

        public string GetName()
        {
            return "BreakComponent";
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
            return new SettingsForm(account);
        }

        public ESettingsType GetSettingType()
        {
            return ESettingsType.AccountSpecific;
        }

        public bool Check(Account account)
        {
            return account.Running;
        }

        public bool IsReady(Account account)
        {
            return account.BreakObject != null && (account.BreakObject.Check() && !account.BreakObject.IsReady());
        }

        public void Update(Account account)
        {
            account.BreakObject.Update();
        }

        public void PostWork(Account account)
        {
        }
    }
}