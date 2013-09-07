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

//using System;
//using System.Net;
//using System.Xml;
//using MinionReloggerLib.Helpers.Memory;

//public static class VersionChecker
//{
//    public static void CheckForUpdates()
//    {
//        XmlTextReader reader = null;
//        try
//        {
//            string xmlURL = "http://minionrelogger.azurewebsites.net/version.xml";
//            var hwRequest = (HttpWebRequest) WebRequest.Create(xmlURL);
//            hwRequest.Timeout = 5000;
//            hwRequest.ReadWriteTimeout = 5000;
//            hwRequest.Proxy = null;
//            HttpWebResponse hwResponse = null;
//            try
//            {
//                hwResponse = (HttpWebResponse) hwRequest.GetResponse();
//                reader = new XmlTextReader(hwResponse.GetResponseStream());
//                reader.MoveToContent();

//                string elementName = "";
//                if ((reader.NodeType == XmlNodeType.Element) &&
//                    (reader.Name == "minionlauncher"))
//                {
//                    while (reader.Read())
//                    {
//                        if (reader.NodeType == XmlNodeType.Element)
//                            elementName = reader.Name;
//                        else
//                        {
//                            if ((reader.NodeType == XmlNodeType.Text) &&
//                                (reader.HasValue))
//                            {
//                                switch (elementName)
//                                {
//                                    case "buildnumber":
//                                        uint.TryParse(reader.Value, out Pointers.BuildNumber);
//                                        break;
//                                    case "viewstate":
//                                        uint.TryParse(reader.Value, out Pointers.ViewStatePtr);
//                                        break;
//                                }
//                            }
//                        }
//                    }
//                }
//            }
//            catch (Exception)
//            {
//            }
//            finally
//            {
//                if (reader != null) reader.Close();
//                if (hwResponse != null) hwResponse.Close();
//            }
//        }
//        catch
//        {
//        }
//        finally
//        {
//            if (reader != null) reader.Close();
//        }
//    }
//}

