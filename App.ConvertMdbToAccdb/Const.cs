using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App.ConvertMdbToAccdb
{
    public static class Const
    {
        public static string DRIVER_NAME = "DAO.DBEngine.120";
        public static string COMPACT_DATABASE = "CompactDatabase";
        public static string DRIVER_PATH_MSI = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase) + "\\accessDB2010x86.msi";
        public static string INIFILE_PATH = Const.removeTexteFile(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase) + "\\cheminSourceMDB.ini");
        public static string LOGFILE_PATH = Const.removeTexteFile(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase) + "\\Logs.txt");
        public static string INIFILE_VAR = "SourcePathDB";
        public static logs mylogs = new logs();

        private static string removeTexteFile(string path)
        {
            if (!string.IsNullOrEmpty(path) && path.Contains("file:\\"))
                path = path.Substring(6, path.Length - 6);
            return path;
        }
    }
}
