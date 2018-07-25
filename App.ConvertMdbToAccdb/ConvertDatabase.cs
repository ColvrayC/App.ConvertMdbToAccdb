using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.ConvertMdbToAccdb
{
    public class ConvertDatabase
    {
        public bool convert(string SourceDb)
        {
            bool flag = false;
            string path = this.getdestFile(SourceDb);
            try
            {
                if (File.Exists(path))
                    File.Delete(path);
                object[] args = new object[2]
                {
                  (object) SourceDb,
                  (object) path
                };
                Display.infosMessage("Conversion de la base de données en cours...", true);
                object instance = Activator.CreateInstance(Type.GetTypeFromProgID(Const.DRIVER_NAME));
                instance.GetType().InvokeMember(Const.COMPACT_DATABASE, BindingFlags.InvokeMethod, (Binder)null, instance, args);
                Marshal.ReleaseComObject(instance);
                Display.successMessage("La base a été correctement convertie ! ", true);
                Display.foreground(ConsoleColor.White);
                Console.WriteLine("BASE SOURCE : " + Environment.NewLine);
                Console.WriteLine(SourceDb ?? "");
                Display.newLines(1);
                Console.WriteLine("BASE CONVERTIE : " + Environment.NewLine);
                Console.WriteLine(path ?? "");
                Thread.Sleep(5000);
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                Display.errorMessage("Une erreur s'est produite lors de la conversion : " + ex.Message, true);
            }
            return flag;
        }

        private string getdestFile(string sourceDb)
        {
            return Path.ChangeExtension(sourceDb, "accdb");
        }
    }
}
