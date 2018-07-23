using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.ConvertMdbToAccdb
{
    public class DatabaseEngine
    {
        public string path { get; set; }

        public bool driverInstalled()
        {
            return File.Exists(this.getPathProgramFilesx86() + "\\Microsoft Office\\Office14\\STSLIST.DLL");
        }

        public bool setupDriver()
        {
            try
            {
                Process process = Process.Start(Const.DRIVER_PATH_MSI, "/q");
                while (!process.HasExited)
                {
                    Display.infosMessage("Installation du pilote Access Database Engine 2010...", true);
                    Thread.Sleep(250);
                }
            }
            catch (Exception ex)
            {
                Display.errorMessage("L'installation du pilote Access Database Engine 2010 a échoué (" + ex.Message + ")", true);
                return false;
            }
            Display.successMessage("Installation du pilote Access Database Engine 2010 est Terminée", true);
            return true;
        }

        private string getPathProgramFilesx86()
        {
            if (8 == IntPtr.Size || !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432")))
                return Environment.GetEnvironmentVariable("ProgramFiles(x86)");
            return Environment.GetEnvironmentVariable("ProgramFiles");
        }

        private string getMainLetter()
        {
            return Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System));
        }
    }
}

