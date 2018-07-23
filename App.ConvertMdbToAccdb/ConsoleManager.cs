using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ConvertMdbToAccdb
{
    public static class ConsoleManager
    {
        public static string errorMessage { get; set; }

        public static string message { get; set; }

        public static string setSourcePath()
        {
            string str = ConsoleManager.readPathFile();
            if (string.IsNullOrEmpty(str))
            {
                while (string.IsNullOrEmpty(ConsoleManager.message))
                {
                    ConsoleManager.errorMessage = string.Empty;
                    str = Display.readLine("Chemin du fichier MDB : ");
                    if (ConsoleManager.pathFileExist(str) && ConsoleManager.pathEqualsExtension(str, ".mdb"))
                    {
                        ConsoleManager.WritePathFile(str);
                        ConsoleManager.message = "Le fichier a été correctement identifié.";
                        Display.successMessage(ConsoleManager.message, true);
                    }
                    if (!string.IsNullOrEmpty(ConsoleManager.errorMessage))
                        Display.errorMessage(ConsoleManager.errorMessage, false);
                }
            }
            return str;
        }

        public static string readPathFile()
        {
            string str = string.Empty;
            IniFile iniFile = new IniFile(Const.INIFILE_PATH);
            if (iniFile.KeyExists(Const.INIFILE_VAR, (string)null))
            {
                string path = iniFile.Read(Const.INIFILE_VAR, (string)null);
                if (!string.IsNullOrEmpty(Const.INIFILE_PATH) && iniFile.IsValidPath(path, false) && File.Exists(path))
                    str = path;
                else
                    Display.errorMessage("le chemin indiqué dans le fichier INI n'est pas valide.", false);
            }
            return str;
        }

        public static string WritePathFile(string sourcePath)
        {
            new IniFile(Const.INIFILE_PATH).Write(Const.INIFILE_VAR, sourcePath.Trim(), (string)null);
            return sourcePath;
        }

        private static bool pathFileExist(string pathFile)
        {
            bool flag = false;
            if (File.Exists(pathFile))
                flag = true;
            else
                ConsoleManager.errorMessage = "Le chemin du fichier spécifié n'existe pas.";
            return flag;
        }

        private static bool pathEqualsExtension(string pathFile, string extension)
        {
            bool flag = false;
            if (Path.GetExtension(pathFile) == extension)
                flag = true;
            else
                ConsoleManager.errorMessage = "Le fichier doit être au format " + extension + ".";
            return flag;
        }

        private static bool fileIsBusy(string sourceFilePath)
        {
            return true;
        }
    }
}
