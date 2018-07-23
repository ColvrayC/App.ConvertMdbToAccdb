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
            Action action = (Action)(() => Program.convertion());

            if (action.BeginInvoke((AsyncCallback)null, (object)null).AsyncWaitHandle.WaitOne(600000))
                Console.WriteLine("Method successful.");
            else
                Console.WriteLine("Method timed out.");
            Console.Title = "Conversion fichier MDB en ACCDB - DECLIC SAS";
        }

        private static void convertion()
        {
            try
            {
                Const.mylogs.createNewFileLogs();
                Display.Title();
                DatabaseEngine databaseEngine = new DatabaseEngine();
                if (!databaseEngine.driverInstalled())
                    databaseEngine.setupDriver();
                new ConvertDatabase().convert(Program.getPaths());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur : " + (object)ex);
                Console.Read();
            }
            Console.Read();
        }

        private static string getPaths()
        {
            return ConsoleManager.setSourcePath();
        }
    }
}
