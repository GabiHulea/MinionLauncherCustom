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
using System.IO;
using System.Linq;
using System.Net;
using MinionReloggerLib.Configuration.Settings;
using MinionReloggerLib.Core;
using MinionReloggerLib.Enums;
using MinionReloggerLib.Helpers.Language;
using MinionReloggerLib.Interfaces.Objects;
using MinionReloggerLib.Logging;
using ProtoBuf;

namespace MinionReloggerLib.Configuration
{
    [ProtoContract]
    public class Config
    {
        private static Config _instance;

        [ProtoMember(2)] public List<Account> AccountSettings;
        [ProtoMember(1)] public GeneralSettings GeneralSettings;

        protected Config()
        {
            AccountSettings = new List<Account>();
            GeneralSettings = new GeneralSettings();
        }

        public static Config Singleton
        {
            get { return _instance ?? (_instance = new Config()); }
            set { _instance = value; }
        }

        public bool AccountExists(Account account)
        {
            return AccountSettings.Any(s => account.LoginName == s.LoginName);
        }

        public void DeleteAccount(Account account)
        {
            Account wanted = AccountSettings.FirstOrDefault(
                a => a.LoginName == account.LoginName);
            if (wanted != null)
            {
                AccountSettings.Remove(wanted);
            }
        }

        public void AddAccount(Account account)
        {
            Logger.LoggingObject.Log(ELogType.Debug,
                LanguageManager.Singleton.GetTranslation(ETranslations.ConfigNewAccount));
            account.SetIndex(AccountSettings.Count);
            account.SetPID(uint.MaxValue);
            AccountSettings.Add(account);
        }

        public void EraseAccountList()
        {
            AccountSettings.Clear();
        }

        public static void SaveSettingsToFile()
        {
            try
            {
                using (FileStream file = File.Create("Launcher.bin"))
                {
                    Singleton.GeneralSettings.AllowedIPAddressesAsString.Clear();
                    foreach (IPAddress ip in Singleton.GeneralSettings.AllowedIPAddresses)
                    {
                        Singleton.GeneralSettings.AllowedIPAddressesAsString.Add(ip.ToString());
                    }
                    Singleton.GeneralSettings.ComponentStatus.Clear();
                    foreach (ComponentClass component in ComponentManager.Singleton.GetComponents())
                    {
                        Singleton.GeneralSettings.ComponentStatus.Add(component.Component.GetName(), component.IsEnabled);
                    }
                    Serializer.Serialize(file, Singleton);
                }
            }
            catch (ProtoException ex)
            {
                Logger.LoggingObject.Log(ELogType.Critical,
                    LanguageManager.Singleton.GetTranslation(
                        ETranslations.ConfigErrorDuringEncryption));
                Logger.LoggingObject.Log(ELogType.Critical, ex.Message);
                Logger.LoggingObject.Log(ELogType.Critical,
                    LanguageManager.Singleton.GetTranslation(ETranslations.ConfigOldSaveFileDeleted));
                try
                {
                    File.Delete("Launcher.bin");
                }
                catch (UnauthorizedAccessException ex2)
                {
                    Logger.LoggingObject.Log(ELogType.Critical, ex2.Message);
                }
                catch (IOException ex3)
                {
                    Logger.LoggingObject.Log(ELogType.Critical, ex3.Message);
                }
            }
            catch (UnauthorizedAccessException ex2)
            {
                Logger.LoggingObject.Log(ELogType.Critical, ex2.Message);
            }
            catch (IOException ex3)
            {
                Logger.LoggingObject.Log(ELogType.Critical, ex3.Message);
            }
        }

        public static bool LoadConfig(bool manual)
        {
            if (File.Exists("Launcher.bin"))
            {
                try
                {
                    LoadConfigFromFile();
                    LanguageManager.Singleton.SetNewLanguage((ELanguages) Singleton.GeneralSettings.CurrentLanguage);
                    UpdateComponentList();
                }
                catch (ProtoException ex)
                {
                    Logger.LoggingObject.Log(ELogType.Critical,
                        LanguageManager.Singleton.GetTranslation(
                            ETranslations.ConfigErrorDuringEncryption));
                    Logger.LoggingObject.Log(ELogType.Critical, ex.Message);
                    Logger.LoggingObject.Log(ELogType.Critical,
                        LanguageManager.Singleton.GetTranslation(
                            ETranslations.ConfigOldSaveFileDeleted));
                    try
                    {
                        File.Delete("Launcher.bin");
                    }
                    catch (UnauthorizedAccessException ex2)
                    {
                        Logger.LoggingObject.Log(ELogType.Critical, ex2.Message);
                    }
                    catch (IOException ex3)
                    {
                        Logger.LoggingObject.Log(ELogType.Critical, ex3.Message);
                    }
                }
                catch (UnauthorizedAccessException ex2)
                {
                    Logger.LoggingObject.Log(ELogType.Critical, ex2.Message);
                }
                catch (IOException ex3)
                {
                    Logger.LoggingObject.Log(ELogType.Critical, ex3.Message);
                }

                HandleFixingOfLists();

                DumpIntegersToLog();
                return true;
            }
            if (manual)
            {
                Logger.LoggingObject.Log(ELogType.Error,
                    LanguageManager.Singleton.GetTranslation(
                        ETranslations.ConfigCouldntFindValidSaveFile));
            }
            return false;
        }

        private static void UpdateComponentList()
        {
            foreach (var component in Singleton.GeneralSettings.ComponentStatus)
            {
                if (component.Value)
                {
                    ComponentManager.Singleton.EnableComponent(component.Key);
                }
                else
                {
                    ComponentManager.Singleton.DisableComponent(component.Key);
                }
            }
        }

        private static void LoadConfigFromFile()
        {
            using (FileStream file = File.OpenRead("Launcher.bin"))
            {
                Singleton = Serializer.Deserialize<Config>(file);
            }
        }

        private static void DumpIntegersToLog()
        {
            Logger.LoggingObject.Log(ELogType.Verbose,
                LanguageManager.Singleton.GetTranslation(ETranslations.ConfigDumpIntegers),
                Singleton.GeneralSettings.PollingDelay,
                Singleton.GeneralSettings.LaunchDelay,
                Singleton.GeneralSettings.RestartDelay,
                Singleton.GeneralSettings.FrozenTime);
        }

        private static void HandleFixingOfLists()
        {
            for (int i = 0; i < Singleton.AccountSettings.Count; i++)
            {
                Singleton.AccountSettings[i].SetPID(uint.MaxValue);
                Singleton.AccountSettings[i].SetIndex(i);
            }
            foreach (string ipAsString in Singleton.GeneralSettings.AllowedIPAddressesAsString)
            {
                IPAddress final;
                if (IPAddress.TryParse(ipAsString, out final))
                    Singleton.GeneralSettings.AddIP(final);
            }
        }
    }
}