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
using System.Runtime.InteropServices;
using System.Text;
using MinionReloggerLib.Enums;
using MinionReloggerLib.Logging;

namespace MinionReloggerLib.Imports
{
    public static class GW2MinionLauncher
    {
        [DllImport(".\\MinionFiles\\GW2MinionLauncherDLL.dll", CharSet = CharSet.Unicode, SetLastError = true,
            CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint LaunchAccount([MarshalAs(UnmanagedType.LPWStr)] string exePath,
            [MarshalAs(UnmanagedType.LPWStr)] string account,
            [MarshalAs(UnmanagedType.LPWStr)] string password, bool noSound,
            bool useBeta);

        [DllImport(".\\MinionFiles\\GW2MinionLauncherDLL.dll", CharSet = CharSet.Unicode, SetLastError = true,
            CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint LaunchGW([MarshalAs(UnmanagedType.LPWStr)] string exePath,
            [MarshalAs(UnmanagedType.LPWStr)] string account,
            [MarshalAs(UnmanagedType.LPWStr)] string password, bool noGui, bool noSound);

        [DllImport(".\\MinionFiles\\GW2MinionLauncherDLL.dll", CharSet = CharSet.Unicode, SetLastError = true,
            CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint LaunchAccountFromPath([MarshalAs(UnmanagedType.LPWStr)] string startupPath,
            [MarshalAs(UnmanagedType.LPWStr)] string exePath,
            [MarshalAs(UnmanagedType.LPWStr)] string account,
            [MarshalAs(UnmanagedType.LPWStr)] string password,
            bool noSound, bool useBeta);

        [DllImport(".\\MinionFiles\\GW2MinionLauncherDLL.dll", CharSet = CharSet.Unicode,
            CallingConvention = CallingConvention.Cdecl,
            SetLastError = true)]
        internal static extern bool KillInstance(uint pid);

        [DllImport(".\\MinionFiles\\GW2MinionLauncherDLL.dll", CharSet = CharSet.Unicode,
            CallingConvention = CallingConvention.Cdecl,
            SetLastError = true)]
        internal static extern bool AccountName(UInt32 pid, StringBuilder name, int bufSize);

        internal static string GetAccountName(uint pid)
        {
            try
            {
                var buf = new StringBuilder(255);
                try
                {
                    Process process = Process.GetProcessById((int) pid);
                    if (!process.HasExited && (DateTime.Now - process.StartTime).TotalMilliseconds > 5000)
                        AccountName(pid, buf, buf.Capacity);
                }
                catch
                {
                }
                return buf.ToString();
            }
            catch (Exception ex)
            {
                Logger.LoggingObject.Log(ELogType.Critical, ex.Message);
            }
            return "<null>";
        }

        [DllImport(".\\MinionFiles\\GW2MinionLauncherDLL.dll", CharSet = CharSet.Unicode,
            CallingConvention = CallingConvention.Cdecl,
            SetLastError = true)]
        internal static extern bool AttachToPid(uint pid, bool useBeta);

        [DllImport(".\\MinionFiles\\GW2MinionLauncherDLL.dll", CharSet = CharSet.Unicode,
            CallingConvention = CallingConvention.Cdecl,
            SetLastError = true)]
        internal static extern uint BuildNumber(uint pid);

        [DllImport(".\\MinionFiles\\GW2MinionLauncherDLL.dll", CharSet = CharSet.Unicode,
            CallingConvention = CallingConvention.Cdecl,
            SetLastError = true)]
        public static extern uint BuildNumberFromApi();

        [DllImport(".\\MinionFiles\\GW2MinionLauncherDLL.dll", CharSet = CharSet.Unicode,
            CallingConvention = CallingConvention.Cdecl,
            SetLastError = true)]
        public static extern int ViewState(uint pid);
    }
}