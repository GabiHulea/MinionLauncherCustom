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
using MinionReloggerLib.Interfaces;
using MinionReloggerLib.Interfaces.Objects;
using MinionReloggerLib.Logging;

namespace ComponentTest
{
    public class TestComponent : IRelogComponent
    {
        public IRelogComponent DoWork(Account account, ref ComponentResult result)
        {
            Logger.LoggingObject.Log("[TestComponent] DoWork");
            return this;
        }

        public string GetName()
        {
            Logger.LoggingObject.Log("[TestComponent] GetName");
            return "TestComponent (external DLL test)";
        }

        public void OnEnable()
        {
            Logger.LoggingObject.Log("[TestComponent] OnEnable");
        }

        public void OnDisable()
        {
            Logger.LoggingObject.Log("[TestComponent] OnDisable");
        }

        public void OnLoad()
        {
            Logger.LoggingObject.Log("[TestComponent] OnLoad");
        }

        public void OnUnload()
        {
            Logger.LoggingObject.Log("[TestComponent] OnUnload");
        }

        public Form ShowSettingsForm(Account account = null)
        {
            return new Form();
        }

        public ESettingsType GetSettingType()
        {
            return ESettingsType.None;
        }
    }
}