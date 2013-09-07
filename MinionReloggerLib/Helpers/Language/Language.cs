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
using MinionReloggerLib.Enums;

namespace MinionReloggerLib.Helpers.Language
{
    public abstract class Language
    {
        protected Dictionary<ETranslations, string> Translations;

        protected Language()
        {
            Translations = new Dictionary<ETranslations, string>();
        }

        public string GetTranslation(ETranslations key)
        {
            return Translations[key];
        }

        public abstract string GetLanguageDescription();

        public abstract ELanguages GetLanguage();
    }
}