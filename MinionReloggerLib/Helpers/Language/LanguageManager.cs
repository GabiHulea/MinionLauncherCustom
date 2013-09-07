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

using System.Collections.Generic;
using MinionReloggerLib.Configuration;
using MinionReloggerLib.Enums;
using MinionReloggerLib.Helpers.Language.Languages;

namespace MinionReloggerLib.Helpers.Language
{
    public class LanguageManager
    {
        private static LanguageManager _instance;

        private readonly Dictionary<ELanguages, Language> _languages;
        private ELanguages _currentLanguage;

        protected LanguageManager()
        {
            _languages = new Dictionary<ELanguages, Language>
            {
                {ELanguages.English, new English()},
                {ELanguages.Chinese, new Chinese()},
                {ELanguages.German, new German()},
                {ELanguages.French, new French()},
                {ELanguages.Turkish, new Turkish()},
            };
            _currentLanguage = ELanguages.Default;
        }

        public static LanguageManager Singleton
        {
            get { return _instance ?? (_instance = new LanguageManager()); }
            set { _instance = value; }
        }

        public Dictionary<ELanguages, Language> GetLanguages()
        {
            return _languages;
        }

        public string GetTranslation(ETranslations key)
        {
            return _languages[_currentLanguage].GetTranslation(key);
        }

        public void SetNewLanguage(ELanguages newLanguage)
        {
            _currentLanguage = newLanguage;
            Config.Singleton.GeneralSettings.SetLanguage(_currentLanguage);
        }

        public ELanguages GetCurrentLanguage()
        {
            return _currentLanguage;
        }
    }
}