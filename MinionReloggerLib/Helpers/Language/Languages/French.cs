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
    public class French : Language
    {
        public French()
        {
            // class: BreakObject
            Translations.Add(ETranslations.BreakObjectExpired, "Pause a expiré pour {0},  début d'un nouveau cycle!");
            Translations.Add(ETranslations.BreakObjectNew, "Nouveau Démarrage : {0}, Nouvelle Fin Pause: {1}.");

            // class ComponentManager
            Translations.Add(ETranslations.ComponentManagerAddedComponent,
                "Un élément avec le nom {0} a été ajouté à la liste.");
            Translations.Add(ETranslations.ComponentManagerDisableComponent,
                "Un élément avec le nom {0} a été désactivé.");
            Translations.Add(ETranslations.ComponentManagerEnableComponent,
                "Un élément avec le nom {0} a été activé.");

            // class: Config
            Translations.Add(ETranslations.ConfigNewAccount, "Un nouvel objet d'Account été ajouté.");
            Translations.Add(ETranslations.ConfigErrorDuringEncryption,
                "Une erreur s'est produite lors de l'encryption de données.!");
            Translations.Add(ETranslations.ConfigOldSaveFileDeleted,
                " Anciens fichiers de sauvegarde ont été supprimés, ça devait être une vielle version ou corrompu!");
            Translations.Add(ETranslations.ConfigCouldntFindValidSaveFile,
                " N'a pas pu trouver une sauvegarde valide. Veuillez en créer unen nouvelle.");
            Translations.Add(ETranslations.ConfigDumpIntegers,
                "Delai d'interrogation: {0}, Delai de démarrage: {1}, Delai de redémarrage: {2}, Temps figé: {3}.");

            // class: DataProtector
            Translations.Add(ETranslations.DataProtectorErrorOccured,
                "Une erreur s'est produite lors de l'encryption de données.!");

            Translations.Add(ETranslations.DataProtectorDeletedSaveFile,
                "Anciens fichiers de sauvegarde ont été supprimés, ça devait être une vielle version ou corrompu!");


            // class: General Settings
            Translations.Add(ETranslations.GeneralSettingsGW2PathChanged,
                "Le dossier cible de GW2 a été changé pour: [{0}].");
            Translations.Add(ETranslations.GeneralSettingsPollingDelayChanged,
                "Delai d'interrogation a été changé à: [{0}].");
            Translations.Add(ETranslations.GeneralSettingsFrozenTimeChanged,
                "Temps figé a été changé à: [{0}].");
            Translations.Add(ETranslations.GeneralSettingsLaunchDelayChanged,
                "Delai de démarrage a été changé à: [{0}].");
            Translations.Add(ETranslations.GeneralSettingsRestartDelayChanged,
                "Delai de redémarrage a été changé pour: [{0}].");
            Translations.Add(ETranslations.GeneralSettingsColorChanged, "Changé pour la couleur: {0}.");
            Translations.Add(ETranslations.GeneralSettingsThemeChanged, "Changé pour le thème: {0}.");
            Translations.Add(ETranslations.GeneralSettingsMinimizeWindowsChanged,
                "Réduction de la fenêtre à été changé pour: {0}.");
            Translations.Add(ETranslations.GeneralSettingsCheckForIPChanged,
                "Verification de l'IP . A été changé à: {0}.");
            Translations.Add(ETranslations.GeneralSettingsAddedIP,
                "L'adresse IP {0} a été ajoutée à  la liste des adresses autorisées.");
            Translations.Add(ETranslations.GeneralSettingsDeletedIP,
                "L'adresse IP {0} a été retirée de la liste des adresses autorisées.");

            // class: GW2ManagerThread
            Translations.Add(ETranslations.GW2ManagerThreadStoppedResponding,
                "Une instance de GW2 roulant {0}, a cessée de fonctionner. Nous gardons un d'oeil dessus.");
            Translations.Add(ETranslations.GW2ManagerThreadStartedRespondingAgain,
                "L'instance de GW2 roulant{0}, a recommencée à répondre.");

            // class: InputBox
            Translations.Add(ETranslations.InputBoxOk, "OK");
            Translations.Add(ETranslations.InputBoxCancel, "Annuler");

            // class: KillWorker
            Translations.Add(ETranslations.KillWorkerStoppingProcess, "Arrêt du processus avec le PID {0}.");

            // class: StartWorker
            Translations.Add(ETranslations.StartWorkerLaunchingInstance, " Démarrage de l'instance pour {0} avec {1}.");
            Translations.Add(ETranslations.StartWorkerScanningForExisting, "Analyse des instances de GW2 existance.");
            Translations.Add(ETranslations.StartWorkerFoundWantedProcess,
                "Trouvé le processus voulu pour {0}, pas besoin de démarrer.");
            Translations.Add(ETranslations.StartWorkerAttachingTo, "Liaison au {0} avec {1}.");

            // class: ViewStateObject
            Translations.Add(ETranslations.ViewStateObjectClientStuckSomewhere,
                "L'instance GW2, roulant {0}, n'a pas été sur le jeu pour {1} secondes, planification d'un redémarrage.");

            // class: WatchObject
            Translations.Add(ETranslations.WatchObjectNotRespondingFor,
                "L'instance GW2,roulant {0}, n'a pas répondu depuis 90 secondes, planification d'un redémarrage.");

            // component: BreakComponent
            Translations.Add(ETranslations.BreakComponentPauseEvery, "Pause chaque"); // ... minutes
            Translations.Add(ETranslations.BreakComponentDelayPrePause, "Delai aléatoire de pré-pause de");
                // ... minutes
            Translations.Add(ETranslations.BreakComponentPause, "Durée de la pause de"); // ... minutes
            Translations.Add(ETranslations.BreakComponentDelayPostPause, "Delai aléatoire d'après pause de");
                // ... minutes
            Translations.Add(ETranslations.BreakComponentEnableBreaks, "Activation des pauses?");
            Translations.Add(ETranslations.BreakComponentMinutes, "minutes");
            Translations.Add(ETranslations.BreakComponentOk, "OK");
            Translations.Add(ETranslations.BreakComponentCancel, "Annuler");

            // component: IPCheckComponent
            Translations.Add(ETranslations.IPCheckComponentDeleteIP, "Supprimer IP");
            Translations.Add(ETranslations.IPCheckComponentAddNewIP, "Ajouter nouvelle IP");
            Translations.Add(ETranslations.IPCheckComponentAddRange, "Ajouter plage(ip)");
            Translations.Add(ETranslations.IPCheckComponentEnableIPChecks, "Activer vérification d'IP?");
            Translations.Add(ETranslations.IPCheckComponentIPToAdd, "IP à Ajouter");
            Translations.Add(ETranslations.IPCheckComponentEnterIP,
                "Veuillez entrer l'adresse IP désiré sous le format: (127.0.0.1).");
            Translations.Add(ETranslations.IPCheckComponentAddingNewIPRange,
                "Ajout de la nouvelle plage IP, la dernière paire de chiffres sera sautée, 192.168.1.1 devient 192.168.1.0-255. Par contre, entrez une adresse IP valide!");
            Translations.Add(ETranslations.IPCheckComponentIPRangeToAdd, "Plage IP À Ajouté:");
            Translations.Add(ETranslations.IPCheckComponentEnterIPRange,
                "Veuillez entrer la plage IP désirée à ajouter (sous le format : 192.168.1.0).");
            Translations.Add(ETranslations.IPCheckComponentOk, "OK");
            Translations.Add(ETranslations.IPCheckComponentCancel, "Annuler");

            // component: LaunchDelayComponent
            Translations.Add(ETranslations.LaunchDelayComponentCurrentValue, "Valeur actuelle:");
            Translations.Add(ETranslations.LaunchDelayComponentSeconds, "secondes");
            Translations.Add(ETranslations.LaunchDelayComponentSetNew, "Configuration Nouveau");
            Translations.Add(ETranslations.LaunchDelayComponentOk, "OK");
            Translations.Add(ETranslations.LaunchDelayComponentCancel, "Annuler");
            Translations.Add(ETranslations.LaunchDelayComponentLaunchDelay, "Delai Démarrage");
            Translations.Add(ETranslations.LaunchDelayComponentEntireDesiredDelay,
                "Veullez entrer le delai désiré entre chaque démarrage de GW2(!minimum: 20, en secondes!).");

            // component: RestartDelayComponent
            Translations.Add(ETranslations.RestartDelayComponentCurrentValue, "Valeur courante:");
            Translations.Add(ETranslations.RestartDelayComponentSeconds, "secondes");
            Translations.Add(ETranslations.RestartDelayComponentSetNew, "Configuration Nouveau");
            Translations.Add(ETranslations.RestartDelayComponentOk, "OK");
            Translations.Add(ETranslations.RestartDelayComponentCancel, "Annuler");
            Translations.Add(ETranslations.RestartDelayComponentRestartDelay, "Delai Redémarrage");
            Translations.Add(ETranslations.RestartDelayComponentEntireDesiredDelay,
                "Veuillez entrer le delai de redémarrage désiré (pour empêcher la limite de clé maximale) (!en secondes!).");

            // component: SchedulerComponent
            Translations.Add(ETranslations.SchedulerComponentStartTime, "Heure démarrage:");
            Translations.Add(ETranslations.SchedulerComponentStopTime, "Heure arrêt:");
            Translations.Add(ETranslations.SchedulerComponentDays, "Jour (cycle de 24h):");
            Translations.Add(ETranslations.SchedulerComponentTimeInMinutes, "Temps en minutes:");
            Translations.Add(ETranslations.SchedulerComponentEnableScheduler, "Activer le planificateur?");
            Translations.Add(ETranslations.SchedulerComponentOk, "OK");
            Translations.Add(ETranslations.SchedulerComponentCancel, "Annuler");
            Translations.Add(ETranslations.SchedulerComponentSaveSettings,
                "Sauvegarde de configuration du planificateur pour{0} (minutes: {1}).");
            // class: AccountControl
            Translations.Add(ETranslations.AccountControlStart, "Démarrer");
            Translations.Add(ETranslations.AccountControlStop, "Arrêter");
            Translations.Add(ETranslations.AccountControlManage, "Gestion");
            Translations.Add(ETranslations.AccountControlSettings, "Configuration");
            Translations.Add(ETranslations.AccountControlEnabled, "Activer");
            Translations.Add(ETranslations.AccountControlDisabled, "Désactiver");
            Translations.Add(ETranslations.AccountControlLoginName, "Nom De Login");
            Translations.Add(ETranslations.AccountControlStatus, "Statut");

            // GUI: AccountForm
            Translations.Add(ETranslations.AccountFormLoginName, "Nom Login");
            Translations.Add(ETranslations.AccountFormPassword, "Mot De Passe");
            Translations.Add(ETranslations.AccountFormNoSound, "Désactiver Son?");
            Translations.Add(ETranslations.AccountFormCancel, "Annuler");
            Translations.Add(ETranslations.AccountFormDelete, "Supprimer");
            Translations.Add(ETranslations.AccountFormOk, "OK");
            Translations.Add(ETranslations.AccountFormAddAccount, "Ajouter Compte");
            Translations.Add(ETranslations.AccountFormEditAccount, "Modifier Compte");

            // GUI: MainForm
            Translations.Add(ETranslations.MainFormStartAll, "Démarrer Tout");
            Translations.Add(ETranslations.MainFormStopAll, "Arrêter Tout");
            Translations.Add(ETranslations.MainFormChangeTheme, "Changer Thème");
            Translations.Add(ETranslations.MainFormChangeColor, "Changer Couleur");
            Translations.Add(ETranslations.MainFormAddAccount, "Ajouter Compte");
            Translations.Add(ETranslations.MainFormOpenSettings, "Ouvrir configuration");
            Translations.Add(ETranslations.MainFormSetGW2EXEPath, "Détermimer endroit du GW2 EXE ");
            Translations.Add(ETranslations.MainFormSetPollingDelay, "Déterminer delai d'intervalle ");
            Translations.Add(ETranslations.MainFormSetFrozenTime, "Déterminer Temps Figé");
            Translations.Add(ETranslations.MainFormMinimizeGW2Windows, "Réduire  fenêtre GW2?");
            Translations.Add(ETranslations.MainFormEnabledComponents, "Activer les modules?");
            Translations.Add(ETranslations.MainFormDisabledComponents, "Désactiver les modules?");
            Translations.Add(ETranslations.MainFormSetLanguage, "Choisir Langue");
            Translations.Add(ETranslations.MainFormMoveToRight, "Bouger À Gauche");
            Translations.Add(ETranslations.MainFormMoveToLeft, "Bouger À Droit");
            Translations.Add(ETranslations.MainFormLoad, "Charger");
            Translations.Add(ETranslations.MainFormSave, "Sauvegarder");
            Translations.Add(ETranslations.MainFormAccounts, "Comptes");
            Translations.Add(ETranslations.MainFormSettings, "Configurations");
            Translations.Add(ETranslations.MainFormLog, "Log");
            Translations.Add(ETranslations.MainFormFreshConfig,
                "Bonjour, puisque vous démarrez avec une nouvelle configuration, vous devrez suivre les prochaines étapes.");
            Translations.Add(ETranslations.MainFormWelcome, "Bienvenu");
            Translations.Add(ETranslations.MainFormWhichComponents,
                "Ok, vous devez maintenant configurer quels modules utiliser avec le relogger. Si vous êtes un débutant, je vous recommande de les activer tous. Vous pouvez le faire en cliquant sur le bouton \"Bouger À Gauche\".");
            Translations.Add(ETranslations.MainFormFirstStep, "Première Étape");
            Translations.Add(ETranslations.MainFormPleaseSave,
                "Après avoir terminé, n'oublier surtout pas d'appuyer sur Sauvegarder ou vous devrez refaire les étapes prédédentes.");
            Translations.Add(ETranslations.MainFormTip, "Conseil!");
            Translations.Add(ETranslations.MainFormEnabled, "Activé");
            Translations.Add(ETranslations.MainFormDisabled, "Désactivé");
            Translations.Add(ETranslations.MainFormLocateGW2Short, "Trouver l'exécutable de GW2");
            Translations.Add(ETranslations.MainFormLocateGW2Long, "Veuillez cibler l'exécutable de votre GW2.");
            Translations.Add(ETranslations.MainFormPollingDelayShort, "Delai d'Intervalle");
            Translations.Add(ETranslations.MainFormPollingDelayLong,
                "Veuillez entrer le délai d'intervalle désiré(!minimum: 3, en secondse!).");
            Translations.Add(ETranslations.MainFormFrozenTimeShort, "Temps Figé");
            Translations.Add(ETranslations.MainFormFrozenTimeLong,
                "Veuillez entrer le temps désiré pour lequel votre instance GW2 sera considéré figé/bloqué (!minimum: 60, en secondes!).");
            Translations.Add(ETranslations.MainFormLoginName, "Nom Login");
            Translations.Add(ETranslations.MainFormStatus, "Statut");

            // component: BasicStopComponent
            Translations.Add(ETranslations.BasicStopComponentStop,
                "Arrêt de l'instance pour {0}, ne devrait pas être en exécution(désactivé).");
            Translations.Add(ETranslations.BasicStopComponentHalt,
                "Arrêt du départ pour {0}, ne devrait plus être en exécution(désactivé).");

            // component: BreakComponent
            Translations.Add(ETranslations.BreakComponentKill,
                "Retardement du démarrage  {0}, ne devrait plus être en exécution du à une configuration de pause.");
            Translations.Add(ETranslations.BreakComponentHalt,
                "Retardement du démarrage pour {0}, ne devrait plus être en exécution du à une configuration de pause.");

            // component: IPCheckComponent
            Translations.Add(ETranslations.IPCheckComponentHalt,
                "Retardement du démarrage pour {0}, ne devrait plus être en exécution. L'IP courante n'a pas été permise.");
            Translations.Add(ETranslations.IPCheckComponentKill,
                "Arrêt de l'instance pour{0}, ne devrait plus être en exécution. L'ip courrante n'a pas été permise.");

            // component: LaunchDelayComponent
            Translations.Add(ETranslations.LaunchDelayComponentHalt,
                "Retardement du démarrage pour {0}, ne devrait plus être en exécution. Le delai de lancement n'est pas encore expiré.");

            // component: RestartDelayComponent
            Translations.Add(ETranslations.RestartDelayComponentHalt,
                "Retadement du démarrage pour {0}, ne devrait plus être en exécution. Le délai de redémarrage n'est pas encore expiré.");

            // component: SchedulerComponent
            Translations.Add(ETranslations.SchedulerComponentHalt,
                "Retardement du démarrage pour {0}, ne devrait plus être en exécution en raison de la configuration du planificateur.");
            Translations.Add(ETranslations.SchedulerComponentKill,
                "Arrêt de l'instance pour {0}, ne devrait plus être en exécution en raison de la configuration du planificateur.");
        }

        public override string GetLanguageDescription()
        {
            return "Français";
        }

        public override ELanguages GetLanguage()
        {
            return ELanguages.French;
        }
    }
}