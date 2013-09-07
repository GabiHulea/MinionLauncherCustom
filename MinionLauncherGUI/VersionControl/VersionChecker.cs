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
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

namespace MinionLauncherGUI.VersionControl
{
    public static class VersionChecker
    {
        public static void CheckForUpdates(Form owner)
        {
            Version newVersion = null;
            string url = "";
            XmlTextReader reader = null;
            try
            {
                string xmlURL = "http://minionrelogger.azurewebsites.net/version.xml";
                var hwRequest = (HttpWebRequest) WebRequest.Create(xmlURL);
                hwRequest.Timeout = 5000;
                hwRequest.ReadWriteTimeout = 5000;
                hwRequest.Proxy = null;
                HttpWebResponse hwResponse = null;
                try
                {
                    hwResponse = (HttpWebResponse) hwRequest.GetResponse();
                    reader = new XmlTextReader(hwResponse.GetResponseStream());
                    reader.MoveToContent();

                    string elementName = "";
                    if ((reader.NodeType == XmlNodeType.Element) &&
                        (reader.Name == "minionlauncher"))
                    {
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element)
                                elementName = reader.Name;
                            else
                            {
                                if ((reader.NodeType == XmlNodeType.Text) &&
                                    (reader.HasValue))
                                {
                                    switch (elementName)
                                    {
                                        case "version":
                                            newVersion = new Version(reader.Value);
                                            break;
                                        case "url":
                                            url = reader.Value;
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                }
                finally
                {
                    if (reader != null) reader.Close();
                    if (hwResponse != null) hwResponse.Close();
                }

                Version curVersion =
                    Assembly.GetExecutingAssembly().GetName().Version;
                if (curVersion.CompareTo(newVersion) < 0)
                {
                    string title = "New version detected.";
                    string question = "Go to the forums to download the new version?";
                    if (DialogResult.Yes ==
                        MessageBox.Show(owner, question, title,
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question))
                    {
                        Process.Start(url);
                    }
                }
            }
            catch
            {
            }
            finally
            {
                if (reader != null) reader.Close();
            }
        }
    }
}