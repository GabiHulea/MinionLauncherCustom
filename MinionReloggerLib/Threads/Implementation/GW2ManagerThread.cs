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
using System.Threading;
using MinionReloggerLib.Configuration;

namespace MinionReloggerLib.Threads.Implementation
{
    internal class GW2ManagerThread : IRelogThread
    {
        private readonly Thread _gw2ManagerThread;
        private int _delay;
        private bool _isRunning;
        private bool _keepAlive;
        private bool _needDelay;

        public GW2ManagerThread()
        {
            _gw2ManagerThread = new Thread(DoWork)
            {
                IsBackground = true,
            };
            _delay = 0;
            _needDelay = false;
            _isRunning = false;
            _keepAlive = false;
        }

        public Thread GetThread()
        {
            return _gw2ManagerThread;
        }

        public string GetName()
        {
            return "GW2ManagerThread";
        }

        public bool IsRunning()
        {
            return _gw2ManagerThread.IsAlive && _isRunning;
        }

        public void Delay(int delay)
        {
            _delay = delay;
            _needDelay = true;
        }

        public void Stop()
        {
            _isRunning = false;
        }

        public void Start()
        {
            if (!_keepAlive)
            {
                _keepAlive = true;
                _gw2ManagerThread.Start();
            }
            _isRunning = true;
        }

        public void DoWork()
        {
            while (_keepAlive)
            {
                while (_isRunning)
                {
                    try
                    {
                        if (_needDelay)
                        {
                            Thread.Sleep(_delay);
                        }
                    }
                    catch (Exception)
                    {
                    }
                    Thread.Sleep(Config.Singleton.GeneralSettings.PollingDelay*1000);
                }
                Thread.Sleep(10000);
            }
        }
    }
}