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
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using MinionReloggerLib.Configuration;
using MinionReloggerLib.Core;
using MinionReloggerLib.Enums;
using MinionReloggerLib.Helpers.Language;
using MinionReloggerLib.Helpers.Memory;
using MinionReloggerLib.Helpers.VersionControl;
using MinionReloggerLib.Imports;
using MinionReloggerLib.Interfaces.Objects;
using MinionReloggerLib.Interfaces.RelogWorkers;
using MinionReloggerLib.Logging;

namespace MinionReloggerLib.Threads.Implementation
{
    internal class InstanceThread : IRelogThread
    {
        private static readonly Dictionary<Process, WatchObject> FrozenGW2Windows =
            new Dictionary<Process, WatchObject>();

        private static readonly Dictionary<Process, ViewStateObject> DeadGW2Windows =
            new Dictionary<Process, ViewStateObject>();

        private static bool _checkAll;
        private readonly bool _enableViewStateChecks;
        private readonly Thread _instanceThread;
        private uint _buildNumber;
        //private uint _buildNumberNeedUpdate;
        private int _delay;
        private bool _isRunning;
        private bool _keepAlive;
        private bool _needDelay;

        public InstanceThread()
        {
            _instanceThread = new Thread(DoWork)
            {
                IsBackground = true,
            };
            _delay = 0;
            _needDelay = false;
            _isRunning = false;
            _keepAlive = false;
            _enableViewStateChecks = true;
            try
            {
                _buildNumber = GW2MinionLauncher.BuildNumberFromApi();
            }
            catch
            {
                _buildNumber = 0;
            }
        }

        public Thread GetThread()
        {
            return _instanceThread;
        }

        public string GetName()
        {
            return "InstanceThread";
        }

        public bool IsRunning()
        {
            return _instanceThread.IsAlive && _isRunning;
        }

        public void Delay(int delay)
        {
            _delay = delay;
            _needDelay = true;
        }

        public void Stop()
        {
            _isRunning = false;
        }

        public void Start()
        {
            if (!_keepAlive)
            {
                _keepAlive = true;
                _instanceThread.Start();
            }
            _isRunning = true;
        }

