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

using System;
using System.Threading;
using MinionReloggerLib.Enums;

namespace MinionReloggerLib.Logging
{
    public abstract class STAHelper
    {
        private readonly ManualResetEvent _complete = new ManualResetEvent(false);
        internal bool DontRetryWorkOnFailed { get; set; }

        internal void Go()
        {
            var thread = new Thread(DoWork)
            {
                IsBackground = true,
            };
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void DoWork()
        {
            try
            {
                _complete.Reset();
                Work();
            }
            catch (Exception ex)
            {
                if (DontRetryWorkOnFailed)
                    throw;
                else
                {
                    try
                    {
                        Thread.Sleep(1000);
                        Work();
                    }
                    catch
                    {
                        Logger.LoggingObject.Log(ELogType.Critical, ex.Message);
                    }
                }
            }
            finally
            {
                _complete.Set();
            }
        }

        protected abstract void Work();
    }
}