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


        internal static string IsValidPath(string[] args)
        {

            var argsSourceDbPath = string.Empty;
            //SI le chemin n'es pas passé en arguments, on génère une rreur dans le log.
            if (args == null || args.Length == 0)
            {
                Display.errorMessage("L'outil de conversion ne contient pas d'arguments.");
            }
            else
            {
                var argument = args[0];
                if (!string.IsNullOrEmpty(argument) &&
                    pathFileExist(argument) &&
                    pathEqualsExtension(argument, ".mdb"))
                {
                    argsSourceDbPath = argument;
                    Display.successMessage(message, true);
                }
                else
                    Display.errorMessage(errorMessage);
            }

            return argsSourceDbPath;
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
            var fileExtension = Path.GetExtension(pathFile).ToLower();
            if (fileExtension == extension.ToLower())
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