        public void DoWork()
        {
            while (_keepAlive)
            {
                while (_isRunning)
                {
                    try
                    {
                        if (_needDelay)
                        {
                            Thread.Sleep(_delay);
                        }

                        foreach (Account account in Config.Singleton.AccountSettings.ToArray())
                        {
                            var results = new List<ComponentResult>();
                            foreach (
                                ComponentClass component in
                                    ComponentManager.Singleton.GetComponents().ToArray().Where(c => c.IsEnabled))
                            {
                                var result = new ComponentResult();
                                component.Component.DoWork(account, ref result);
                                results.Add(result);
                            }
                            if (results.Any(r => r.Result == EComponentResult.KillForced))
                            {
                                if (Config.Singleton.GeneralSettings.ExtensiveLogging)
                                {
                                    foreach (
                                        ComponentResult componentResult in
                                            results.Where(r => r.Result == EComponentResult.KillForced))
                                    {
                                        Logger.LoggingObject.Log(ELogType.Debug, componentResult.LogMessage,
                                            account.LoginName);
                                    }
                                }
                                new KillWorker().DoWork(account).Update(account);
                            }
                            else if (results.Any(r => r.Result == EComponentResult.HaltForced))
                            {
                                if (Config.Singleton.GeneralSettings.ExtensiveLogging)
                                {
                                    foreach (
                                        ComponentResult componentResult in
                                            results.Where(r => r.Result == EComponentResult.HaltForced))
                                    {
                                        Logger.LoggingObject.Log(ELogType.Debug, componentResult.LogMessage,
                                            account.LoginName);
                                    }
                                }
                                account.SetLastStopTime(DateTime.Now);
                            }
                            else if (results.Any(r => r.Result == EComponentResult.StartForced))
                            {
                                if (Config.Singleton.GeneralSettings.ExtensiveLogging)
                                {
                                    foreach (
                                        ComponentResult componentResult in
                                            results.Where(r => r.Result == EComponentResult.StartForced))
                                    {
                                        Logger.LoggingObject.Log(ELogType.Debug, componentResult.LogMessage,
                                            account.LoginName);
                                    }
                                }
                                new StartWorker().DoWork(account);
                            }
                            else if (results.Any(r => r.Result == EComponentResult.ContinueForced))
                            {
                            }
                            else if (results.Any(r => r.Result == EComponentResult.Kill))
                            {
                                if (Config.Singleton.GeneralSettings.ExtensiveLogging)
                                {
                                    foreach (
                                        ComponentResult componentResult in
                                            results.Where(r => r.Result == EComponentResult.Kill))
                                    {
                                        Logger.LoggingObject.Log(ELogType.Debug, componentResult.LogMessage,
                                            account.LoginName);
                                    }
                                }
                                new KillWorker().DoWork(account).Update(account);
                            }
                            else if (results.Any(r => r.Result == EComponentResult.Halt))
                            {
                                if (Config.Singleton.GeneralSettings.ExtensiveLogging)
                                {
                                    foreach (
                                        ComponentResult componentResult in
                                            results.Where(r => r.Result == EComponentResult.Halt))
                                    {
                                        Logger.LoggingObject.Log(ELogType.Debug, componentResult.LogMessage,
                                            account.LoginName);
                                    }
                                }
                            }
                            else if (results.Any(r => r.Result == EComponentResult.Start))
                            {
                                if (VersionControl.CheckVersionBot())
                                    new StartWorker().DoWork(account).Update(account);
                                else
                                    VersionControl.Update();
                            }
                            else if (results.Any(r => r.Result == EComponentResult.Continue))
                            {
                            }
                            else if (results.Any(r => r.Result == EComponentResult.Ignore))
                            {
                            }
                            else if (results.Any(r => r.Result == EComponentResult.Default))
                            {
                            }
                        }
                        User32.EnumWindows(EnumTheWindows, IntPtr.Zero);

                        IEnumerable<Process> gw2Processes = UpdateListWithRemainingGW2Processes();

                        if (_checkAll || Config.Singleton.GeneralSettings.PollingDelay >= 60)
                        {
                            Process[] enumerable = gw2Processes as Process[] ?? gw2Processes.ToArray();
                            foreach (Process gw2Process in enumerable)
                            {
                                UpdateProcessIdForMatchingScheduler(gw2Process);
                                if (!gw2Process.Responding)
                                {
                                    if (FrozenGW2Windows.All(p => p.Key.Id != gw2Process.Id))
                                    {
                                        AddUnresponsiveProcessToTheList(gw2Process);
                                    }
                                    else
                                    {
                                        GetRidOfProcessesThatHaveBeenFrozenForLong(gw2Process);
                                    }
                                }
                                else
                                {
                                    if (_enableViewStateChecks)
                                    {
                                        var viewState = (EViewState) GW2MinionLauncher.ViewState((uint) gw2Process.Id);
                                        //GetViewState(gw2Process);
                                        if (viewState != EViewState.ViewGameplay &&
                                            DeadGW2Windows.All(p => p.Key.Id != gw2Process.Id))
                                        {
                                            AddDeadProcessToTheList(gw2Process, viewState);
                                        }
                                        else if (viewState != EViewState.ViewGameplay)
                                        {
                                            GetRidOfProcessesThatHaveBeenIdleForLong(gw2Process, viewState);
                                        }
                                        else
                                        {
                                            RemoveWorkingWindowsFromTheList(gw2Process);
                                        }
                                    }
                                    RemoveRespondingWindowsFromTheList(gw2Process);
                                    MinimizeGW2Windows(gw2Process);
                                }
                            }
                            //if (_buildNumberNeedUpdate == 0)
                            //{
                            //    try
                            //    {
                            //        _buildNumber = GW2MinionLauncher.BuildNumberFromApi();
                            //        //VersionChecker.CheckForUpdates();
                            //    }
                            //    catch
                            //    {
                            //        _buildNumber = 0;
                            //    }
                            //    _buildNumberNeedUpdate = 0;
                            //    try
                            //    {
                            //        if (enumerable.Any())
                            //            _enableViewStateChecks =
                            //                GW2MinionLauncher.BuildNumber((uint) enumerable.First().Id) == _buildNumber;
                            //        && _buildNumber == Pointers.BuildNumber;
                            //    }
                            //    catch
                            //    {
                            //        _enableViewStateChecks = false;
                            //    }
                            //}
                            //_buildNumberNeedUpdate++;
                            //if (_buildNumberNeedUpdate > 30)
                            //    _buildNumberNeedUpdate = 0;
                        }
                        _checkAll = !_checkAll;
                    }
                    catch (Exception)
                    {
                    }
                    Thread.Sleep(Config.Singleton.GeneralSettings.PollingDelay*1000);
                }
                Thread.Sleep(10000);
            }
        }


