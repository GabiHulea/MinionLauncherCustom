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
*   Copyright (C) 2011, Stefan                                               *
*   source: http://stackoverflow.com/questions/2196097/                      *
 *          elegant-log-window-in-winforms-c-sharp                           *
*                                                                            *
******************************************************************************/

using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MinionReloggerLib.CustomEventArgs;
using MinionReloggerLib.Enums;

namespace MinionReloggerLib.Logging
{
    public static class Logger
    {
        public static ListBoxLog LoggingObject;

        public static void Initialize(ListBox listBox)
        {
            LoggingObject = new ListBoxLog(listBox);
        }

        public sealed class ListBoxLog : IDisposable
        {
            private const string DefaultMessageFormat = "{0} [{5}] ==> {8}";
            private const int DefaultMaxLinesInListbox = 2000;

            private readonly int _maxEntriesInListBox;
            private readonly string _messageFormat;
            private bool _canAdd = true;
            private bool _disposed;
            private ListBox _listBox;
            private bool _paused;

            public ListBoxLog(ListBox listBox)
                : this(listBox, DefaultMessageFormat, DefaultMaxLinesInListbox)
            {
            }

            public ListBoxLog(ListBox listBox, string messageFormat)
                : this(listBox, messageFormat, DefaultMaxLinesInListbox)
            {
            }

            public ListBoxLog(ListBox listBox, string messageFormat, int maxLinesInListbox)
            {
                _disposed = false;

                _listBox = listBox;
                _messageFormat = messageFormat;
                _maxEntriesInListBox = maxLinesInListbox;

                _paused = false;

                _listBox.SelectionMode = SelectionMode.MultiExtended;

                _listBox.HandleCreated += OnHandleCreated;
                _listBox.HandleDestroyed += OnHandleDestroyed;
                _listBox.DrawItem += DrawItemHandler;
                _listBox.KeyDown += KeyDownHandler;

                var menuItems = new[] {new MenuItem("Copy", CopyMenuOnClickHandler)};
                _listBox.ContextMenu = new ContextMenu(menuItems);
                _listBox.ContextMenu.Popup += CopyMenuPopupHandler;

                _listBox.DrawMode = DrawMode.OwnerDrawFixed;
            }

            public bool Paused
            {
                get { return _paused; }
                set { _paused = value; }
            }

            public void Dispose()
            {
                if (!_disposed)
                {
                    Dispose(true);
                    GC.SuppressFinalize(this);
                    _disposed = true;
                }
            }

            private void OnHandleCreated(object sender, EventArgs e)
            {
                _canAdd = true;
            }

            private void OnHandleDestroyed(object sender, EventArgs e)
            {
                _canAdd = false;
            }

            private void DrawItemHandler(object sender, DrawItemEventArgs e)
            {
                if (e.Index >= 0)
                {
                    e.DrawBackground();
                    e.DrawFocusRectangle();

                    LogEventArgs logEvent = ((ListBox) sender).Items[e.Index] as LogEventArgs ??
                                            new LogEventArgs(ELogType.Critical,
                                                ((ListBox) sender).Items[e.Index].ToString());

                    Color color;
                    switch (logEvent.Type)
                    {
                        case ELogType.Critical:
                            color = Color.White;
                            break;
                        case ELogType.Error:
                            color = Color.Red;
                            break;
                        case ELogType.Warning:
                            color = Color.Goldenrod;
                            break;
                        case ELogType.Info:
                            color = Color.Green;
                            break;
                        case ELogType.Verbose:
                            color = Color.Blue;
                            break;
                        default:
                            color = Color.Black;
                            break;
                    }

                    if (logEvent.Type == ELogType.Critical)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(Color.Red), e.Bounds);
                    }
                    e.Graphics.DrawString(FormatALogEventMessage(logEvent, _messageFormat),
                        new Font("Lucida Console", 8, FontStyle.Regular), new SolidBrush(color),
                        e.Bounds);
                }
            }

            private void KeyDownHandler(object sender, KeyEventArgs e)
            {
                if ((e.Modifiers == Keys.Control) && (e.KeyCode == Keys.C))
                {
                    CopyToClipboard();
                }
            }

