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
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace MinionLauncherGUI
{
    internal static class Program
    {
        private class MyApplicationContext : ApplicationContext
        {
            private readonly MainForm _mainForm;
            private int _formCount;

            private MyApplicationContext()
            {
                _formCount = 0;

                _mainForm = new MainForm();
                _mainForm.Closed += OnFormClosed;
                _formCount++;

                _mainForm.Show();
            }

            private void OnFormClosed(object sender, EventArgs e)
            {
                _formCount--;
                if (_formCount == 0)
                {
                    ExitThread();
                }
            }

            /// <summary>
            ///     The main entry point for the application.
            /// </summary>
            [STAThread]
            private static void Main(string[] args)
            {
                Version LocalVersion, RemoteVersion;
                string remoteUri = "http://patcher.gw2.mmominion.com/Updater/";
                string fileName = "Updater.exe";
                try
                {
                    AppDomain.CurrentDomain.AssemblyResolve += CurrentDomainAssemblyResolve;
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    if (args.Length > 0)
                    {
                        var context = new MyApplicationContext();
                        Application.Run(context);
                    }
                    else
                    {
                        var myWebClient = new WebClient();
                        myWebClient.Proxy = null;
                        myWebClient.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
                        if (File.Exists(fileName))
                        {
                            FileVersionInfo fv;
                            fv = FileVersionInfo.GetVersionInfo(fileName);
                            LocalVersion = new Version(fv.FileVersion.Replace(',', '.'));
                            string updaterVersion = myWebClient.DownloadString(remoteUri + "UpdaterVer.txt");
                            RemoteVersion = new Version(updaterVersion);
                            if (LocalVersion < RemoteVersion)
                            {
                                File.SetAttributes(fileName, FileAttributes.Normal);
                                File.Delete(fileName);
                                myWebClient.DownloadFile(remoteUri + fileName, fileName);
                            }
                        }
                        else
                        {
                            //we dont have the damn file anyway so get it!
                            myWebClient.DownloadFile(remoteUri + fileName, fileName);
                        }
                        Thread.Sleep(1000);
                        //now run the damn file to update the noobs
                        Process currentproc = Process.GetCurrentProcess();
                        var startInfo = new ProcessStartInfo();

                        startInfo.FileName = fileName;
                        startInfo.Arguments = currentproc.Id.ToString();
                        Process startedProc = Process.Start(startInfo);
                        startedProc.WaitForExit();
                        Thread.Sleep(1000);
                        var context = new MyApplicationContext();
                        Application.Run(context);
                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }

            private static Assembly CurrentDomainAssemblyResolve(object sender, ResolveEventArgs args)
            {
                try
                {
                    string RMSAssemblyFolder = AppDomain.CurrentDomain.BaseDirectory + "\\MinionFiles\\";

                    Assembly MyAssembly = null;
                    string strTempAssmbPath = string.Empty;

                    Assembly objExecutingAssemblies = Assembly.GetExecutingAssembly();
                    AssemblyName[] arrReferencedAssmbNames = objExecutingAssemblies.GetReferencedAssemblies();

                    AssemblyName myAssemblyName = Array.Find(arrReferencedAssmbNames, a => a.Name == args.Name);

                    if (myAssemblyName != null)
                    {
                        MyAssembly = Assembly.LoadFrom(myAssemblyName.CodeBase);
                    }
                    else
                    {
                        strTempAssmbPath = Path.Combine(RMSAssemblyFolder,
                            args.Name.Substring(0, args.Name.IndexOf(",")) + ".dll");

                        if (!string.IsNullOrEmpty(strTempAssmbPath))
                        {
                            if (File.Exists(strTempAssmbPath))
                            {
                                MyAssembly = Assembly.LoadFrom(strTempAssmbPath);
                            }
                        }
                    }
                    return MyAssembly;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }
}