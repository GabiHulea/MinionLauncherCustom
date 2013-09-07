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
using System.IO;
using System.Security.Cryptography;
using System.Text;
using MinionReloggerLib.Enums;
using MinionReloggerLib.Helpers.Language;
using MinionReloggerLib.Logging;

namespace MinionReloggerLib.Helpers.Encryption
{
    internal static class DataProtector
    {
        private const string EntropyValue = "ThisStringIsNotSoSecretRight";

        internal static string EncryptData(string stringToEncrypt)
        {
            var encryptedData = new byte[] {};
            try
            {
                encryptedData = ProtectedData.Protect(Encoding.Unicode.GetBytes(stringToEncrypt),
                    Encoding.Unicode.GetBytes(EntropyValue),
                    DataProtectionScope.LocalMachine);
            }
            catch (CryptographicException ex)
            {
                Logger.LoggingObject.Log(ELogType.Critical,
                    LanguageManager.Singleton.GetTranslation(
                        ETranslations.DataProtectorErrorOccured));
                Logger.LoggingObject.Log(ELogType.Critical, ex.Message);
                Logger.LoggingObject.Log(ELogType.Critical,
                    LanguageManager.Singleton.GetTranslation(
                        ETranslations.DataProtectorDeletedSaveFile));
                try
                {
                    File.Delete("Launcher.bin");
                }
                catch (UnauthorizedAccessException ex2)
                {
                    Logger.LoggingObject.Log(ELogType.Critical, ex2.Message);
                }
                catch (IOException ex3)
                {
                    Logger.LoggingObject.Log(ELogType.Critical, ex3.Message);
                }
            }
            return Convert.ToBase64String(encryptedData);
        }

        internal static string DecryptData(string stringToDecrypt)
        {
            var decryptedData = new byte[] {};
            try
            {
                decryptedData = ProtectedData.Unprotect(Convert.FromBase64String(stringToDecrypt),
                    Encoding.Unicode.GetBytes(EntropyValue),
                    DataProtectionScope.LocalMachine);
            }
            catch (CryptographicException ex)
            {
                Logger.LoggingObject.Log(ELogType.Critical,
                    LanguageManager.Singleton.GetTranslation(
                        ETranslations.DataProtectorErrorOccured));
                Logger.LoggingObject.Log(ELogType.Critical, ex.Message);
                Logger.LoggingObject.Log(ELogType.Critical,
                    LanguageManager.Singleton.GetTranslation(
                        ETranslations.DataProtectorDeletedSaveFile));
                try
                {
                    File.Delete("" +
                                "Launcher.bin");
                }
                catch (UnauthorizedAccessException ex2)
                {
                    Logger.LoggingObject.Log(ELogType.Critical, ex2.Message);
                }
                catch (IOException ex3)
                {
                    Logger.LoggingObject.Log(ELogType.Critical, ex3.Message);
                }
            }
            return Encoding.Unicode.GetString(decryptedData);
        }
    }
}