using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ConvertMdbToAccdb
{
    public class logs
    {
        public void addLog(string message)
        {
            string str = DateTime.Now.ToString("dd/MM/yyyy à HH:mm:ss");
            using (StreamWriter streamWriter = new StreamWriter(Const.LOGFILE_PATH, true))
                streamWriter.WriteLine("-> " + message + " : " + str);
        }

        public void createNewFileLogs()
        {
            this.deleteLogFile();
            File.Create(Const.LOGFILE_PATH).Close();
        }

        private void deleteLogFile()
        {
            if (!File.Exists(Const.LOGFILE_PATH))
                return;
            File.Delete(Const.LOGFILE_PATH);
        }
    }
}
