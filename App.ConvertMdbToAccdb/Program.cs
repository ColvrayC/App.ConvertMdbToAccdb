using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ConvertMdbToAccdb
{
    class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            Console.Title = "Conversion fichier MDB en ACCDB - DECLIC SAS";
            //Vlide datas  + hemon au lieu de getpath
            var argsSourceDbPath = ConsoleManager.IsValidPath(args);

            if (!string.IsNullOrEmpty(argsSourceDbPath))
                convertion(argsSourceDbPath);
        }
        private static void convertion(string argsSourceDbPath)
        {
            try
            {
                Const.mylogs.createNewFileLogs();
                Display.Title();
                DatabaseEngine databaseEngine = new DatabaseEngine();
                if (databaseEngine.driverInstalledx86())
                    Display.errorMessage("Impossible d'installer le moteur Acess 2010 64 bits car une version 32 bits existe déjà. merci de la désinstaller puis de relancer l'outil.");
                else if (!databaseEngine.driverInstalledx64())
                {
                    databaseEngine.setupDriver();
                    //véfifie que le moteur Access est bien installé
                    if (!databaseEngine.driverInstalledx64())
                        Display.errorMessage("Impossible d'installer le moteur Acess 2010, l'outil doit être démarré au moins une fois en tant qu'administrateur.");
                }


                //Convert database
                new ConvertDatabase().convert(argsSourceDbPath);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + (object)ex);

            }
        }

    }
}
