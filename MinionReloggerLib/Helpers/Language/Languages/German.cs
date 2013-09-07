/*****************************************************************************
*                                                                            *
*  MinionReloggerLib 0.x Alpha -- https://github.com/Vipeax/MinionRelogger   *
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
    public class German : Language
    {
        public German()
        {
            // class: BreakObject
            Translations.Add(ETranslations.BreakObjectExpired, "Pause für {0} vorbei, starte neue Runde!");
            Translations.Add(ETranslations.BreakObjectNew, "Neue Startpause für: {0}, Neue End-Pause für: {1}.");

            // class ComponentManager
            Translations.Add(ETranslations.ComponentManagerAddedComponent,
                "Eine Komponente mit dem Namen {0} wurde zur Liste hinzugefügt.");
            Translations.Add(ETranslations.ComponentManagerDisableComponent,
                " Eine Komponente mit dem Namen {0} wurde deaktiviert.");
            Translations.Add(ETranslations.ComponentManagerEnableComponent,
                " Eine Komponente mit dem Namen {0} wurde aktiviert.");

            // class: Config
            Translations.Add(ETranslations.ConfigNewAccount, "Neues Accountobject hinzugefügt.");
            Translations.Add(ETranslations.ConfigErrorDuringEncryption,
                "Ein Fehler ist bei der Verschlüsselung aufgetreten!");
            Translations.Add(ETranslations.ConfigOldSaveFileDeleted,
                "Alte Speicherdatei gelöscht, es musste sich um eine alte version gehandelt haben!");
            Translations.Add(ETranslations.ConfigCouldntFindValidSaveFile,
                "Keine gültigen Speicherdatei gefunden. Bitte erstelle eine neue Speicherdatei.");
            Translations.Add(ETranslations.ConfigDumpIntegers,
                "Abfrageverzögerung: {0}, Startverzögerung: {1}, Neustartverzögerung: {2}, Einfrierzeit: {3}.");

            // class: DataProtector
            Translations.Add(ETranslations.DataProtectorErrorOccured,
                " Ein Fehler ist bei der Verschlüsselung aufgetreten!");
            Translations.Add(ETranslations.DataProtectorDeletedSaveFile,
                " Alte Speicherdatei gelöscht, es musste sich um eine alte Version gehandelt haben!");

            // class: General Settings
            Translations.Add(ETranslations.GeneralSettingsGW2PathChanged, "GW2 Pfad zu: [{0}] Geändert.");
            Translations.Add(ETranslations.GeneralSettingsPollingDelayChanged,
                " Abfrageverzögerung geändert: [{0}].");
            Translations.Add(ETranslations.GeneralSettingsFrozenTimeChanged,
                "Einfrierzeit geändert: [{0}].");
            Translations.Add(ETranslations.GeneralSettingsLaunchDelayChanged, " Startverzögerung geändert: [{0}].");
            Translations.Add(ETranslations.GeneralSettingsRestartDelayChanged,
                " Neustartverzögerung geändert: [{0}].");
            Translations.Add(ETranslations.GeneralSettingsColorChanged, "Farbwechsel: {0}.");
            Translations.Add(ETranslations.GeneralSettingsThemeChanged, "Themenwechsel: {0}.");
            Translations.Add(ETranslations.GeneralSettingsMinimizeWindowsChanged,
                "Fensterminimieren geändert: {0}.");
            Translations.Add(ETranslations.GeneralSettingsCheckForIPChanged,
                "IP Check geändert: {0}.");
            Translations.Add(ETranslations.GeneralSettingsAddedIP,
                "IP {0} zur Liste erlaubter IPs hinzugefügt.");
            Translations.Add(ETranslations.GeneralSettingsDeletedIP,
                "IP {0} von der Liste erlaubter gelöscht.");

            // class: GW2ManagerThread
            Translations.Add(ETranslations.GW2ManagerThreadStoppedResponding,
                "GW2 Instanz, {0}, reagiert nicht mehr.");
            Translations.Add(ETranslations.GW2ManagerThreadStartedRespondingAgain,
                " GW2 Instanz, {0}, reagiert wieder.");

            // class: InputBox
            Translations.Add(ETranslations.InputBoxOk, "OK");
            Translations.Add(ETranslations.InputBoxCancel, "Abbrechen");

            // class: KillWorker
            Translations.Add(ETranslations.KillWorkerStoppingProcess, "Stoppe Prozess mit PID {0}.");

            // class: StartWorker
            Translations.Add(ETranslations.StartWorkerLaunchingInstance, "Starte Instanz für {0} mit {1}.");
            Translations.Add(ETranslations.StartWorkerScanningForExisting, "Scanne nach existierenden GW2 Instanzen.");
            Translations.Add(ETranslations.StartWorkerFoundWantedProcess,
                "Prozess für {0} gefunden, brauch nicht gestartet werden.");
            Translations.Add(ETranslations.StartWorkerAttachingTo, "Verbinde zu {0} mit {1}.");

            // class: ViewStateObject
            Translations.Add(ETranslations.ViewStateObjectClientStuckSomewhere,
                "Die GW2 Instanz {0}, ist nicht im Spiel seit {1} Sekunden, plane Neustart.");

            // class: WatchObject
            Translations.Add(ETranslations.WatchObjectNotRespondingFor,
                " Die GW2 Instanz {0}, antwortet seit 90sec nicht mehr, plane Neustart");

            // component: BreakComponent
            Translations.Add(ETranslations.BreakComponentPauseEvery, "Pausiere jede "); // ... minutes 
            Translations.Add(ETranslations.BreakComponentDelayPrePause, "Zufällige Pause vor der Pause"); // ... minutes
            Translations.Add(ETranslations.BreakComponentPause, "Pausezeit von"); // ... minutes
            Translations.Add(ETranslations.BreakComponentDelayPostPause, "Zufällige Pause nach der Pause");
                // ... minutes
            Translations.Add(ETranslations.BreakComponentEnableBreaks, "Pausen Aktivieren?");
            Translations.Add(ETranslations.BreakComponentMinutes, "Minuten");
            Translations.Add(ETranslations.BreakComponentOk, "OK");
            Translations.Add(ETranslations.BreakComponentCancel, "Abbrechen");

            // component: IPCheckComponent
            Translations.Add(ETranslations.IPCheckComponentDeleteIP, "Lösche IP");
            Translations.Add(ETranslations.IPCheckComponentAddNewIP, "Neue IP");
            Translations.Add(ETranslations.IPCheckComponentAddRange, "Neue IPs");
            Translations.Add(ETranslations.IPCheckComponentEnableIPChecks, "IP Checks aktivieren?");
            Translations.Add(ETranslations.IPCheckComponentIPToAdd, "IP zum hinzufügen");
            Translations.Add(ETranslations.IPCheckComponentEnterIP,
                "IP zum Hinzufügen eingeben (Im Format: 127.0.0.1).");
            Translations.Add(ETranslations.IPCheckComponentAddingNewIPRange,
                "Füge neue IP-Range hinzu, das letzte Paar der IP-Range wird übersprungen, 192.168.1.1 wird 192.168.1.0-255.");
            Translations.Add(ETranslations.IPCheckComponentIPRangeToAdd, "IP-Range zum Hinzufügen");
            Translations.Add(ETranslations.IPCheckComponentEnterIPRange,
                "Bitte die gewünschte IP-Range zum hinzufügen eingeben (Im Format: 192.168.1.0).");
            Translations.Add(ETranslations.IPCheckComponentOk, "OK");
            Translations.Add(ETranslations.IPCheckComponentCancel, "Abbrechen");

            // component: LaunchDelayComponent
            Translations.Add(ETranslations.LaunchDelayComponentCurrentValue, "Aktueller Wert:");
            Translations.Add(ETranslations.LaunchDelayComponentSeconds, "Sekunden");
            Translations.Add(ETranslations.LaunchDelayComponentSetNew, "Neu");
            Translations.Add(ETranslations.LaunchDelayComponentOk, "OK");
            Translations.Add(ETranslations.LaunchDelayComponentCancel, "Abbrechen");
            Translations.Add(ETranslations.LaunchDelayComponentLaunchDelay, "Startverzögerung");
            Translations.Add(ETranslations.LaunchDelayComponentEntireDesiredDelay,
                "Bitte die gewünschte Verzögerung zwischen den GW2-Starts eingeben (! Minimum: 20, in Sekunden!).");

            // component: RestartDelayComponent
            Translations.Add(ETranslations.RestartDelayComponentCurrentValue, "Aktueller Wert:");
            Translations.Add(ETranslations.RestartDelayComponentSeconds, " Sekunden ");
            Translations.Add(ETranslations.RestartDelayComponentSetNew, " Neu ");
            Translations.Add(ETranslations.RestartDelayComponentOk, "OK");
            Translations.Add(ETranslations.RestartDelayComponentCancel, "Abbrechen");
            Translations.Add(ETranslations.RestartDelayComponentRestartDelay, "Neustartverzögerung");
            Translations.Add(ETranslations.RestartDelayComponentEntireDesiredDelay,
                "Bitte die gewünschte Neustartverzögerung eingeben (Um das maximale Key-Limit zu umgehen) (! in Sekunden!).");

            // component: SchedulerComponent
            Translations.Add(ETranslations.SchedulerComponentStartTime, "Startzeit:");
            Translations.Add(ETranslations.SchedulerComponentStopTime, "Stoppzeit:");
            Translations.Add(ETranslations.SchedulerComponentDays, "Tage (24h Zyklen):");
            Translations.Add(ETranslations.SchedulerComponentTimeInMinutes, "Zeit in Minuten:");
            Translations.Add(ETranslations.SchedulerComponentEnableScheduler, "Zeitplaner aktivieren?");
            Translations.Add(ETranslations.SchedulerComponentOk, "OK");
            Translations.Add(ETranslations.SchedulerComponentCancel, "Abbrechen");
            Translations.Add(ETranslations.SchedulerComponentSaveSettings,
                "Speichere Zeitplan-einstellung für {0} (Minuten: {1}).");
            // class: AccountControl
            Translations.Add(ETranslations.AccountControlStart, "Start");
            Translations.Add(ETranslations.AccountControlStop, "Stopp");
            Translations.Add(ETranslations.AccountControlManage, "Planen");
            Translations.Add(ETranslations.AccountControlSettings, "Einstellungen");
            Translations.Add(ETranslations.AccountControlEnabled, "Aktiviert");
            Translations.Add(ETranslations.AccountControlDisabled, "Deaktiviert");
            Translations.Add(ETranslations.AccountControlLoginName, "Login Name");
            Translations.Add(ETranslations.AccountControlStatus, "Status");

            // GUI: AccountForm
            Translations.Add(ETranslations.AccountFormLoginName, "Login Name");
            Translations.Add(ETranslations.AccountFormPassword, "Passwort");
            Translations.Add(ETranslations.AccountFormNoSound, "Kein Sound?");
            Translations.Add(ETranslations.AccountFormCancel, "Abbrechen");
            Translations.Add(ETranslations.AccountFormDelete, "Löschen");
            Translations.Add(ETranslations.AccountFormOk, "OK");
            Translations.Add(ETranslations.AccountFormAddAccount, "Account hinzufügen");
            Translations.Add(ETranslations.AccountFormEditAccount, "Account bearbeiten");

            // GUI: MainForm
            Translations.Add(ETranslations.MainFormStartAll, "Starte Bots");
            Translations.Add(ETranslations.MainFormStopAll, "Stoppe Bots");
            Translations.Add(ETranslations.MainFormChangeTheme, "Theme Wechseln");
            Translations.Add(ETranslations.MainFormChangeColor, "Farbe Wechseln");
            Translations.Add(ETranslations.MainFormAddAccount, "Account hinzufügen");
            Translations.Add(ETranslations.MainFormOpenSettings, "Öffne Einstellungen");
            Translations.Add(ETranslations.MainFormSetGW2EXEPath, "GW2.EXE Pfad festlegen");
            Translations.Add(ETranslations.MainFormSetPollingDelay, "Abfragehäufigkeit setzen");
            Translations.Add(ETranslations.MainFormSetFrozenTime, "Einfrierzeit setzen");
            Translations.Add(ETranslations.MainFormMinimizeGW2Windows, "Minimiere GW2 Fenster?");
            Translations.Add(ETranslations.MainFormEnabledComponents, "Aktivierte Komponenten");
            Translations.Add(ETranslations.MainFormDisabledComponents, "Deaktivierte Komponenten ");
            Translations.Add(ETranslations.MainFormSetLanguage, "Sprache");
            Translations.Add(ETranslations.MainFormMoveToRight, "Nach rechts verschieben");
            Translations.Add(ETranslations.MainFormMoveToLeft, "Nach links verschieben");
            Translations.Add(ETranslations.MainFormLoad, "Laden");
            Translations.Add(ETranslations.MainFormSave, "Speichern");
            Translations.Add(ETranslations.MainFormAccounts, "Accounts");
            Translations.Add(ETranslations.MainFormSettings, "Einstellungen");
            Translations.Add(ETranslations.MainFormLog, "Log");
            Translations.Add(ETranslations.MainFormFreshConfig,
                " Hallo, da du mit einer frischen Konfiguration beginnen, müssen einige Einstellungen zuerst vorgenommen werden.");
            Translations.Add(ETranslations.MainFormWelcome, "Hallo!");
            Translations.Add(ETranslations.MainFormWhichComponents,
                "Ok, jetzt musst du die Komponenten, welche der Relogger benutzen soll, festlegen. Als Anfänger, einfach alle Komponenten hinzufügen indem du auf „Nach links verschieben“ drückst..");
            Translations.Add(ETranslations.MainFormFirstStep, "Erster Schritt");
            Translations.Add(ETranslations.MainFormPleaseSave,
                "Wenn du fertig bist unbedingt SPEICHERN drücken!");
            Translations.Add(ETranslations.MainFormTip, "Tipp!");
            Translations.Add(ETranslations.MainFormEnabled, "Aktiviert");
            Translations.Add(ETranslations.MainFormDisabled, "Deaktiviert");
            Translations.Add(ETranslations.MainFormLocateGW2Short, "GW2.exe lokalisieren");
            Translations.Add(ETranslations.MainFormLocateGW2Long, "Bitte deine gw2.exe suchen und auswählen.");
            Translations.Add(ETranslations.MainFormPollingDelayShort, "Abfrageverzögerung");
            Translations.Add(ETranslations.MainFormPollingDelayLong,
                "Bitte die gewünschte Abfrageverzögerung festlegen (!Minimum: 3, in Sekunden!).");
            Translations.Add(ETranslations.MainFormFrozenTimeShort, "Einfrierzeit");
            Translations.Add(ETranslations.MainFormFrozenTimeLong,
                "Bitte die gewünschte Zeit angeben, nach der eine GW2 Instanz als eingefroren gelten soll (!Minimum: 60, in Sekunden!).");
            Translations.Add(ETranslations.MainFormLoginName, "Login Name");
            Translations.Add(ETranslations.MainFormStatus, "Status");

            // component: BasicStopComponent
            Translations.Add(ETranslations.BasicStopComponentStop,
                "Stoppe Instanz {0}, sollte nicht laufen (deaktiviert).");
            Translations.Add(ETranslations.BasicStopComponentHalt,
                "Pausiere Start für {0}, sollte nicht laufen (deaktiviert).");

            // component: BreakComponent
            Translations.Add(ETranslations.BreakComponentKill,
                "Stoppe Instanz {0}, sollte laut Pause-einstellungen nicht laufen.");
            Translations.Add(ETranslations.BreakComponentHalt,
                "Pausiere start für {0}, sollte laut Pause-einstellungen nicht starten.");

            // component: IPCheckComponent
            Translations.Add(ETranslations.IPCheckComponentHalt,
                "Pausiere Start für {0}, sollte nicht laufen. Aktuelle IP ist nicht erlaubt.");
            Translations.Add(ETranslations.IPCheckComponentKill,
                "Stoppe Instanz {0}, sollten nicht laufen. AKtuelle IP ist nicht erlaubt.");

            // component: LaunchDelayComponent
            Translations.Add(ETranslations.LaunchDelayComponentHalt,
                "Pausiere Start für {0}. Startverzögerung ist noch nicht abgelaufen.");

            // component: RestartDelayComponent
            Translations.Add(ETranslations.RestartDelayComponentHalt,
                "Pausiere Start für {0}. Neustartverzögerung ist noch nicht abgelaufen.");

            // component: SchedulerComponent
            Translations.Add(ETranslations.SchedulerComponentHalt,
                "Pausiere Start für {0}, sollte laut Zeitplaner nicht laufen.");
            Translations.Add(ETranslations.SchedulerComponentKill,
                "Stoppe Instanz für {0}, sollte laut Zeitplaner nicht laufen.");
        }

        public override string GetLanguageDescription()
        {
            return "Deutsch";
        }

        public override ELanguages GetLanguage()
        {
            return ELanguages.German;
        }
    }
}