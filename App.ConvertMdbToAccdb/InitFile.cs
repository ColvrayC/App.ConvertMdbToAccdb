using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace App.ConvertMdbToAccdb
{
    public class IniFile
    {
        private string EXE = Assembly.GetExecutingAssembly().GetName().Name;
        private string Path;

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        public IniFile(string IniPath = null)
        {
            this.createFile(IniPath);
            this.Path = new FileInfo(IniPath ?? this.EXE + ".ini").FullName.ToString();
        }

        private void createFile(string IniPath)
        {
            if (File.Exists(IniPath))
                return;
            File.Create(IniPath).Close();
        }

        public string Read(string Key, string Section = null)
        {
            StringBuilder RetVal = new StringBuilder((int)byte.MaxValue);
            IniFile.GetPrivateProfileString(Section ?? this.EXE, Key, "", RetVal, (int)byte.MaxValue, this.Path);
            return RetVal.ToString();
        }

        public void Write(string Key, string Value, string Section = null)
        {
            IniFile.WritePrivateProfileString(Section ?? this.EXE, Key, Value, this.Path);
        }

        public void DeleteKey(string Key, string Section = null)
        {
            this.Write(Key, (string)null, Section ?? this.EXE);
        }

        public void DeleteSection(string Section = null)
        {
            this.Write((string)null, (string)null, Section ?? this.EXE);
        }

        public bool KeyExists(string Key, string Section = null)
        {
            return this.Read(Key, Section).Length > 0;
        }

        public bool IsValidPath(string path, bool allowRelativePaths = false)
        {
            bool flag;
            try
            {
                System.IO.Path.GetFullPath(path);
                if (allowRelativePaths)
                    flag = System.IO.Path.IsPathRooted(path);
                else
                    flag = !string.IsNullOrEmpty(System.IO.Path.GetPathRoot(path).Trim('\\', '/'));
            }
            catch (Exception ex)
            {
                flag = false;
            }
            return flag;
        }
    }
}
