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
    public class Chinese : Language
    {
        public Chinese()
        {
            // class: BreakObject
            Translations.Add(ETranslations.BreakObjectExpired, " 休息结束{0}, 开始新的循环!");
            Translations.Add(ETranslations.BreakObjectNew, "开始新的休息: {0}, 结束新的休息: {1}.");

            // class ComponentManager
            Translations.Add(ETranslations.ComponentManagerAddedComponent,
                "一个名为 {0}组建已经添加到清单.");
            Translations.Add(ETranslations.ComponentManagerDisableComponent,
                "一个名为 {0} 已经停止.");
            Translations.Add(ETranslations.ComponentManagerEnableComponent,
                "一个名为 {0} 已经打开.");

            // class: Config
            Translations.Add(ETranslations.ConfigNewAccount, "添家新的账号.");
            Translations.Add(ETranslations.ConfigErrorDuringEncryption, "在加密过程中发生一个错误!");
            Translations.Add(ETranslations.ConfigOldSaveFileDeleted,
                "老的保存的文件被删除, 是版本或者冲突的原因!");
            Translations.Add(ETranslations.ConfigCouldntFindValidSaveFile,
                "不能找一个有效的保存文件. 请新建一个保存文件.");
            Translations.Add(ETranslations.ConfigDumpIntegers,
                "间隔延迟: {0}, 启动延迟: {1}, 重启延迟: {2}, 冻结时间: {3}.");

            // class: DataProtector
            Translations.Add(ETranslations.DataProtectorErrorOccured, "在加密过程中发生一个错误!");
            Translations.Add(ETranslations.DataProtectorDeletedSaveFile,
                "老的保存的文件被删除, 是版本或者冲突的原因!");

            // class: General Settings
            Translations.Add(ETranslations.GeneralSettingsGW2PathChanged, "GW2 路径已经变更为: [{0}].");
            Translations.Add(ETranslations.GeneralSettingsPollingDelayChanged,
                "间隔延迟已经变更为: [{0}].");
            Translations.Add(ETranslations.GeneralSettingsFrozenTimeChanged,
                "冻结时间已经变更为: [{0}].");
            Translations.Add(ETranslations.GeneralSettingsLaunchDelayChanged, "启动延迟已经变更为: [{0}].");
            Translations.Add(ETranslations.GeneralSettingsRestartDelayChanged,
                "重启延迟已经变更为: [{0}].");
            Translations.Add(ETranslations.GeneralSettingsColorChanged, "切换颜色为: {0}.");
            Translations.Add(ETranslations.GeneralSettingsThemeChanged, "切换主题为: {0}.");
            Translations.Add(ETranslations.GeneralSettingsMinimizeWindowsChanged,
                "窗口最小化已经变更为: {0}.");
            Translations.Add(ETranslations.GeneralSettingsCheckForIPChanged,
                "ip检测已经变更为: {0}.");
            Translations.Add(ETranslations.GeneralSettingsAddedIP,
                "添加IP {0} 到允许的地址清单.");
            Translations.Add(ETranslations.GeneralSettingsDeletedIP,
                "删除IP {0} 从允许的地址清单.");

            // class: GW2ManagerThread
            Translations.Add(ETranslations.GW2ManagerThreadStoppedResponding,
                "一个正在运行的GW 2窗口 {0}, 已经停止响应. 请注意.");
            Translations.Add(ETranslations.GW2ManagerThreadStartedRespondingAgain,
                "一个正在运行的GW 2窗口 {0}, 已经再次开始响应.");

            // class: InputBox
            Translations.Add(ETranslations.InputBoxOk, "好");
            Translations.Add(ETranslations.InputBoxCancel, "取消");

            // class: KillWorker
            Translations.Add(ETranslations.KillWorkerStoppingProcess, "停止进程 PID {0}.");

            // class: StartWorker
            Translations.Add(ETranslations.StartWorkerLaunchingInstance, "启动窗口 {0} 用 {1}.");
            Translations.Add(ETranslations.StartWorkerScanningForExisting, "扫描现有的GW2 窗口.");
            Translations.Add(ETranslations.StartWorkerFoundWantedProcess,
                "发现进程 {0}, 勿需启动.");
            Translations.Add(ETranslations.StartWorkerAttachingTo, "注入 {0} 用 {1}.");

            // class: ViewStateObject
            Translations.Add(ETranslations.ViewStateObjectClientStuckSomewhere,
                "正在运行的GW2 窗口 {0}, 已经离开游戏 {1} 秒, 计划重启.");

            // class: WatchObject
            Translations.Add(ETranslations.WatchObjectNotRespondingFor,
                "正在运行的GW2 窗口 {0}, 停止响应 90 秒, 计划重启.");

            // component: BreakComponent
            Translations.Add(ETranslations.BreakComponentPauseEvery, "暂停每隔"); // ... minutes 
            Translations.Add(ETranslations.BreakComponentDelayPrePause, "自由延迟（暂停前）"); // ... minutes
            Translations.Add(ETranslations.BreakComponentPause, "暂停时间"); // ... minutes
            Translations.Add(ETranslations.BreakComponentDelayPostPause, "自由延迟（暂停后）"); // ... minutes
            Translations.Add(ETranslations.BreakComponentEnableBreaks, "打开休息?");
            Translations.Add(ETranslations.BreakComponentMinutes, "分钟");
            Translations.Add(ETranslations.BreakComponentOk, "好");
            Translations.Add(ETranslations.BreakComponentCancel, "取消");

            // component: IPCheckComponent
            Translations.Add(ETranslations.IPCheckComponentDeleteIP, "删除 IP");
            Translations.Add(ETranslations.IPCheckComponentAddNewIP, "添加新的 IP");
            Translations.Add(ETranslations.IPCheckComponentAddRange, "添加 IP段");
            Translations.Add(ETranslations.IPCheckComponentEnableIPChecks, "打开IP检测?");
            Translations.Add(ETranslations.IPCheckComponentIPToAdd, "添加的IP");
            Translations.Add(ETranslations.IPCheckComponentEnterIP,
                "请输入想要添加的IP (格式为: 127.0.0.1).");
            Translations.Add(ETranslations.IPCheckComponentAddingNewIPRange,
                "添加新的IP段, 最后的那段将被忽略, 192.168.1.1 变为 192.168.1.0-255. 输入有效的IP地址!");
            Translations.Add(ETranslations.IPCheckComponentIPRangeToAdd, "添加的IP段");
            Translations.Add(ETranslations.IPCheckComponentEnterIPRange,
                "请输入想要添加的IP段 (格式为: 192.168.1.0).");
            Translations.Add(ETranslations.IPCheckComponentOk, "好");
            Translations.Add(ETranslations.IPCheckComponentCancel, "取消");

            // component: LaunchDelayComponent
            Translations.Add(ETranslations.LaunchDelayComponentCurrentValue, "当前值:");
            Translations.Add(ETranslations.LaunchDelayComponentSeconds, "秒");
            Translations.Add(ETranslations.LaunchDelayComponentSetNew, "设置新的");
            Translations.Add(ETranslations.LaunchDelayComponentOk, "好");
            Translations.Add(ETranslations.LaunchDelayComponentCancel, "取消");
            Translations.Add(ETranslations.LaunchDelayComponentLaunchDelay, "启动延迟");
            Translations.Add(ETranslations.LaunchDelayComponentEntireDesiredDelay,
                "请输入启动窗口的延迟时间 (!最少: 20, 秒!).");

            // component: RestartDelayComponent
            Translations.Add(ETranslations.RestartDelayComponentCurrentValue, "当前值:");
            Translations.Add(ETranslations.RestartDelayComponentSeconds, "秒");
            Translations.Add(ETranslations.RestartDelayComponentSetNew, "设置新的");
            Translations.Add(ETranslations.RestartDelayComponentOk, "好");
            Translations.Add(ETranslations.RestartDelayComponentCancel, "取消");
            Translations.Add(ETranslations.RestartDelayComponentRestartDelay, "延迟重置");
            Translations.Add(ETranslations.RestartDelayComponentEntireDesiredDelay,
                "请输入一个重启的延迟 (为了避免外挂窗口数的限制) (!秒!).");

            // component: SchedulerComponent
            Translations.Add(ETranslations.SchedulerComponentStartTime, "开始时间:");
            Translations.Add(ETranslations.SchedulerComponentStopTime, "停止时间:");
            Translations.Add(ETranslations.SchedulerComponentDays, "天 (24小时 循环):");
            Translations.Add(ETranslations.SchedulerComponentTimeInMinutes, "时间（分钟）:");
            Translations.Add(ETranslations.SchedulerComponentEnableScheduler, "打开计划任务?");
            Translations.Add(ETranslations.SchedulerComponentOk, "好");
            Translations.Add(ETranslations.SchedulerComponentCancel, "取消");
            Translations.Add(ETranslations.SchedulerComponentSaveSettings,
                "保存计划任务设置 {0} (分: {1}).");
            // class: AccountControl
            Translations.Add(ETranslations.AccountControlStart, "开始");
            Translations.Add(ETranslations.AccountControlEnabled, "打开");
            Translations.Add(ETranslations.AccountControlStop, "停止");
            Translations.Add(ETranslations.AccountControlManage, "管理");
            Translations.Add(ETranslations.AccountControlSettings, "设置");
            Translations.Add(ETranslations.AccountControlDisabled, "关闭");
            Translations.Add(ETranslations.AccountControlLoginName, "账号");
            Translations.Add(ETranslations.AccountControlStatus, "状态");

            // GUI: AccountForm
            Translations.Add(ETranslations.AccountFormLoginName, "账号");
            Translations.Add(ETranslations.AccountFormPassword, "密码");
            Translations.Add(ETranslations.AccountFormNoSound, "静音?");
            Translations.Add(ETranslations.AccountFormCancel, "取消");
            Translations.Add(ETranslations.AccountFormDelete, "删除");
            Translations.Add(ETranslations.AccountFormOk, "好");
            Translations.Add(ETranslations.AccountFormAddAccount, "添加账号");
            Translations.Add(ETranslations.AccountFormEditAccount, "编辑账号");

            // GUI: MainForm
            Translations.Add(ETranslations.MainFormStartAll, "全部开始");
            Translations.Add(ETranslations.MainFormStopAll, "全部停止");
            Translations.Add(ETranslations.MainFormChangeTheme, "改变主题");
            Translations.Add(ETranslations.MainFormChangeColor, "改变颜色");
            Translations.Add(ETranslations.MainFormAddAccount, "添加账号");
            Translations.Add(ETranslations.MainFormOpenSettings, "打开设置");
            Translations.Add(ETranslations.MainFormSetGW2EXEPath, "设置GW2路径");
            Translations.Add(ETranslations.MainFormSetPollingDelay, "设置间隔延迟");
            Translations.Add(ETranslations.MainFormSetFrozenTime, "设置冻结时间");
            Translations.Add(ETranslations.MainFormMinimizeGW2Windows, "GW2窗口最小化?");
            Translations.Add(ETranslations.MainFormEnabledComponents, "打开组件");
            Translations.Add(ETranslations.MainFormDisabledComponents, "关闭组件");
            Translations.Add(ETranslations.MainFormSetLanguage, "设置语言");
            Translations.Add(ETranslations.MainFormMoveToRight, "移动到右边");
            Translations.Add(ETranslations.MainFormMoveToLeft, "移动到左边");
            Translations.Add(ETranslations.MainFormLoad, "加载");
            Translations.Add(ETranslations.MainFormSave, "保存");
            Translations.Add(ETranslations.MainFormAccounts, "账号");
            Translations.Add(ETranslations.MainFormSettings, "设置");
            Translations.Add(ETranslations.MainFormLog, "日志");
            Translations.Add(ETranslations.MainFormFreshConfig,
                "Hello, 你必须先通过几步设置，才能开始一个新的设置, .");
            Translations.Add(ETranslations.MainFormWelcome, "欢迎");
            Translations.Add(ETranslations.MainFormWhichComponents,
                " 好吧，你必须为自动登陆器配置相关组件，如果你是新手，请开启全部组件，请通过\"移动到左边\" 键去做.");
            Translations.Add(ETranslations.MainFormFirstStep, "第一步");
            Translations.Add(ETranslations.MainFormPleaseSave,
                "在你配置完成后，请记住保存设置, 若没有，你讲不得不重新设置一次.");
            Translations.Add(ETranslations.MainFormTip, "提示!");
            Translations.Add(ETranslations.MainFormEnabled, "打开");
            Translations.Add(ETranslations.MainFormDisabled, "关闭");
            Translations.Add(ETranslations.MainFormLocateGW2Short, "定位 GW2 执行程序（.exe)");
            Translations.Add(ETranslations.MainFormLocateGW2Long, "请定位 GW2 执行程序（.exe).");
            Translations.Add(ETranslations.MainFormPollingDelayShort, "间隔延迟");
            Translations.Add(ETranslations.MainFormPollingDelayLong,
                "请输入间隔延迟 (!最少: 3, 秒!).");
            Translations.Add(ETranslations.MainFormFrozenTimeShort, "冻结时间");
            Translations.Add(ETranslations.MainFormFrozenTimeLong,
                "请输入一个你认为游戏窗口被冻结或者卡主的时间 (!最少: 60, 秒!).");
            Translations.Add(ETranslations.MainFormLoginName, "账号");
            Translations.Add(ETranslations.MainFormStatus, "状态");

            // component: BasicStopComponent
            Translations.Add(ETranslations.BasicStopComponentStop, "停止窗口 {0}, 应该没有在运行 (关闭).");
            Translations.Add(ETranslations.BasicStopComponentHalt, "挂起窗口 {0}, 应该没有在运行 （关闭）.");

            // component: BreakComponent
            Translations.Add(ETranslations.BreakComponentKill, "停止窗口{0}, 由休息设置引起的.");
            Translations.Add(ETranslations.BreakComponentHalt, "挂起窗口 {0}, 由休息设置引起的.");

            // component: IPCheckComponent
            Translations.Add(ETranslations.IPCheckComponentHalt, "挂起窗口 {0}, 当前IP没有被允许.");
            Translations.Add(ETranslations.IPCheckComponentKill, "停止窗口 {0}, 当前IP没有被允许.");

            // component: LaunchDelayComponent
            Translations.Add(ETranslations.LaunchDelayComponentHalt, "挂起窗口{0}，启动延迟计时器还没到期.");

            // component: RestartDelayComponent
            Translations.Add(ETranslations.RestartDelayComponentHalt, "挂起窗口{0}, 重启延迟计时器还没到期.");

            // component: SchedulerComponentHalt,
            Translations.Add(ETranslations.SchedulerComponentHalt, "挂起窗口 {0}, 计划任务设置.");
            Translations.Add(ETranslations.SchedulerComponentKill, "停止窗口 {0}, 计划任务设置.");
        }

        public override string GetLanguageDescription()
        {
            return "中文";
        }

        public override ELanguages GetLanguage()
        {
            return ELanguages.Chinese;
        }
    }
}