        protected static bool EnumTheWindows(IntPtr hWnd, IntPtr lParam)
        {
            int size = User32.GetWindowTextLength(hWnd);
            if (size++ > 0 && User32.IsWindowVisible(hWnd))
            {
                var sb = new StringBuilder(size);
                User32.GetWindowText(hWnd, sb, size);
                if (sb.ToString().ToLower() == System.IO.Path.GetFileNameWithoutExtension(Config.Singleton.GeneralSettings.GW2Path).ToLower() ||
                    sb.ToString().ToLower() == "guild wars 2 game client")
                {
                    try
                    {
                        Process firstOrDefault =
                            Process.GetProcesses().FirstOrDefault(p => p.MainWindowHandle == hWnd);
                        Account wanted =
                            Config.Singleton.AccountSettings.FirstOrDefault(
                                a => firstOrDefault != null && a.PID == firstOrDefault.Id);
                        if (firstOrDefault != null)
                        {
                            if (wanted != null)
                            {
                                wanted.SetLastCrash(DateTime.Now);
                                wanted.SetLastStopTime(DateTime.Now);
                            }
                            firstOrDefault.Kill();
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            return true;
        }

        private static EViewState GetViewState(Process process)
        {
            var toReturn = EViewState.Default;
            try
            {
                if (Memory.OpenProcess(process.Id))
                {
                    var addr = Memory.Read<uint>(Memory.BaseAddress + Pointers.ViewStatePtr);
                    if (addr >= Memory.BaseAddress)
                    {
                        toReturn = (EViewState) Memory.Read<int>(addr + 0x34);
                    }
                }
            }
            catch (Exception)
            {
            }
            return toReturn;
        }

        private static IEnumerable<Process> UpdateListWithRemainingGW2Processes()
        {
            List<Process> gw2ProcessesList = new List<Process>();
            Process[] gw2Processes = Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(Config.Singleton.GeneralSettings.GW2Path));
            if (gw2Processes.Count()>0)
                gw2ProcessesList.AddRange(gw2Processes.ToList());
            foreach (Account accs in Config.Singleton.AccountSettings)
            {
                if (accs.UseCustomGW2Path == true)
                {
                    gw2Processes = Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(accs.CustomGW2Path));
                    if (gw2Processes.Count() > 0)
                        gw2ProcessesList.AddRange(gw2Processes.ToList());
                }
            }
            for (int i = 0; i < FrozenGW2Windows.Count; i++)
            {
                if (FrozenGW2Windows.ElementAt(i).Key.HasExited)
                {
                    FrozenGW2Windows.Remove(FrozenGW2Windows.ElementAt(i).Key);
                    i--;
                }
            }
            for (int i = 0; i < DeadGW2Windows.Count; i++)
            {
                if (DeadGW2Windows.ElementAt(i).Key.HasExited)
                {
                    DeadGW2Windows.Remove(DeadGW2Windows.ElementAt(i).Key);
                    i--;
                }
            }
            gw2Processes = gw2ProcessesList.ToArray();
            return gw2Processes;
        }

        private static void UpdateProcessIdForMatchingScheduler(Process gw2Process)
        {
            if (Config.Singleton.AccountSettings.All(a => a.PID != gw2Process.Id))
            {
                string name = GW2MinionLauncher.GetAccountName((uint) gw2Process.Id);
                Account wanted =
                    Config.Singleton.AccountSettings.FirstOrDefault(a => a.LoginName == name);
                if (wanted != null)
                {
                    wanted.SetPID((uint) gw2Process.Id);
                    wanted.SetLastStartTime(DateTime.Now);
                }
            }
        }

        private static void AddUnresponsiveProcessToTheList(Process gw2Process)
        {
            Account wanted =
                Config.Singleton.AccountSettings.FirstOrDefault(a => a.PID == gw2Process.Id);
            if (wanted != null)
            {
                FrozenGW2Windows.Add(gw2Process, new WatchObject(wanted, DateTime.Now, gw2Process));
                Logger.LoggingObject.Log(ELogType.Critical,
                    LanguageManager.Singleton.GetTranslation(
                        ETranslations.GW2ManagerThreadStoppedResponding),
                    wanted.LoginName);
            }
            else
            {
                FrozenGW2Windows.Add(gw2Process, new WatchObject(new Account(), DateTime.Now, gw2Process));
            }
        }

        private static void AddDeadProcessToTheList(Process gw2Process, EViewState viewState)
        {
            Account wanted =
                Config.Singleton.AccountSettings.FirstOrDefault(a => a.PID == gw2Process.Id);
            if (wanted != null)
            {
                DeadGW2Windows.Add(gw2Process, new ViewStateObject(wanted, DateTime.Now, gw2Process, viewState));
            }
            else
            {
                DeadGW2Windows.Add(gw2Process, new ViewStateObject(new Account(), DateTime.Now, gw2Process, viewState));
            }
        }


        private static void GetRidOfProcessesThatHaveBeenFrozenForLong(Process gw2Process)
        {
            try
            {
                KeyValuePair<Process, WatchObject> wanted =
                    FrozenGW2Windows.FirstOrDefault(p => p.Key.Id == gw2Process.Id);
                if (wanted.Key != null && (DateTime.Now - wanted.Value.Time).TotalSeconds > 90)
                {
                    if (wanted.Value.Account != null && wanted.Value.Check())
                    {
                        try
                        {
                            wanted.Value.DoWork();
                        }
                        catch
                        {
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LoggingObject.Log(ELogType.Error, ex.Message);
            }
        }

        private static void GetRidOfProcessesThatHaveBeenIdleForLong(Process gw2Process, EViewState viewState)
        {
            KeyValuePair<Process, ViewStateObject> wanted =
                DeadGW2Windows.FirstOrDefault(p => p.Key.Id == gw2Process.Id);
            if (wanted.Key != null &&
                (DateTime.Now - wanted.Value.Time).TotalSeconds > Config.Singleton.GeneralSettings.FrozenTime)
            {
                if (viewState != EViewState.ViewGameplay && wanted.Value.Account != null && wanted.Value.Check())
                {
                    wanted.Value.DoWork();
                }
            }
        }

        private static void RemoveRespondingWindowsFromTheList(Process gw2Process)
        {
            KeyValuePair<Process, WatchObject> wanted =
                FrozenGW2Windows.FirstOrDefault(p => p.Key.Id == gw2Process.Id);
            if (wanted.Key != null)
            {
                if (wanted.Value.Account != null)
                    Logger.LoggingObject.Log(ELogType.Critical,
                        LanguageManager.Singleton.GetTranslation(
                            ETranslations.GW2ManagerThreadStartedRespondingAgain),
                        wanted.Value.Account.LoginName);
                FrozenGW2Windows.Remove(wanted.Key);
            }
        }

        private static void RemoveWorkingWindowsFromTheList(Process gw2Process)
        {
            KeyValuePair<Process, ViewStateObject> wanted =
                DeadGW2Windows.FirstOrDefault(p => p.Key.Id == gw2Process.Id);
            if (wanted.Key != null)
            {
                DeadGW2Windows.Remove(wanted.Key);
            }
        }

        private static void MinimizeGW2Windows(Process gw2Process)
        {
            if (Config.Singleton.GeneralSettings.MinimizeWindows &&
                Config.Singleton.AccountSettings.Any(a => a.PID == gw2Process.Id))
            {
                try
                {
                    IntPtr hwnd = Process.GetProcessById(gw2Process.Id).MainWindowHandle;
                    if (!hwnd.Equals(IntPtr.Zero))
                    {
                        User32.ShowWindowAsync(hwnd, User32.SW_SHOWMINIMIZED);
                    }
                }
                catch
                {
                }
            }
        }
    }
}