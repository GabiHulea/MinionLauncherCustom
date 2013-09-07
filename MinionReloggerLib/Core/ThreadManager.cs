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
using System.Linq;
using MinionReloggerLib.Threads;
using MinionReloggerLib.Threads.Implementation;

namespace MinionReloggerLib.Core
{
    public class ThreadManager
    {
        private static ThreadManager _instance;

        private readonly List<IRelogThread> _threads;

        protected ThreadManager()
        {
            // _threads = new List<IRelogThread> {new GW2ManagerThread(), new InstanceThread()};
            _threads = new List<IRelogThread> {new InstanceThread()};
        }

        public static ThreadManager Singleton
        {
            get { return _instance ?? (_instance = new ThreadManager()); }
            set { _instance = value; }
        }

        public void Initialize()
        {
            foreach (IRelogThread thread in _threads)
            {
                EnableThread(thread.GetName());
            }
        }

        internal List<IRelogThread> GetThreads()
        {
            return _threads;
        }

        internal void AddThread(IRelogThread threadToAdd)
        {
            _threads.Add(threadToAdd);
        }

        public void EnableThread(string threadToEnable)
        {
            IRelogThread first = _threads.FirstOrDefault(t => t.GetName() == threadToEnable);
            if (first != null)
            {
                first.Start();
            }
        }

        public void DisableThread(string threadToDisable)
        {
            IRelogThread first = _threads.FirstOrDefault(t => t.GetName() == threadToDisable);
            if (first != null)
            {
                first.Stop();
            }
        }

        public void DelayThread(string threadToDelay, int delay)
        {
            IRelogThread first = _threads.FirstOrDefault(t => t.GetName() == threadToDelay);
            if (first != null)
            {
                first.Delay(delay);
            }
        }

        public bool ThreadIsRunning(string threadToCheck)
        {
            IRelogThread first = _threads.FirstOrDefault(t => t.GetName() == threadToCheck);
            if (first != null)
            {
                return first.IsRunning();
            }
            return false;
        }
    }
}