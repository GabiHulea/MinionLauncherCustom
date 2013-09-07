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

namespace MinionReloggerLib.Enums
{
    public enum ETranslations
    {
        /////////////////////////////
        /// CLASSES               ///
        /////////////////////////////
        // class: BreakObject
        BreakObjectExpired,
        BreakObjectNew,

        // class: ComponentManager
        ComponentManagerAddedComponent,
        ComponentManagerEnableComponent,
        ComponentManagerDisableComponent,

        // class: Config
        ConfigNewAccount,
        ConfigErrorDuringEncryption,
        ConfigOldSaveFileDeleted,
        ConfigCouldntFindValidSaveFile,
        ConfigDumpIntegers,

        // class: DataProtector
        DataProtectorErrorOccured,
        DataProtectorDeletedSaveFile,

        // class: General Settings
        GeneralSettingsGW2PathChanged,
        GeneralSettingsPollingDelayChanged,
        GeneralSettingsFrozenTimeChanged,
        GeneralSettingsLaunchDelayChanged,
        GeneralSettingsRestartDelayChanged,
        GeneralSettingsColorChanged,
        GeneralSettingsThemeChanged,
        GeneralSettingsMinimizeWindowsChanged,
        GeneralSettingsCheckForIPChanged,
        GeneralSettingsAddedIP,
        GeneralSettingsDeletedIP,

        // class: GW2ManagerThread
        GW2ManagerThreadStoppedResponding,
        GW2ManagerThreadStartedRespondingAgain,

        // class: InputBox
        InputBoxOk,
        InputBoxCancel,

        // class: KillWorker
        KillWorkerStoppingProcess,

        // class: StartWorker
        StartWorkerScanningForExisting,
        StartWorkerLaunchingInstance,
        StartWorkerFoundWantedProcess,
        StartWorkerAttachingTo,

        // class: ViewStateObject
        ViewStateObjectClientStuckSomewhere,

        // class: WatchObject
        WatchObjectNotRespondingFor,

        /////////////////////////////
        /// GUI FORMS AND RELATED ///
        /////////////////////////////
        // component: BreakComponent
        BreakComponentPauseEvery,
        BreakComponentDelayPrePause,
        BreakComponentPause,
        BreakComponentDelayPostPause,
        BreakComponentEnableBreaks,
        BreakComponentMinutes,
        BreakComponentOk,
        BreakComponentCancel,

        // component: IPCheckComponent
        IPCheckComponentDeleteIP,
        IPCheckComponentAddNewIP,
        IPCheckComponentAddRange,
        IPCheckComponentEnableIPChecks,
        IPCheckComponentIPToAdd,
        IPCheckComponentEnterIP,
        IPCheckComponentAddingNewIPRange,
        IPCheckComponentIPRangeToAdd,
        IPCheckComponentEnterIPRange,
        IPCheckComponentOk,
        IPCheckComponentCancel,

        // component: LaunchDelayComponent
        LaunchDelayComponentCurrentValue,
        LaunchDelayComponentSeconds,
        LaunchDelayComponentSetNew,
        LaunchDelayComponentOk,
        LaunchDelayComponentCancel,
        LaunchDelayComponentLaunchDelay,
        LaunchDelayComponentEntireDesiredDelay,

        // component: RestartDelayComponent
        RestartDelayComponentCurrentValue,
        RestartDelayComponentSeconds,
        RestartDelayComponentSetNew,
        RestartDelayComponentOk,
        RestartDelayComponentCancel,
        RestartDelayComponentRestartDelay,
        RestartDelayComponentEntireDesiredDelay,

        // component: SchedulerComponent
        SchedulerComponentStartTime,
        SchedulerComponentStopTime,
        SchedulerComponentDays,
        SchedulerComponentTimeInMinutes,
        SchedulerComponentEnableScheduler,
        SchedulerComponentOk,
        SchedulerComponentCancel,
        SchedulerComponentSaveSettings,

        // class: AccountControl
        AccountControlStart,
        AccountControlStop,
        AccountControlManage,
        AccountControlSettings,
        AccountControlDisabled,
        AccountControlEnabled,
        AccountControlLoginName,
        AccountControlStatus,

        // GUI: AccountForm
        AccountFormLoginName,
        AccountFormPassword,
        AccountFormNoSound,
        AccountFormCancel,
        AccountFormDelete,
        AccountFormOk,
        AccountFormAddAccount,
        AccountFormEditAccount,

        // GUI: MainForm
        MainFormStartAll,
        MainFormStopAll,
        MainFormChangeTheme,
        MainFormChangeColor,
        MainFormAddAccount,
        MainFormOpenSettings,
        MainFormSetGW2EXEPath,
        MainFormSetPollingDelay,
        MainFormSetFrozenTime,
        MainFormMinimizeGW2Windows,
        MainFormEnabledComponents,
        MainFormDisabledComponents,
        MainFormMoveToRight,
        MainFormMoveToLeft,
        MainFormSetLanguage,
        MainFormLoad,
        MainFormSave,
        MainFormAccounts,
        MainFormSettings,
        MainFormLog,
        MainFormFreshConfig,
        MainFormWelcome,
        MainFormWhichComponents,
        MainFormFirstStep,
        MainFormPleaseSave,
        MainFormTip,
        MainFormEnabled,
        MainFormDisabled,
        MainFormLocateGW2Short,
        MainFormLocateGW2Long,
        MainFormPollingDelayShort,
        MainFormPollingDelayLong,
        MainFormFrozenTimeShort,
        MainFormFrozenTimeLong,
        MainFormLoginName,
        MainFormStatus,

        /////////////////////////////
        /// COMPONENTS            ///
        /////////////////////////////
        // component: BasicStartComponent
        BasicStartComponentStart,

        // component: BasicStopComponent
        BasicStopComponentStop,
        BasicStopComponentHalt,

        // component: BreakComponent
        BreakComponentKill,
        BreakComponentHalt,

        // component: IPCheckComponent
        IPCheckComponentHalt,
        IPCheckComponentKill,

        // component: LaunchDelayComponent
        LaunchDelayComponentHalt,

        // component: RestartDelayComponent
        RestartDelayComponentHalt,

        // component: SchedulerComponent
        SchedulerComponentHalt,
        SchedulerComponentKill,
    }
}