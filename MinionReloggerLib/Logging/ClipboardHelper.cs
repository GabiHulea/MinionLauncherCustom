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

/*****************************************************************************
*                                                                            *
*   Copyright (C) 2009, Paul Alexander                                       *
*   source: http://stackoverflow.com/questions/899350/                       *
 *          how-to-copy-the-contents-of-a-string-to-the-clipboard-in-c       *
*                                                                            *
******************************************************************************/

using System.Windows.Forms;

namespace MinionReloggerLib.Logging
{
    public class ClipboardHelper : STAHelper
    {
        private readonly object _data;
        private readonly string _format;

        internal ClipboardHelper(string format, object data)
        {
            _format = format;
            _data = data;
        }

        protected override void Work()
        {
            var obj = new DataObject(
                _format,
                _data
                );

            Clipboard.SetDataObject(obj, true);
        }
    }
}