using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace MultipleRoblox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Multiple Roblox Instances | MainDab Extensions | discord.io/maindab";

            // Intro
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("\r\n  __  __       _ _   _       _        _____       _     _             _____           _                            \r\n |  \\/  |     | | | (_)     | |      |  __ \\     | |   | |           |_   _|         | |                           \r\n | \\  / |_   _| | |_ _ _ __ | | ___  | |__) |___ | |__ | | _____  __   | |  _ __  ___| |_ __ _ _ __   ___ ___  ___ \r\n | |\\/| | | | | | __| | '_ \\| |/ _ \\ |  _  // _ \\| '_ \\| |/ _ \\ \\/ /   | | | '_ \\/ __| __/ _` | '_ \\ / __/ _ \\/ __|\r\n | |  | | |_| | | |_| | |_) | |  __/ | | \\ \\ (_) | |_) | | (_) >  <   _| |_| | | \\__ \\ || (_| | | | | (_|  __/\\__ \\\r\n |_|  |_|\\__,_|_|\\__|_| .__/|_|\\___| |_|  \\_\\___/|_.__/|_|\\___/_/\\_\\ |_____|_| |_|___/\\__\\__,_|_| |_|\\___\\___||___/\r\n                      | |                                                                                          \r\n                      |_|                                                                                          \r\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nMade by Main_EX @ discord.io/maindab\n\n");
            
            // Note
            Console.Write("=== Note ===\nPlease make sure that you ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("run this ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("before running Roblox or it will not work! You must use seperate accounts.\nIf you close this window, all Roblox instances will close except for one.\n\n");
            
            // Actual thing
            new Mutex(true, "ROBLOX_singletonMutex");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Multiple Roblox Instances is now running!\n");

            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.Write("\nDo not press enter or this application will close.");
            //Console.ReadLine();
            Thread.Sleep(-1); //Keeps Application Open Until Closed By User

        }
    }
}