            private void CopyMenuOnClickHandler(object sender, EventArgs e)
            {
                CopyToClipboard();
            }

            private void CopyMenuPopupHandler(object sender, EventArgs e)
            {
                var menu = sender as ContextMenu;
                if (menu != null)
                {
                    menu.MenuItems[0].Enabled = (_listBox.SelectedItems.Count > 0);
                }
            }

            private void WriteEvent(LogEventArgs logEvent)
            {
                if ((logEvent != null) && (_canAdd))
                {
                    _listBox.BeginInvoke(new AddALogEntryDelegate(AddALogEntry), logEvent);
                }
            }

            private void AddALogEntry(object item)
            {
                _listBox.Items.Add(item);

                if (_listBox.Items.Count > _maxEntriesInListBox)
                {
                    _listBox.Items.RemoveAt(0);
                }

                if (!_paused) _listBox.TopIndex = _listBox.Items.Count - 1;
            }

            private string LogTypeName(ELogType type)
            {
                switch (type)
                {
                    case ELogType.Critical:
                        return "Critical";
                    case ELogType.Error:
                        return "Error";
                    case ELogType.Warning:
                        return "Warning";
                    case ELogType.Info:
                        return "Info";
                    case ELogType.Verbose:
                        return "Verbose";
                    case ELogType.Debug:
                        return "Debug";
                    default:
                        return string.Format("<value={0}>", (int) type);
                }
            }

            private string FormatALogEventMessage(LogEventArgs logEvent, string messageFormat)
            {
                string message = logEvent.Message ?? "<NULL>";
                return string.Format(messageFormat,
                    logEvent.EventTime.ToString("HH:mm:ss"),
                    logEvent.EventTime.ToString("HH:mm:ss"),
                    logEvent.EventTime.ToString("HH:mm:ss"),
                    logEvent.EventTime.ToString("HH:mm:ss"),
                    logEvent.EventTime.ToString("HH:mm:ss"),
                    LogTypeName(logEvent.Type)[0],
                    LogTypeName(logEvent.Type),
                    (int) logEvent.Type,
                    message);
            }

            private void CopyToClipboard()
            {
                if (_listBox.SelectedItems.Count > 0)
                {
                    var selectedItemsAsRTFText = new StringBuilder();
                    foreach (LogEventArgs logEvent in _listBox.SelectedItems)
                    {
                        selectedItemsAsRTFText.Append(FormatALogEventMessage(logEvent, _messageFormat));
                    }
                    var worker = new ClipboardHelper(DataFormats.Text, selectedItemsAsRTFText.ToString());
                    worker.Go();
                }
            }

            public void Log(string message)
            {
                Log(ELogType.Debug, message);
            }

            public void Log(string format, params object[] args)
            {
                Log(ELogType.Debug, (format == null) ? null : string.Format(format, args));
            }

            public void Log(ELogType type, string format, params object[] args)
            {
                Log(type, (format == null) ? null : string.Format(format, args));
            }

            public void Log(ELogType type, string message)
            {
                WriteEvent(new LogEventArgs(type, message));
            }

            ~ListBoxLog()
            {
                if (!_disposed)
                {
                    Dispose(false);
                    _disposed = true;
                }
            }

            private void Dispose(bool disposing)
            {
                if (_listBox != null)
                {
                    _canAdd = false;

                    _listBox.HandleCreated -= OnHandleCreated;
                    _listBox.HandleCreated -= OnHandleDestroyed;
                    _listBox.DrawItem -= DrawItemHandler;
                    _listBox.KeyDown -= KeyDownHandler;

                    _listBox.ContextMenu.MenuItems.Clear();
                    _listBox.ContextMenu.Popup -= CopyMenuPopupHandler;
                    _listBox.ContextMenu = null;

                    _listBox.Items.Clear();
                    _listBox.DrawMode = DrawMode.Normal;
                    _listBox = null;
                }
            }

            private delegate void AddALogEntryDelegate(object item);
        }
    }
}