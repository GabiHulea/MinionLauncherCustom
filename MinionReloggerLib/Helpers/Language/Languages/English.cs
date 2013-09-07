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

using MinionReloggerLib.Enums;

namespace MinionReloggerLib.Helpers.Language.Languages
{
    public class English : Language
    {
        public English()
        {
            // class: BreakObject
            Translations.Add(ETranslations.BreakObjectExpired, "Break has expired for {0}, starting new cycle!");
            Translations.Add(ETranslations.BreakObjectNew, "New Start Break: {0}, New End Break: {1}.");

            // class ComponentManager
            Translations.Add(ETranslations.ComponentManagerAddedComponent,
                "A component with the name {0} has been added to the list.");
            Translations.Add(ETranslations.ComponentManagerDisableComponent,
                "A component with the name {0} has been disabled.");
            Translations.Add(ETranslations.ComponentManagerEnableComponent,
                "A component with the name {0} has been enabled.");

            // class: Config
            Translations.Add(ETranslations.ConfigNewAccount, "Added new Account object.");
            Translations.Add(ETranslations.ConfigErrorDuringEncryption, "An error has occurred during data encryption!");
            Translations.Add(ETranslations.ConfigOldSaveFileDeleted,
                "Old save file has been deleted, must have been a different version or corrupt!");
            Translations.Add(ETranslations.ConfigCouldntFindValidSaveFile,
                "Couldn't find a valid save file. Please create a new save file.");
            Translations.Add(ETranslations.ConfigDumpIntegers,
                "Polling Delay: {0}, Launch Delay: {1}, Restart Delay: {2}, Frozen Time: {3}.");

            // class: DataProtector
            Translations.Add(ETranslations.DataProtectorErrorOccured, "An error has occurred during data encryption!");
            Translations.Add(ETranslations.DataProtectorDeletedSaveFile,
                "Old save file has been deleted, must have been a different version or corrupt!");

            // class: General Settings
            Translations.Add(ETranslations.GeneralSettingsGW2PathChanged, "GW2 Path has been changed to: [{0}].");
            Translations.Add(ETranslations.GeneralSettingsPollingDelayChanged,
                "Polling delay has been changed to: [{0}].");
            Translations.Add(ETranslations.GeneralSettingsFrozenTimeChanged,
                "Frozen time has been changed to: [{0}].");
            Translations.Add(ETranslations.GeneralSettingsLaunchDelayChanged, "Launch delay has been changed to: [{0}].");
            Translations.Add(ETranslations.GeneralSettingsRestartDelayChanged,
                "Restart delay has been changed to: [{0}].");
            Translations.Add(ETranslations.GeneralSettingsColorChanged, "Switched to color: {0}.");
            Translations.Add(ETranslations.GeneralSettingsThemeChanged, "Switched to theme: {0}.");
            Translations.Add(ETranslations.GeneralSettingsMinimizeWindowsChanged,
                "Minimize windows has been changed to: {0}.");
            Translations.Add(ETranslations.GeneralSettingsCheckForIPChanged,
                "Check for IP has been changed to: {0}.");
            Translations.Add(ETranslations.GeneralSettingsAddedIP,
                "Added IP address {0} to the list of allowed addresses.");
            Translations.Add(ETranslations.GeneralSettingsDeletedIP,
                "Deleted IP address {0} from the list of allowed addresses.");

            // class: GW2ManagerThread
            Translations.Add(ETranslations.GW2ManagerThreadStoppedResponding,
                "A GW 2 instance, running {0}, has stopped responding. Keeping an eye out.");
            Translations.Add(ETranslations.GW2ManagerThreadStartedRespondingAgain,
                "The GW 2 instance, running {0}, has started responding again.");

            // class: InputBox
            Translations.Add(ETranslations.InputBoxOk, "OK");
            Translations.Add(ETranslations.InputBoxCancel, "Cancel");

            // class: KillWorker
            Translations.Add(ETranslations.KillWorkerStoppingProcess, "Stopping process with PID {0}.");

            // class: StartWorker
            Translations.Add(ETranslations.StartWorkerLaunchingInstance, "Launching instance for {0} with {1}.");
            Translations.Add(ETranslations.StartWorkerScanningForExisting, "Scanning existing GW2 instances.");
            Translations.Add(ETranslations.StartWorkerFoundWantedProcess,
                "Found wanted process for {0}, no need to launch.");
            Translations.Add(ETranslations.StartWorkerAttachingTo, "Attaching to {0} with {1}.");

            // class: ViewStateObject
            Translations.Add(ETranslations.ViewStateObjectClientStuckSomewhere,
                "The GW2 instance, running {0}, has not been in-game for {1} seconds, scheduling it for a restart.");

            // class: WatchObject
            Translations.Add(ETranslations.WatchObjectNotRespondingFor,
                "The GW 2 instance, running {0}, has not been responding for 90 seconds, scheduling it for a restart.");

            // component: BreakComponent
            Translations.Add(ETranslations.BreakComponentPauseEvery, "Pause every"); // ... minutes 
            Translations.Add(ETranslations.BreakComponentDelayPrePause, "Random delay pre-pause of"); // ... minutes
            Translations.Add(ETranslations.BreakComponentPause, "Pause time of"); // ... minutes
            Translations.Add(ETranslations.BreakComponentDelayPostPause, "Random delay post-pause of"); // ... minutes
            Translations.Add(ETranslations.BreakComponentEnableBreaks, "Enable Breaks?");
            Translations.Add(ETranslations.BreakComponentMinutes, "minutes");
            Translations.Add(ETranslations.BreakComponentOk, "OK");
            Translations.Add(ETranslations.BreakComponentCancel, "Cancel");

            // component: IPCheckComponent
            Translations.Add(ETranslations.IPCheckComponentDeleteIP, "Delete IP");
            Translations.Add(ETranslations.IPCheckComponentAddNewIP, "Add New IP");
            Translations.Add(ETranslations.IPCheckComponentAddRange, "Add Range");
            Translations.Add(ETranslations.IPCheckComponentEnableIPChecks, "Enable IP Checks?");
            Translations.Add(ETranslations.IPCheckComponentIPToAdd, "IP To Add");
            Translations.Add(ETranslations.IPCheckComponentEnterIP,
                "Please enter the desired IP to add (in the format: 127.0.0.1).");
            Translations.Add(ETranslations.IPCheckComponentAddingNewIPRange,
                "Adding new IP range, the last pair of digits will be skipped, 192.168.1.1 becomes 192.168.1.0-255. Enter a valid IP address though!");
            Translations.Add(ETranslations.IPCheckComponentIPRangeToAdd, "IP range To Add");
            Translations.Add(ETranslations.IPCheckComponentEnterIPRange,
                "Please enter the desired IP range to add (in the format: 192.168.1.0).");
            Translations.Add(ETranslations.IPCheckComponentOk, "OK");
            Translations.Add(ETranslations.IPCheckComponentCancel, "Cancel");

            // component: LaunchDelayComponent
            Translations.Add(ETranslations.LaunchDelayComponentCurrentValue, "Current value:");
            Translations.Add(ETranslations.LaunchDelayComponentSeconds, "seconds");
            Translations.Add(ETranslations.LaunchDelayComponentSetNew, "Set New");
            Translations.Add(ETranslations.LaunchDelayComponentOk, "OK");
            Translations.Add(ETranslations.LaunchDelayComponentCancel, "Cancel");
            Translations.Add(ETranslations.LaunchDelayComponentLaunchDelay, "Launch Delay");
            Translations.Add(ETranslations.LaunchDelayComponentEntireDesiredDelay,
                "Please enter the desired delay between GW2 launches (!minimum: 20, in seconds!).");

            // component: RestartDelayComponent
            Translations.Add(ETranslations.RestartDelayComponentCurrentValue, "Current value:");
            Translations.Add(ETranslations.RestartDelayComponentSeconds, "seconds");
            Translations.Add(ETranslations.RestartDelayComponentSetNew, "Set New");
            Translations.Add(ETranslations.RestartDelayComponentOk, "OK");
            Translations.Add(ETranslations.RestartDelayComponentCancel, "Cancel");
            Translations.Add(ETranslations.RestartDelayComponentRestartDelay, "Restart Delay");
            Translations.Add(ETranslations.RestartDelayComponentEntireDesiredDelay,
                "Please enter the desired restart delay (to avoid max key limits) (!in seconds!).");

            // component: SchedulerComponent
            Translations.Add(ETranslations.SchedulerComponentStartTime, "Start Time:");
            Translations.Add(ETranslations.SchedulerComponentStopTime, "Stop Time:");
            Translations.Add(ETranslations.SchedulerComponentDays, "Days (24h cycles):");
            Translations.Add(ETranslations.SchedulerComponentTimeInMinutes, "Time in minutes:");
            Translations.Add(ETranslations.SchedulerComponentEnableScheduler, "Enable Scheduler?");
            Translations.Add(ETranslations.SchedulerComponentOk, "OK");
            Translations.Add(ETranslations.SchedulerComponentCancel, "Cancel");
            Translations.Add(ETranslations.SchedulerComponentSaveSettings,
                "Saving schedule settings for {0} (minutes: {1}).");
            // class: AccountControl
            Translations.Add(ETranslations.AccountControlStart, "Start");
            Translations.Add(ETranslations.AccountControlStop, "Stop");
            Translations.Add(ETranslations.AccountControlManage, "Manage");
            Translations.Add(ETranslations.AccountControlSettings, "Settings");
            Translations.Add(ETranslations.AccountControlEnabled, "Enabled");
            Translations.Add(ETranslations.AccountControlDisabled, "Disabled");
            Translations.Add(ETranslations.AccountControlLoginName, "Login Name");
            Translations.Add(ETranslations.AccountControlStatus, "Status");

            // GUI: AccountForm
            Translations.Add(ETranslations.AccountFormLoginName, "Login Name");
            Translations.Add(ETranslations.AccountFormPassword, "Password");
            Translations.Add(ETranslations.AccountFormNoSound, "No Sound?");
            Translations.Add(ETranslations.AccountFormCancel, "Cancel");
            Translations.Add(ETranslations.AccountFormDelete, "Delete");
            Translations.Add(ETranslations.AccountFormOk, "OK");
            Translations.Add(ETranslations.AccountFormAddAccount, "Add Account");
            Translations.Add(ETranslations.AccountFormEditAccount, "Edit Account");

            // GUI: MainForm
            Translations.Add(ETranslations.MainFormStartAll, "Start All");
            Translations.Add(ETranslations.MainFormStopAll, "Stop All");
            Translations.Add(ETranslations.MainFormChangeTheme, "Change Theme");
            Translations.Add(ETranslations.MainFormChangeColor, "Change Color");
            Translations.Add(ETranslations.MainFormAddAccount, "Add Account");
            Translations.Add(ETranslations.MainFormOpenSettings, "Open Settings");
            Translations.Add(ETranslations.MainFormSetGW2EXEPath, "Set GW2 EXE Path");
            Translations.Add(ETranslations.MainFormSetPollingDelay, "Set Polling Delay");
            Translations.Add(ETranslations.MainFormSetFrozenTime, "Set Frozen Time");
            Translations.Add(ETranslations.MainFormMinimizeGW2Windows, "Minimize GW2 Windows?");
            Translations.Add(ETranslations.MainFormEnabledComponents, "Enabled Components");
            Translations.Add(ETranslations.MainFormDisabledComponents, "Disabled Components");
            Translations.Add(ETranslations.MainFormSetLanguage, "Set Language");
            Translations.Add(ETranslations.MainFormMoveToRight, "Move To Right");
            Translations.Add(ETranslations.MainFormMoveToLeft, "Move To Left");
            Translations.Add(ETranslations.MainFormLoad, "Load");
            Translations.Add(ETranslations.MainFormSave, "Save");
            Translations.Add(ETranslations.MainFormAccounts, "Accounts");
            Translations.Add(ETranslations.MainFormSettings, "Settings");
            Translations.Add(ETranslations.MainFormLog, "Log");
            Translations.Add(ETranslations.MainFormFreshConfig,
                "Hello, since you are starting with a fresh config, you will have to go through a few steps of settings first.");
            Translations.Add(ETranslations.MainFormWelcome, "Wecome");
            Translations.Add(ETranslations.MainFormWhichComponents,
                "Alright, you now have to configure which components you want to use for the relogger. If you are a novice, I recommend enabling them all. You are able to do so by clicking the \"Move To Left\" button.");
            Translations.Add(ETranslations.MainFormFirstStep, "First Step");
            Translations.Add(ETranslations.MainFormPleaseSave,
                "After you are done, please don't forget to click Save, or you will have to do these steps over, again.");
            Translations.Add(ETranslations.MainFormTip, "Tip!");
            Translations.Add(ETranslations.MainFormEnabled, "Enabled");
            Translations.Add(ETranslations.MainFormDisabled, "Disabled");
            Translations.Add(ETranslations.MainFormLocateGW2Short, "Locate GW2 Executable");
            Translations.Add(ETranslations.MainFormLocateGW2Long, "Please locate your GW2 executable.");
            Translations.Add(ETranslations.MainFormPollingDelayShort, "Polling Delay");
            Translations.Add(ETranslations.MainFormPollingDelayLong,
                "Please enter the desired polling delay (!minimum: 3, in seconds!).");
            Translations.Add(ETranslations.MainFormFrozenTimeShort, "Frozen Time");
            Translations.Add(ETranslations.MainFormFrozenTimeLong,
                "Please enter the desired time after which a GW2 instance is considered frozen/stuck (!minimum: 60, in seconds!).");
            Translations.Add(ETranslations.MainFormLoginName, "Login Name");
            Translations.Add(ETranslations.MainFormStatus, "Status");

            // component: BasicStopComponent
            Translations.Add(ETranslations.BasicStopComponentStop,
                "Stopping instance for {0}, should not be running (disabled).");
            Translations.Add(ETranslations.BasicStopComponentHalt,
                "Halting start for {0}, should not be running (disabled).");

            // component: BreakComponent
            Translations.Add(ETranslations.BreakComponentKill,
                "Stopping instance for {0}, should not be running due to break settings.");
            Translations.Add(ETranslations.BreakComponentHalt,
                "Halting start for {0}, should not be starting due to break settings.");

            // component: IPCheckComponent
            Translations.Add(ETranslations.IPCheckComponentHalt,
                "Halting start for {0}, should not be running. Current IP has not been permitted.");
            Translations.Add(ETranslations.IPCheckComponentKill,
                "Stopping instance for {0}, should not be running. Current IP has not been permitted.");

            // component: LaunchDelayComponent
            Translations.Add(ETranslations.LaunchDelayComponentHalt,
                "Halting start for {0}, should not be running. Launch Delay timer has not expired yet.");

            // component: RestartDelayComponent
            Translations.Add(ETranslations.RestartDelayComponentHalt,
                "Halting start for {0}, should not be running. Restart Delay timer has not expired yet.");

            // component: SchedulerComponent
            Translations.Add(ETranslations.SchedulerComponentHalt,
                "Halting start for {0}, should not be running due to scheduler settings.");
            Translations.Add(ETranslations.SchedulerComponentKill,
                "Stopping instance for {0}, should not be running due to scheduler settings.");
        }

        public override string GetLanguageDescription()
        {
            return "English";
        }

        public override ELanguages GetLanguage()
        {
            return ELanguages.English;
        }
    }
}