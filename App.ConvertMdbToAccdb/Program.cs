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
                if (!databaseEngine.driverInstalled())
                    databaseEngine.setupDriver();

                //Convert database
                new ConvertDatabase().convert(argsSourceDbPath);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + (object)ex);
                Console.Read();
            }
        }

    }
}
