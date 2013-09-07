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
using System.Reflection;
using MinionReloggerLib.Enums;
using MinionReloggerLib.Helpers.Language;
using MinionReloggerLib.Interfaces;
using MinionReloggerLib.Interfaces.Objects;
using MinionReloggerLib.Logging;

namespace MinionReloggerLib.Core
{
    public class ComponentManager
    {
        private static ComponentManager _instance;

        private readonly List<ComponentClass> _components;

        protected ComponentManager()
        {
            _components = new List<ComponentClass>();
        }

        public static ComponentManager Singleton
        {
            get { return _instance ?? (_instance = new ComponentManager()); }
            set { _instance = value; }
        }

        internal List<ComponentClass> GetComponents()
        {
            return _components;
        }

        internal void AddComponent(IRelogComponent componentToAdd)
        {
            _components.Add(new ComponentClass
            {
                Component = componentToAdd,
                IsEnabled = false,
            });
            Logger.LoggingObject.Log(ELogType.Info,
                LanguageManager.Singleton.GetTranslation(
                    ETranslations.ComponentManagerAddedComponent), componentToAdd.GetName());
        }

        internal void AddComponent(IRelogComponent componentToAdd, int index)
        {
            if (index > _components.Count - 1 && index <= _components.Count)
            {
                _components.Insert(index, new ComponentClass
                {
                    Component = componentToAdd,
                    IsEnabled = false,
                });
                Logger.LoggingObject.Log(ELogType.Info,
                    LanguageManager.Singleton.GetTranslation(
                        ETranslations.ComponentManagerAddedComponent), componentToAdd.GetName());
            }
        }

        public void EnableAllComponents()
        {
            foreach (ComponentClass relogComponent in _components)
            {
                relogComponent.IsEnabled = true;
                relogComponent.Component.OnEnable();
                Logger.LoggingObject.Log(ELogType.Info,
                    LanguageManager.Singleton.GetTranslation(
                        ETranslations.ComponentManagerEnableComponent),
                    relogComponent.Component.GetName());
            }
        }

        public void EnableComponent(string componentToEnable)
        {
            ComponentClass first = _components.FirstOrDefault(c => c.Component.GetName() == componentToEnable);
            if (first != null)
            {
                first.IsEnabled = true;
                first.Component.OnEnable();
                Logger.LoggingObject.Log(ELogType.Info,
                    LanguageManager.Singleton.GetTranslation(
                        ETranslations.ComponentManagerEnableComponent), componentToEnable);
            }
        }

        public void DisableComponent(string componentToDisable)
        {
            ComponentClass first = _components.FirstOrDefault(c => c.Component.GetName() == componentToDisable);
            if (first != null)
            {
                first.IsEnabled = false;
                first.Component.OnDisable();
                Logger.LoggingObject.Log(ELogType.Info,
                    LanguageManager.Singleton.GetTranslation(
                        ETranslations.ComponentManagerDisableComponent), componentToDisable);
            }
        }

        public bool HasComponentWithName(string componentToCheck)
        {
            ComponentClass first = _components.FirstOrDefault(c => c.Component.GetName() == componentToCheck);
            return first != null && first.Component != null;
        }

        public bool HasComponentOfType(Type componentToCheck)
        {
            ComponentClass first = _components.FirstOrDefault(c => c.Component.GetType() == componentToCheck);
            return first != null && first.Component != null;
        }

        public void OpenSettingsForm(IRelogComponent componentToCall, Account account = null)
        {
            componentToCall.ShowSettingsForm(account).ShowDialog();
        }

        public void OpenSettingsForm(string nameofComponentToCall, Account account = null)
        {
            ComponentClass first = _components.FirstOrDefault(c => c.Component.GetName() == nameofComponentToCall);
            if (first != null)
            {
                OpenSettingsForm(first.Component, account);
            }
        }

        public List<string> GetComponentNames()
        {
            return _components.Select(componentClass => componentClass.Component.GetName()).ToList();
        }

