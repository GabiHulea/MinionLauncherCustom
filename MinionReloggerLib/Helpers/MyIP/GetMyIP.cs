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
using System.Net;

namespace MinionReloggerLib.Helpers.MyIP
{
    public static class GetMyIP
    {
        public static IPAddress GetMyCurrentIPAddress()
        {
            try
            {
                var req = new HTTPGet();
                req.Request("http://checkip.dyndns.org");
                string[] a = req.ResponseBody.Split(':');
                string a2 = a[1].Substring(1);
                string[] a3 = a2.Split('<');
                string a4 = a3[0];
                return IPAddress.Parse(a4);
            }
            catch
            {
                return new IPAddress(new byte[] {255, 255, 255, 255});
            }
        }

        public static bool IsMyAddress(IPAddress toCheck)
        {
            return toCheck.Equals(GetMyCurrentIPAddress());
        }

        public static bool ListContainsMyIPAddress(List<IPAddress> listOfAddresses)
        {
            IPAddress myAddress = GetMyCurrentIPAddress();
            return listOfAddresses.Any(ip => ip.Equals(myAddress)) ||
                   myAddress.Equals(new IPAddress(new byte[] {255, 255, 255, 255}));
        }
    }
}