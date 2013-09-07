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
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Threading;
using MinionReloggerLib.Configuration;
using MinionReloggerLib.Imports;

namespace MinionReloggerLib.Helpers.VersionControl
{
    public static class VersionControl
    {
        public static bool CheckVersionBot()
        {
            const string remoteUri = "http://patcher.gw2.mmominion.com/Gw2MinionFiles/";
            const string fileName = "GameVersion.txt";
            try
            {
                var myWebClient = new WebClient
                {
                    Proxy = null,
                    CachePolicy =
                        new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore)
                };
                uint minionVersion = Convert.ToUInt32(myWebClient.DownloadString(remoteUri + fileName));
                uint apiVer = GW2MinionLauncher.BuildNumberFromApi();
                if (minionVersion != apiVer)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return true;
            }
        }

        public static void Update()
        {
            try
            {
                string toWrite = "";
                foreach (var account in Config.Singleton.AccountSettings)
                {
                    if (account.ShouldBeRunning)
                    {
                        toWrite += ";" + account.LoginName;
                    }
                }
                toWrite = toWrite.Remove(0, 1);
                IniFile ini = new IniFile(".\\MinionFiles\\RunningAccounts.ini");
                if (!String.IsNullOrEmpty(toWrite))
                {
                    ini.IniWriteValue("RunningAccounts", "Accounts", toWrite);
                    ini.IniWriteValue("RunningAccounts", "Active", "True");
                }
                else
                {
                    ini.IniWriteValue("RunningAccounts", "Active", "False");
                }
                Version LocalVersion, RemoteVersion;
                string remoteUri = "http://patcher.gw2.mmominion.com/Updater/";
                string fileName = "Updater.exe";

                var myWebClient = new WebClient();
                myWebClient.Proxy = null;
                myWebClient.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
                if (File.Exists(fileName))
                {
                    FileVersionInfo fv;
                    fv = FileVersionInfo.GetVersionInfo(fileName);
                    LocalVersion = new Version(fv.FileVersion.Replace(',', '.'));
                    string updaterVersion = myWebClient.DownloadString(remoteUri + "UpdaterVer.txt");
                    RemoteVersion = new Version(updaterVersion);
                    if (LocalVersion < RemoteVersion)
                    {
                        File.SetAttributes(fileName, FileAttributes.Normal);
                        File.Delete(fileName);
                        myWebClient.DownloadFile(remoteUri + fileName, fileName);
                    }
                }
                else
                {
                    //we dont have the damn file anyway so get it!
                    myWebClient.DownloadFile(remoteUri + fileName, fileName);
                }
                Thread.Sleep(1000);
                //now run the damn file to update the noobs
                Process currentproc = Process.GetCurrentProcess();
                var startInfo = new ProcessStartInfo();

                startInfo.FileName = fileName;
                startInfo.Arguments = currentproc.Id.ToString();
                Process startedProc = Process.Start(startInfo);
                startedProc.WaitForExit();
                Thread.Sleep(1000);
            }
            catch
            {

            }
        }
    }
}