        public List<string> GetComponentNamesForEnabled()
        {
            return
                _components.Where(component => component.IsEnabled)
                    .Select(componentClass => componentClass.Component.GetName())
                    .ToList();
        }

        public List<string> GetComponentNamesForDisabled()
        {
            return
                _components.Where(component => !component.IsEnabled)
                    .Select(componentClass => componentClass.Component.GetName())
                    .ToList();
        }

        public List<string> GetEnabledGlobalSettingsComponentNames()
        {
            return
                _components.Where(c => c.IsEnabled && c.Component.GetSettingType() == ESettingsType.Global)
                    .Select(componentClass => componentClass.Component.GetName())
                    .ToList();
        }

        public List<string> GetEnabledAccountSettingsComponentNames()
        {
            return
                _components.Where(c => c.IsEnabled && c.Component.GetSettingType() == ESettingsType.AccountSpecific)
                    .Select(componentClass => componentClass.Component.GetName())
                    .ToList();
        }

        public List<string> GetEnabledNoSettingsComponentNames()
        {
            return
                _components.Where(c => c.IsEnabled && c.Component.GetSettingType() == ESettingsType.None)
                    .Select(componentClass => componentClass.Component.GetName())
                    .ToList();
        }

        public List<string> GetDisabledGlobalSettingsComponentNames()
        {
            return
                _components.Where(c => !c.IsEnabled && c.Component.GetSettingType() == ESettingsType.Global)
                    .Select(componentClass => componentClass.Component.GetName())
                    .ToList();
        }

        public List<string> GetDisabledAccountSettingsComponentNames()
        {
            return
                _components.Where(c => !c.IsEnabled && c.Component.GetSettingType() == ESettingsType.AccountSpecific)
                    .Select(componentClass => componentClass.Component.GetName())
                    .ToList();
        }

        public List<string> GetDisabledNoSettingsComponentNames()
        {
            return
                _components.Where(c => !c.IsEnabled && c.Component.GetSettingType() == ESettingsType.None)
                    .Select(componentClass => componentClass.Component.GetName())
                    .ToList();
        }


        public List<string> GetGlobalSettingsComponentNames()
        {
            return
                _components.Where(c => c.Component.GetSettingType() == ESettingsType.Global)
                    .Select(componentClass => componentClass.Component.GetName())
                    .ToList();
        }

        public List<string> GetAccountSettingsComponentNames()
        {
            return
                _components.Where(c => c.Component.GetSettingType() == ESettingsType.AccountSpecific)
                    .Select(componentClass => componentClass.Component.GetName())
                    .ToList();
        }

        public List<string> GetNoSettingsComponentNames()
        {
            return
                _components.Where(c => c.Component.GetSettingType() == ESettingsType.None)
                    .Select(componentClass => componentClass.Component.GetName())
                    .ToList();
        }

        public void LoadComponents()
        {
            foreach (ComponentClass relogComponent in _components)
            {
                relogComponent.Component.OnUnload();
            }

            _components.Clear();

            try
            {
                if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "Components"))
                    return;
                var di = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "Components");
                foreach (FileInfo fi in di.GetFiles())
                {
                    if (fi.Extension.ToLower() == ".dll")
                    {
                        try
                        {
                            Assembly assembly = Assembly.LoadFrom(fi.FullName);
                            if (assembly != null)
                            {
                                String fName = fi.Name.Replace(fi.Extension, String.Empty);
                                ComponentClass toRemove = _components.FirstOrDefault(c => c.Component.GetName() == fName);
                                if (toRemove != null)
                                    _components.Remove(toRemove);
                                foreach (Type t in assembly.GetTypes())
                                {
                                    if (t.GetInterface("IRelogComponent") != null && t.IsClass)
                                    {
                                        object obj = Activator.CreateInstance(t);
                                        var component = (IRelogComponent) obj;
                                        AddComponent(component);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.LoggingObject.Log(ELogType.Error, ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LoggingObject.Log(ELogType.Error, ex.Message);
            }

            foreach (ComponentClass relogComponent in _components)
            {
                relogComponent.Component.OnLoad();
            }
        }
    }
}