using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ConvertMdbToAccdb
{
    public static class Display
    {
        public static void infosMessage(string message, bool clear = false)
        {
            if (clear)
                Display.Clear();
            Display.foreground(ConsoleColor.White);
            Console.WriteLine(message);
            Display.newLines(2);
        }

        public static void successMessage(string message, bool clear = false)
        {
            Const.mylogs.addLog(message);
            if (clear)
                Display.Clear();
            Display.foreground(ConsoleColor.Green);
            Console.WriteLine("> " + message);
            Display.newLines(2);
        }

        public static void errorMessage(string errorMessage, bool exit = false)
        {
            Const.mylogs.addLog(errorMessage);
            Display.Clear();
            Display.foreground(ConsoleColor.Red);
            Console.WriteLine(errorMessage);
            Display.newLines(2);
            Console.WriteLine("Appuez sur Entrée pour continuer...");
            Console.ReadLine();
            if (exit)
                Process.GetCurrentProcess().Kill();
            Display.Clear();
        }

        public static void foreground(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        public static string readLine(string text)
        {
            Display.foreground(ConsoleColor.White);
            Console.WriteLine(text ?? "");
            Display.newLines(1);
            Console.Write("> ");
            string str = Console.ReadLine();
            Display.newLines(2);
            return str;
        }

        public static void Title()
        {
            Display.foreground(ConsoleColor.Yellow);
            Console.WriteLine("\r\n================================================================================\r\n       __  __ _____  ____    _                   _____ _____ _____  ____  \r\n      |  \\/  |  __ \\|  _ \\  | |            /\\   / ____/ ____|  __ \\|  _ \\ \r\n      | \\  / | |  | | |_) | | |_ ___      /  \\ | |   | |    | |  | | |_) |\r\n      | |\\/| | |  | |  _ <  | __/ _ \\    / /\\ \\| |   | |    | |  | |  _ < \r\n      | |  | | |__| | |_) | | || (_) |  / ____ \\ |___| |____| |__| | |_) |\r\n      |_|  |_|_____/|____/   \\__\\___/  /_/    \\_\\_____\\_____|_____/|____/ \r\n                                                                     \r\n================================================================================\r\n        ");
        }

        public static void Clear()
        {
            Console.Clear();
            Display.Title();
        }

        public static void newLines(int number)
        {
            switch (number)
            {
                case 1:
                    Console.WriteLine(Environment.NewLine);
                    break;
                case 2:
                    Console.WriteLine(Environment.NewLine + Environment.NewLine);
                    break;
                case 3:
                    Console.WriteLine(Environment.NewLine + Environment.NewLine + Environment.NewLine);
                    break;
                case 4:
                    Console.WriteLine(Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine);
                    break;
            }
        }
    }
}
